using System;
using System.Speech.Synthesis;

namespace ken.Speech
{
    public class DutchSpeechSynthesizer : UnsealedSpeechSynthesizer
    {
        public DutchSpeechSynthesizer()
        {
            SelectVoice("Microsoft Server Speech Text to Speech Voice (nl-NL, Hanna)");
        }
    }
}