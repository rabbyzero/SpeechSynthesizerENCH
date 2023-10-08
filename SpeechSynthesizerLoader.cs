namespace SpeechSynthesizerENCH
{
    internal static class SpeechSynthesizerLoader
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        /// 

        public static SpeechSynthesizerEngine speechEngine = new SpeechSynthesizerEngine();
        public static readIt mainWindow = new readIt();

        [STAThread]
        static void Main()
        {
            new GoogleTranslation();
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();
            Application.Run(mainWindow);
        }
    }
}