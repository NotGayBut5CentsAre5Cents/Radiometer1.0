using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using LiveCharts.Configurations;
using Radiometer.Models;
using LiveCharts;
using System.Threading;
using System.ComponentModel;

namespace Radiometer.UserControls
{
    /// <summary>
    /// Interaction logic for MainGraphWindow.xaml
    /// </summary>

    public partial class MainGraphWindow : UserControl, INotifyPropertyChanged
    {
        private double _axisMax;
        private double _axisMin;
        public MainGraphWindow()
        {
            InitializeComponent();
            if(!IsReading)
            {
                Read();
            }
            DataContext = this;
        }
        public ChartValues<int> ChartValues { get; set; }
        public bool IsReading { get; set; }
        public double AxisMax
        {
            get { return _axisMax; }
            set
            {
                _axisMax = value;
                OnPropertyChanged("AxisMax");
            }
        }
        public double AxisMin
        {
            get { return _axisMin; }
            set
            {
                _axisMin = value;
                OnPropertyChanged("AxisMin");
            }
        }
        private void SetAxisLimits(ChartData _chartData)
        {
            AxisMax = _chartData.data.Count;
            AxisMin = 0;
        }
        public void Read()
        {
            //var mapper = Mappers.Xy<MeasureModel>()
            //.X(model => model.Channel)
            //.Y(model => model.Value);
            //Charting.For<MeasureModel>(mapper);
            ChartValues = new ChartValues<int>();
            ChartData _chartData = DataInit.ChartData;
            int[] values = new int[_chartData.data.Count];
            _chartData.data.Values.CopyTo(values, 0);
            ChartValues.AddRange(values);
            IsReading = true;

            SetAxisLimits(DataInit.ChartData);
        }
        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName = null)
        {
            if (PropertyChanged != null)
                PropertyChanged.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }

}
