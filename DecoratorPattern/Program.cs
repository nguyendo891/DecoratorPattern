
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DecoratorPattern
{
    [DebuggerDisplay("{value*100.0f)%")]
    public struct Percentage
    {
        private readonly float value;
        internal Percentage(float value)
        {
            this.value = value;
        }

        public static float operator *(float f, Percentage p)
        {
            return f * p.value;
        }
        public static float operator +(Percentage f, Percentage p)
        {
            return f.value + p.value;
        }
        public override string ToString()
        {
            return $"{value * 100}%";
        }
    }

    public static class PercentageExtensions
    {
        public static Percentage Percent(this float value)
        {
            return new Percentage(value / 100.0f);
        }

        public static Percentage Percent(this int value)
        {
            return new Percentage(value / 100.0f);
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(10f * 5.Percent());
            Console.WriteLine(2.Percent() + 3.Percent());
        }
    }
}
