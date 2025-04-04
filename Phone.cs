using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPF_PROJECT
{
    public class Phone
    {
        public required string Name { get; set; }
        public required Display Display { get; set; }
        public int Release { get; set; }
        public int Battery { get; set; }
        public Rom? Rom { get; set; }
        public int Main_camera { get; set; }
    }

    public class Display
    {
        public required string Type { get; set; }
        public float Size { get; set; }
    }

    public class Rom
    {
        public required string Type { get; set; }
        public int Version { get; set; }
    }

}
