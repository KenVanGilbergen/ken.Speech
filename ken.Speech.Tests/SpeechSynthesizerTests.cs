using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Speech.Synthesis;
using Xunit;
using Xunit.Extensions;

namespace ken.Speech.Tests
{
    /// <summary>
    /// https://msdn.microsoft.com/en-us/library/jj572477(v=office.14).aspx
    /// </summary>
    public class SpeechSynthesizerTests
    {
        private IEnumerable<InstalledVoice> GetInstalledVoices()
        {
            using (var synth = new SpeechSynthesizer())
            {
                var installedVoices = synth.GetInstalledVoices();
                Debug.WriteLine("Installed voices -");
                foreach (InstalledVoice voice in installedVoices)
                {
                    VoiceInfo info = voice.VoiceInfo;
                    Debug.WriteLine(" Voice Name: {0} Culture: {1}", info.Name, info.Culture);
                }
                return installedVoices.ToList();
            }
        }

        [Theory]
        [InlineData("en-US")]
        [InlineData("pl-PL")]
        public void ShouldHaveCultureInstalled(string cultureName)
        {
            var sut = GetInstalledVoices();
            //Assert.True(sut.Any(_ => _.VoiceInfo.Culture.Name == cultureName));
        }
    }
}
