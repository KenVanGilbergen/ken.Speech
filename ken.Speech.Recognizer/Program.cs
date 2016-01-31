using System;
using System.Globalization;
using Microsoft.Speech.Recognition;

namespace ken.Speech.Recognizer
{
    class Program
    {
        static void Main(string[] args)
        {
            var recognizers = SpeechRecognitionEngine.InstalledRecognizers();
            Console.WriteLine("Installed recognizers -");
            foreach (RecognizerInfo recognizer in recognizers)
            {
                Console.WriteLine("Name: {0} Culture: {1}", recognizer.Name, recognizer.Culture);
            }

            //var cultureInfo = new CultureInfo("en-US");
            var cultureInfo = new CultureInfo("pl-PL");
            
            var engine = new SpeechRecognitionEngine(cultureInfo);
            
            //AddWord(engine, cultureInfo, "test");
            //AddWord(engine, cultureInfo, "hello");
            //AddWord(engine, cultureInfo, "exit");
            AddWord(engine, cultureInfo, "nie");
            AddWord(engine, cultureInfo, "jeden");
            AddWord(engine, cultureInfo, "jak");
            AddWord(engine, cultureInfo, "rodzina");
            AddWord(engine, cultureInfo, "tata");
            AddWord(engine, cultureInfo, "ojciec");
            AddWord(engine, cultureInfo, "siostra");
            AddWord(engine, cultureInfo, "kuzynka");
            AddWord(engine, cultureInfo, "dziadek");
            AddWord(engine, cultureInfo, "brat");
            AddWord(engine, cultureInfo, "babcia");
            AddWord(engine, cultureInfo, "córka");
            AddWord(engine, cultureInfo, "ciocia");
            AddWord(engine, cultureInfo, "wujek");
            AddWord(engine, cultureInfo, "żona");
            AddWord(engine, cultureInfo, "syn");
            AddWord(engine, cultureInfo, "bratowa");
            AddWord(engine, cultureInfo, "mama");
            AddWord(engine, cultureInfo, "kuzynka");
            AddWord(engine, cultureInfo, "mąż");
            
            engine.SpeechRecognized += engine_SpeechRecognized;
            engine.SetInputToDefaultAudioDevice();
            engine.RecognizeAsync(RecognizeMode.Multiple);

            while (true)
            {
                Console.ReadLine();
            }
        }

        private static void AddWord(SpeechRecognitionEngine engine, CultureInfo cultureInfo, string text)
        {
            //engine.LoadGrammar(new DictationGrammar());
            var grammerBuilder = new GrammarBuilder(text);
            grammerBuilder.Culture = cultureInfo;
            var grammer = new Grammar(grammerBuilder);
            engine.LoadGrammar(grammer);
        }

        private static void engine_SpeechRecognized(object sender, SpeechRecognizedEventArgs e)
        {
            var word = e.Result.Text;
            Console.WriteLine(word);
            using (var synth = new PolishSpeechSynthesizer())
            {
                synth.Speak(word);
            }
        }
    }
}
