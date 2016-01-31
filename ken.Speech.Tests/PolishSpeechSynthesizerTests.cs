using Xunit;

namespace ken.Speech.Tests
{
    public class PolishSpeechSynthesizerTests
    {
        [Fact]
        public void ShouldSpeakPolishWords()
        {
            using (var synth = new PolishSpeechSynthesizer())
            {
                synth.Speak("nie");
                synth.Speak("to");
                synth.Speak("się");
                synth.Speak("w");
                synth.Speak("na");
                synth.Speak("i");
                synth.Speak("z");
                synth.Speak("co");
                synth.Speak("jest");
                synth.Speak("że");
                synth.Speak("do");
                synth.Speak("tak");
                synth.Speak("jak");
                synth.Speak("o");
                synth.Speak("mnie");
                synth.Speak("a");
                synth.Speak("ale");
                synth.Speak("mi");
                synth.Speak("za");
                synth.Speak("ja");
                synth.Speak("ci");
                synth.Speak("tu");
                synth.Speak("ty");
                synth.Speak("czy");
                synth.Speak("tym");
                synth.Speak("go");
                synth.Speak("tego");
                synth.Speak("tylko");
                synth.Speak("jestem");
                synth.Speak("po");
                synth.Speak("cię");
                synth.Speak("ma");
                synth.Speak("już");
                synth.Speak("mam");
                synth.Speak("jesteś");
                synth.Speak("może");
                synth.Speak("pan");
                synth.Speak("dla");
                synth.Speak("coś");
                synth.Speak("dobrze");
                synth.Speak("wiem");
                synth.Speak("jeśli");
                synth.Speak("teraz");
                synth.Speak("proszę");
                synth.Speak("od");
                synth.Speak("wszystko");
                synth.Speak("tam");
                synth.Speak("więc");
                synth.Speak("masz");
                synth.Speak("nic");
            }
        }

        [Fact]
        public void ShouldSpeakPolishNumbers()
        {
            using (var synth = new PolishSpeechSynthesizer())
            {
                for (var i = 0; i <= 25; i++)
                {
                    synth.Speak(i.ToString());
                }
            }
        }
    }
}
