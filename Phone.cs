using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json.Serialization;

namespace WPF_PROJECT
{
    public class Phone
    {
        public string? Name { get; set; }
        public Display? Display { get; set; }
        public int Release { get; set; }
        public int Battery { get; set; }
        public Rom? Rom { get; set; }
        public int MainCamera { get; set; }

        public Phone Clone()
        {
            Phone clone = (Phone)MemberwiseClone();
            clone.Display = Display.Clone();
            if (Rom != null)
            {
                clone.Rom = Rom.Clone();
            }
            return clone;
        }
    }

    public class Display
    {
        public string Type { get; set; }
        public float Size { get; set; }

        public Display Clone()
        {
            return (Display)MemberwiseClone();
        }
    }

    public class Rom
    {
        public string Type { get; set; }
        public int Version { get; set; }

        public Rom Clone()
        {
            return (Rom)MemberwiseClone();
        }
    }
}
