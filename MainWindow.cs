namespace SpeechSynthesizerENCH
{
    public partial class readIt : Form
    {
        public readIt()
        {
            InitializeComponent();
            loadData();
            voiceNameENComboBox.SelectedIndexChanged += VoiceNameENComboBox_SelectedIndexChanged;
            voiceNameCHComboBox.SelectedIndexChanged += VoiceNameCHComboBox_SelectedIndexChanged;
            readButton.Click += ReadButton_Click;
            saveButton.Click += SaveButton_Click;
        }

        private void SaveButton_Click(object? sender, EventArgs e)
        {
            string t = inputText.Text;
            string fileName = outputFileNameInputBox.Text;
            SpeechSynthesizerLoader.speechEngine.save(t,fileName);
        }

        private void ReadButton_Click(object? sender, EventArgs e)
        {
            string t = inputText.Text;
            SpeechSynthesizerLoader.speechEngine.speak(t);
        }

        private void VoiceNameENComboBox_SelectedIndexChanged(object? sender, EventArgs e)
        {
            var cb = (ComboBox)sender;
            SpeechSynthesizerLoader.speechEngine.selectVoiceEN(cb.SelectedItem.ToString());
        }
        private void VoiceNameCHComboBox_SelectedIndexChanged(object? sender, EventArgs e)
        {
            var cb = (ComboBox)sender;
            SpeechSynthesizerLoader.speechEngine.selectVoiceCH(cb.SelectedItem.ToString());
        }

        protected void loadData()
        {
            voiceNameENComboBox.Items.Clear();
            voiceNameENComboBox.Items.AddRange(SpeechSynthesizerLoader.speechEngine.voiceNamesEN.ToArray());
            if (voiceNameENComboBox.Items.Count > 0)
            {
                voiceNameENComboBox.SelectedIndex = 0;
            }

            voiceNameCHComboBox.Items.Clear();
            voiceNameCHComboBox.Items.AddRange(SpeechSynthesizerLoader.speechEngine.voiceNamesCH.ToArray());
            if (voiceNameCHComboBox.Items.Count > 0)
            {
                voiceNameCHComboBox.SelectedIndex = 0;
            }
        }

        public void finishWindow()
        {
            MessageBox.Show("finished");
        }
        

    }

}