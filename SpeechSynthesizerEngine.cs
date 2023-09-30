using System.Collections.ObjectModel;
using System.Globalization;
using System.Speech.Synthesis;

namespace SpeechSynthesizerENCH
{
    
    internal class SpeechSynthesizerEngine
    {
        public enum Language
        {
            EN,
            CH
        }

        protected SpeechSynthesizer readEngine;
        protected SpeechSynthesizer saveEngine;
        protected ReadOnlyCollection<InstalledVoice> voicesEN;
        public List<string> voiceNamesEN = new List<string>();
        protected ReadOnlyCollection<InstalledVoice> voicesCH;
        public List<string> voiceNamesCH = new List<string>();
        protected string? selectedVoiceNameEN;
        protected string? selectedVoiceNameCH;
        //protected Task? reading;
        //protected Task? saving;
        protected List<PlayItem> playList = new List<PlayItem>();
        protected PlayItem? reading;
        protected PlayItem? saving;

        public SpeechSynthesizerEngine()
        {
            readEngine = new SpeechSynthesizer();
            readEngine.SetOutputToDefaultAudioDevice();
            
            saveEngine = new SpeechSynthesizer();
            //setSaveFile("readit.wav");

            voicesEN = readEngine.GetInstalledVoices(new CultureInfo("en-US"));
            foreach(var voice in voicesEN)
            {
                voiceNamesEN.Add(voice.VoiceInfo.Name);
            }
            if (voiceNamesEN.Count > 0) selectedVoiceNameEN = voiceNamesEN[0];
            voicesCH = readEngine.GetInstalledVoices(new CultureInfo("zh-CN"));
            foreach(var voice in voicesCH)
            {
                voiceNamesCH.Add(voice.VoiceInfo.Name);
            }
            if (voiceNamesCH.Count > 0) selectedVoiceNameCH = voiceNamesCH[0];

            readEngine.SpeakCompleted += ReadEngine_SpeakCompleted;
            saveEngine.SpeakCompleted += SaveEngine_SpeakCompleted;
        }

        private void SaveEngine_SpeakCompleted(object? sender, SpeakCompletedEventArgs e)
        {
            if (saving != null) saving.finish();
        }

        private void ReadEngine_SpeakCompleted(object? sender, SpeakCompletedEventArgs e)
        {
            if(reading != null) reading.finish();
        }

        public void selectVoiceEN(string voiceName)
        {
            selectedVoiceNameEN = voiceName;
        }

        public void selectVoiceCH(string voiceName)
        {
            selectedVoiceNameCH = voiceName;
        }

        public void speak(string t)
        {
            readEngine.SpeakAsyncCancelAll();
            playList.Clear();
            reading = null;

            parseText(t);

            if(playList.Count > 0)
            {
                playList[0].play();
            }
        }

        public void save(string t,string fileName)
        {
            saveEngine.SpeakAsyncCancelAll();
            playList.Clear();
            saving = null;

            setSaveFile(fileName);
            parseText(t,PlayItem.PlayOrSave.SAVE);

            if (playList.Count > 0)
            {
                playList[0].play();
            }
        }

        private void parseText(string text,PlayItem.PlayOrSave ps=PlayItem.PlayOrSave.PLAY)
        {
            string current = "";
            Language currentLanguage=Language.CH; //only to avoid use before assignment warning.
            foreach(var ch in text)
            {
                if (current.Length == 0)
                {
                    current = ch.ToString();

                    if (ch > '~') currentLanguage = Language.CH;
                    else currentLanguage = Language.EN;

                    continue;
                }
                else
                {
                    if (ch > '~')
                    {
                        if (currentLanguage == Language.CH)
                        {
                            current += ch.ToString();
                        }
                        else
                        {
                            PlayItem item = new PlayItem(currentLanguage, current,ps);
                            if(playList.Count > 0) { playList[playList.Count - 1].addPlayItem(item); }
                            playList.Add(item);

                            current = ch.ToString();
                            currentLanguage = Language.CH;
                        }
                    }
                    else//if (ch<='~')
                    {
                        if (currentLanguage == Language.EN)
                        {
                            current += ch.ToString();
                        }
                        else
                        {
                            PlayItem item = new PlayItem(currentLanguage, current, ps);
                            if (playList.Count > 0) { playList[playList.Count - 1].addPlayItem(item); }
                            playList.Add(item);

                            current = ch.ToString();
                            currentLanguage = Language.EN;
                        }
                    }
                }
            }
            if(current.Length > 0)
            {
                PlayItem lastitem = new PlayItem(currentLanguage, current, ps);
                if (playList.Count > 0) { playList[playList.Count - 1].addPlayItem(lastitem); }
                playList.Add(lastitem);
            }
        }

        public void speakEN(string t,PlayItem playing)
        {
            reading = playing;
            readEngine.SelectVoice(selectedVoiceNameEN);
            readEngine.SpeakAsync(t);
        }

        public void speakCH(string t, PlayItem playing)
        {
            reading = playing;
            readEngine.SelectVoice(selectedVoiceNameCH);
            readEngine.SpeakAsync(t);
        }
        public void saveEN(string t, PlayItem playing)
        {
            saving = playing;
            saveEngine.SelectVoice(selectedVoiceNameEN);
            saveEngine.SpeakAsync(t);
        }

        public void saveCH(string t, PlayItem playing)
        {
            saving = playing;
            saveEngine.SelectVoice(selectedVoiceNameCH);
            saveEngine.SpeakAsync(t);
        }
        public void setSaveFile(string saveFile)
        {
            saveEngine.SetOutputToWaveFile(saveFile);
        }
    }

    internal class PlayItem
    {
        public enum Status
        {
            WAIT,
            PLAYING,
            DONE
        }
        public enum PlayOrSave
        {
            PLAY,
            SAVE
        }

        private SpeechSynthesizerEngine.Language language;
        private string text;
        private PlayItem? next;
        private Status status;
        private SpeechSynthesizerEngine engine;
        private PlayOrSave playType;
        
        public PlayItem(SpeechSynthesizerEngine.Language lang, string t,PlayOrSave type=PlayOrSave.PLAY)
        {
            language = lang;
            text = t;
            status = Status.WAIT;
            engine = SpeechSynthesizerLoader.speechEngine;
            playType = type;
        }

        public void addPlayItem(PlayItem item)
        {
            next = item;
        }

        public void play()
        {
            if(status == Status.WAIT)
            {
                if(language == SpeechSynthesizerEngine.Language.EN)
                {
                    if (playType == PlayOrSave.PLAY) engine.speakEN(text,this);
                    else if(playType == PlayOrSave.SAVE) engine.saveEN(text,this);
                }
                else if(language == SpeechSynthesizerEngine.Language.CH)
                {
                    if(playType == PlayOrSave.PLAY)engine.speakCH(text,this);
                    else if (playType == PlayOrSave.SAVE)engine.saveCH(text,this);
                }
                status = Status.PLAYING;
            }
        }

        public void finish()
        {
            status = Status.DONE;
            if(next != null)
            {
                next.play();
            }
            else
            {
                SpeechSynthesizerLoader.mainWindow.finishWindow();
            }
        }
    }
}
