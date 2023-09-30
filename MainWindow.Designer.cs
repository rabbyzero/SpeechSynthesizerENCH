namespace SpeechSynthesizerENCH
{
    partial class readIt
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            outputFileNameInputBox = new TextBox();
            inputText = new TextBox();
            readButton = new Button();
            saveButton = new Button();
            voiceNameENComboBox = new ComboBox();
            voiceNameCHComboBox = new ComboBox();
            SuspendLayout();
            // 
            // outputFileNameInputBox
            // 
            outputFileNameInputBox.Location = new Point(575, 27);
            outputFileNameInputBox.MaxLength = 200;
            outputFileNameInputBox.Name = "outputFileNameInputBox";
            outputFileNameInputBox.Size = new Size(252, 23);
            outputFileNameInputBox.TabIndex = 2;
            outputFileNameInputBox.Text = "Output File Name";
            // 
            // inputText
            // 
            inputText.Location = new Point(26, 67);
            inputText.MaxLength = 327670;
            inputText.Multiline = true;
            inputText.Name = "inputText";
            inputText.ScrollBars = ScrollBars.Both;
            inputText.Size = new Size(801, 522);
            inputText.TabIndex = 3;
            inputText.Text = "Input Text ...";
            inputText.WordWrap = false;
            // 
            // readButton
            // 
            readButton.Location = new Point(860, 27);
            readButton.Name = "readButton";
            readButton.Size = new Size(75, 23);
            readButton.TabIndex = 4;
            readButton.Text = "Read";
            readButton.UseVisualStyleBackColor = true;
            // 
            // saveButton
            // 
            saveButton.Location = new Point(860, 67);
            saveButton.Name = "saveButton";
            saveButton.Size = new Size(75, 23);
            saveButton.TabIndex = 5;
            saveButton.Text = "Save";
            saveButton.UseVisualStyleBackColor = true;
            // 
            // voiceNameENComboBox
            // 
            voiceNameENComboBox.FormattingEnabled = true;
            voiceNameENComboBox.Location = new Point(26, 26);
            voiceNameENComboBox.Name = "voiceNameENComboBox";
            voiceNameENComboBox.Size = new Size(202, 23);
            voiceNameENComboBox.TabIndex = 6;
            // 
            // voiceNameCHComboBox
            // 
            voiceNameCHComboBox.FormattingEnabled = true;
            voiceNameCHComboBox.Location = new Point(249, 26);
            voiceNameCHComboBox.Name = "voiceNameCHComboBox";
            voiceNameCHComboBox.Size = new Size(202, 23);
            voiceNameCHComboBox.TabIndex = 7;
            // 
            // readIt
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(947, 612);
            Controls.Add(voiceNameCHComboBox);
            Controls.Add(voiceNameENComboBox);
            Controls.Add(saveButton);
            Controls.Add(readButton);
            Controls.Add(inputText);
            Controls.Add(outputFileNameInputBox);
            Name = "readIt";
            Text = "Read with MS Speech Synthesizer";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private TextBox outputFileNameInputBox;
        private TextBox inputText;
        private Button readButton;
        private Button saveButton;
        private ComboBox voiceNameENComboBox;
        private ComboBox voiceNameCHComboBox;
    }
}