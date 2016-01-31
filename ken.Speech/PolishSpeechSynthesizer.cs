using System;
using System.Speech.Synthesis;

namespace ken.Speech
{
    public class PolishSpeechSynthesizer : UnsealedSpeechSynthesizer
    {
        public PolishSpeechSynthesizer()
        {
            SelectVoice("Microsoft Server Speech Text to Speech Voice (pl-PL, Paulina)");
        }

        public override void Speak(string text)
        {
            text = text.Replace("+", "plus"); // + is not recognized
            text = text.Replace("=", "to"); // + is not recognized
            text = text.Replace(" ", ""); // spaces makes computer say rok
            text = text.Replace("100", "sto"); // say rok something
            base.Speak(text);
        }
    }
}