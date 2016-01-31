using System;
using System.Speech.Synthesis;

namespace ken.Speech
{
    public class UnsealedSpeechSynthesizer : IDisposable
    {
        private readonly SpeechSynthesizer _decorated = new SpeechSynthesizer();
        
        public void Dispose()
        {
            _decorated.Dispose();
        }

        public void SelectVoice(string name)
        {
            _decorated.SelectVoice(name);
        }

        public virtual int Rate
        {
            get { return _decorated.Rate; }
            set { _decorated.Rate = value; }
        }

        public virtual void Speak(string text)
        {
            _decorated.Speak(text);
        }
    }
}