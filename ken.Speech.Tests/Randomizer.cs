// Decompiled with JetBrains decompiler
// Type: ken.Core.Cryptography.Randomizer
// Assembly: ken.Core, Version=0.0.5586.21051, Culture=neutral, PublicKeyToken=null

using System;
using System.Text;

namespace ken.Core.Cryptography
{
    public class Randomizer
    {
        private static bool _mStoredUniformDeviateIsGood = false;
        private const string LegalCharacters = "        abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789      ";
        private static Random _rndm;
        private static double _mStoredUniformDeviate;

        public static Randomizer Get
        {
            get
            {
                return new Randomizer();
            }
        }

        static Randomizer()
        {
            Randomizer.Reset();
        }

        public static void Reset()
        {
            Randomizer._rndm = new Random(Environment.TickCount);
        }

        public double Double()
        {
            return Randomizer._rndm.NextDouble();
        }

        public bool Boolean()
        {
            return Randomizer._rndm.Next(0, 2) != 0;
        }

        public short Int16(short min, short max)
        {
            if ((int)max <= (int)min)
                throw new ArgumentException("Max must be greater than min.");
            return Convert.ToInt16(((double)max * 1.0 - (double)min * 1.0) * Randomizer._rndm.NextDouble() + (double)min * 1.0);
        }

        public int Int32(int min, int max)
        {
            return Randomizer._rndm.Next(min, max);
        }

        public long Int64(long min, long max)
        {
            if (max <= min)
                throw new ArgumentException("Max must be greater than min.");
            return Convert.ToInt64(((double)max * 1.0 - (double)min * 1.0) * Randomizer._rndm.NextDouble() + (double)min * 1.0);
        }

        public float Single(float min, float max)
        {
            if ((double)max <= (double)min)
                throw new ArgumentException("Max must be greater than min.");
            return Convert.ToSingle(((double)max * 1.0 - (double)min * 1.0) * Randomizer._rndm.NextDouble() + (double)min * 1.0);
        }

        public double Double(double min, double max)
        {
            if (max <= min)
                throw new ArgumentException("Max must be greater than min.");
            return (max - min) * Randomizer._rndm.NextDouble() + min;
        }

        public DateTime DateTime(DateTime min, DateTime max)
        {
            if (max <= min)
                throw new ArgumentException("Max must be greater than min.");
            long ticks = min.Ticks;
            return new DateTime(Convert.ToInt64((Convert.ToDouble(max.Ticks) - Convert.ToDouble(ticks)) * Randomizer._rndm.NextDouble() + Convert.ToDouble(ticks)));
        }

        public TimeSpan TimeSpan(TimeSpan min, TimeSpan max)
        {
            if (max <= min)
                throw new ArgumentException("Max must be greater than min.");
            long ticks = min.Ticks;
            return new TimeSpan(Convert.ToInt64((Convert.ToDouble(max.Ticks) - Convert.ToDouble(ticks)) * Randomizer._rndm.NextDouble() + Convert.ToDouble(ticks)));
        }

        public double Normal()
        {
            if (Randomizer._mStoredUniformDeviateIsGood)
            {
                Randomizer._mStoredUniformDeviateIsGood = false;
                return Randomizer._mStoredUniformDeviate;
            }
            double a = 0.0;
            double num1 = 0.0;
            double num2 = 0.0;
            for (; a >= 1.0 || a == 0.0; a = num1 * num1 + num2 * num2)
            {
                num1 = 2.0 * this.Double() - 1.0;
                num2 = 2.0 * this.Double() - 1.0;
            }
            double num3 = Math.Sqrt(-2.0 * Math.Log(a, Math.E) / a);
            Randomizer._mStoredUniformDeviate = num1 * num3;
            Randomizer._mStoredUniformDeviateIsGood = true;
            return num2 * num3;
        }

        public string Binary(int length = 8)
        {
            return Convert.ToString(Randomizer._rndm.Next(1000, int.MaxValue), 2).Substring(0, length);
        }

        public int Bit()
        {
            return new Random().Next() % 2 != 0 ? 0 : 1;
        }

        public string StringWithoutSpaces(int limit = 255)
        {
            return this.String(limit, "        abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789      ".Replace(" ", string.Empty));
        }

        public string String(int limit = 255, string set = "        abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789      ")
        {
            StringBuilder stringBuilder = new StringBuilder();
            limit = Randomizer._rndm.Next(1, limit);
            for (int index = 0; index < limit; ++index)
                stringBuilder.Append(set[Randomizer._rndm.Next(set.Length)]);
            return stringBuilder.ToString();
        }

        public string Color(bool gray = false)
        {
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.Append("#");
            if (gray)
            {
                char ch1 = "0123456789abcdef"[Randomizer._rndm.Next("0123456789abcdef".Length)];
                char ch2 = "0123456789abcdef"[Randomizer._rndm.Next("0123456789abcdef".Length)];
                for (int index = 0; index < 3; ++index)
                {
                    stringBuilder.Append(ch1);
                    stringBuilder.Append(ch2);
                }
            }
            else
            {
                for (int index = 0; index < 6; ++index)
                    stringBuilder.Append("0123456789abcdef"[Randomizer._rndm.Next("0123456789abcdef".Length)]);
            }
            return stringBuilder.ToString();
        }
    }
}
