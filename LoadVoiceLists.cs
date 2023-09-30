using System.Speech.Synthesis;



namespace SpeechSynthesizerENCH
{
    internal class LoadVoiceLists
    {
        protected SpeechSynthesizer synth;
        public LoadVoiceLists()
        {
            synth = new SpeechSynthesizer();
            foreach (InstalledVoice i in synth.GetInstalledVoices())
            {
                Console.WriteLine(i.VoiceInfo.Name);
            }

        }
        public List<string> getVoicelist()
        {
            List<string> voiceList = new List<string>();
            foreach (InstalledVoice i in synth.GetInstalledVoices())
            {
                voiceList.Add(i.VoiceInfo.Name);
            }
            return voiceList;
        }
    }
}
