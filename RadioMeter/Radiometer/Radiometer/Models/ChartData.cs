using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Radiometer.Models
{
    class ChartData
    {
        public SortedDictionary<int, int> data { get; set; }
    }
    class Channel
    {
        public int Value { get; set; }
        public int Type { get; set; }
    }
}
