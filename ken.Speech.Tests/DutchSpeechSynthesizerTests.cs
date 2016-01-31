using Xunit;

namespace ken.Speech.Tests
{
    public class DutchSpeechSynthesizerTests
    {
        [Fact]
        public void ShouldSpeakDutchWords()
        {
            using (var synth = new DutchSpeechSynthesizer())
            {
                synth.Speak("niet");
                synth.Speak("ja");
                synth.Speak("nee");
                synth.Speak("op");
                synth.Speak("onder");
                synth.Speak("broer");
                synth.Speak("boer");
                synth.Speak("tafel");
                synth.Speak("stoel");
            }
        }

        [Fact]
        public void ShouldSpeakPolishNumbers()
        {
            using (var synth = new DutchSpeechSynthesizer())
            {
                for (var i = 0; i <= 25; i++)
                {
                    synth.Speak(i.ToString());
                }
            }
        }
    }
}
