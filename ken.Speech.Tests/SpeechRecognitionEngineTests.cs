using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using Microsoft.Speech.Recognition;
using Xunit;
using Xunit.Extensions;

namespace ken.Speech.Tests
{
    public class SpeechRecognitionEngineTests
    {
        private IEnumerable<RecognizerInfo> GetInstalledRecognizer()
        {
            var recognizers = SpeechRecognitionEngine.InstalledRecognizers();
            Debug.WriteLine("Installed recognizers -");
            foreach (RecognizerInfo recognizer in recognizers)
            {
                Debug.WriteLine("Name: {0} Culture: {1}", recognizer.Name, recognizer.Culture);
            }
            return recognizers;
        }

        [Theory]
        [InlineData("en-US")]
        [InlineData("pl-PL")]
        public void ShouldHaveCultureInstalled(string cultureName)
        {
            var sut = GetInstalledRecognizer();
            Assert.True(sut.Any(_ => _.Culture.Name == cultureName));
        }
    }
}
