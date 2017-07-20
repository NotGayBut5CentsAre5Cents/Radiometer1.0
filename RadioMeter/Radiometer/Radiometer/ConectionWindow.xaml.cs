using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.IO.Ports;

namespace Radiometer
{
    /// <summary>
    /// Interaction logic for ConectionWindow.xaml
    /// </summary>
    public partial class ConectionWindow : Window
    {
        public static string _port;
        public static int _baudRate;
        public static string _parity;
        public static int _dataBits;
        public static string _stopBits;

        public ConectionWindow()
        {
            InitializeComponent();

            List<string> ports = new List<string>();
            List<int> baudRates = new List<int> { 110, 300, 600, 1200, 2400, 4800, 9600, 14400, 19200 };
            List<string> parities = new List<string>();
            List<int> dataBits = new List<int> { 5, 6, 7, 8 };
            List<string> stopBits = new List<string>();

            foreach (string s in SerialPort.GetPortNames())
            {
                ports.Add(s);
            }
            foreach (string s in Enum.GetNames(typeof(Parity)))
            {
                parities.Add(s);
            }
            foreach (string s in Enum.GetNames(typeof(StopBits)))
            {
                stopBits.Add(s);
            }
            listPortNames.ItemsSource = ports;
            listBaudRate.ItemsSource = baudRates;
            listParity.ItemsSource = parities;
            listDataBits.ItemsSource = dataBits;
            listStopBits.ItemsSource = stopBits;

        }
        private void DataWindow_Closing(object sender, CancelEventArgs e)
        {
            MainWindow.IsConnectionWOpen = false;
        }

        private void setConnectionParams(object sender, RoutedEventArgs e)
        {
            _port = listPortNames.SelectedItem.ToString();
            _baudRate = int.Parse(listBaudRate.SelectedItem.ToString());
            _parity = listParity.SelectedItem.ToString();
            _dataBits = int.Parse(listDataBits.SelectedItem.ToString());
            _stopBits = listStopBits.SelectedItem.ToString();
            Close();
        }

        private void cancelSet(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
