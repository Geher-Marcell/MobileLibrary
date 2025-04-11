using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPF_PROJECT
{
    public static class InputChecker
    {
        public static bool StringValueExp(string? value)
        {
            return string.IsNullOrWhiteSpace(value);
        }

        public static bool NumberValueExp(int value)
        {
            return value <= 0;
        }

        public static bool NumberValueExp(double value)
        {
            return value <= 0;
        }
    }
}
