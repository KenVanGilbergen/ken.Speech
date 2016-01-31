using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading;
using ken.Core.Cryptography;
using Xunit;

namespace ken.Speech.Tests
{
    public class PolishTrainingTests
    {
        [Fact]
        public void TrainingNumbers()
        {
            var lst = new List<Tuple<int, int>>();
            for (var i = 1; i <= 5; i++)
            {
                var rate = Randomizer.Get.Int32(-2, 1); //-10..10
                var number = Randomizer.Get.Int32(0, 199);
                var t = new Tuple<int, int>(number, rate);
                Debug.WriteLine("{0} - Rate: {1}", t.Item1, t.Item2);
                lst.Add(t);
            }

            using (var synth = new PolishSpeechSynthesizer())
            {
                for (var i = 1; i <= 3; i++)
                {
                    foreach (var t in lst)
                    {
                        synth.Rate = t.Item2;
                        synth.Speak(t.Item1.ToString());
                        Thread.Sleep(1000);
                    }
                    Thread.Sleep(3000);
                }
            }
        }

        [Fact]
        public void TrainingSums()
        {
            using (var synth = new PolishSpeechSynthesizer())
            {
                synth.Rate = Randomizer.Get.Int32(-3, 1); //-10..10
                var n1 = Randomizer.Get.Int32(0, 99);
                var n2 = Randomizer.Get.Int32(0, 99);
                var text = String.Format("{0} + {1} = {2}", n1, n2, n1 + n2);
                Debug.WriteLine(text);
                synth.Speak(text);
            }
        }

    }
}
