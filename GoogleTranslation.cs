using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Google.Api.Gax.ResourceNames;
using Google.Cloud.Translate.V3;
using static Google.Protobuf.Reflection.SourceCodeInfo.Types;

namespace SpeechSynthesizerENCH
{
    internal class GoogleTranslation
    {
        string projectId = "ocrtranslation-401403";
        string locationId = "global";
        public GoogleTranslation()
        {
            var client = TranslationServiceClient.Create();
            var response = client.TranslateText(
                new LocationName(projectId, locationId),
                "fr-FR",
                new[] { "It is raining.", "It is sunny." });
            
            foreach (var translation in response.Translations)
            {
                Console.WriteLine($"Detected language: {translation.DetectedLanguageCode}");
                Console.WriteLine($"Translated text: {translation.TranslatedText}");
                Console.WriteLine();
            }
        }
    }
}
