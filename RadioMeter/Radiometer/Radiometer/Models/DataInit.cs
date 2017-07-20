using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Radiometer.Models
{
    class DataInit
    {
        private static ChartData _chartData;
        private static List<Channel> _channels;
        static DataInit()
        {
            Random rdn = new Random();
            _chartData = new ChartData();
            _channels = new List<Channel>();
            for (int i = 0; i < 1000; i++)
            {
                _channels.Add(new Channel
                {
                    Value = i,
                    Type = rdn.Next(0, 2)
                });
            }
      
            _chartData.data = new SortedDictionary<int, int>();
            foreach (Channel ch in _channels)
            {
                _chartData.data[ch.Value] = rdn.Next(1, 200);
            }
        }
        public static List<Channel> GetAllChannels()
        {
            var result = _channels.ToList<Channel>();
            return result;
        }

        public static ChartData ChartData
        {
            get
            {
                return _chartData;
            }
        }
    }
}
