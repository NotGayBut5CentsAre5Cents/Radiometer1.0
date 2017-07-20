using System;
using System.IO.Ports;
using System.Windows;

namespace Radiometer
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public static bool IsConnectionWOpen { get; set; }
        static SerialPort _serialPort;
        public MainWindow()
        {
            InitializeComponent();
        }
        private void Connect(object sender, RoutedEventArgs e)
        {
            ConectionWindow connectionWindow = new ConectionWindow();
            if (!IsConnectionWOpen)
            {
                var location = connect.PointToScreen(new Point(0, 0));
                connectionWindow.Left = location.X;
                connectionWindow.Top = location.Y;
                connectionWindow.Show();
                IsConnectionWOpen = true;
            }
        }

        private void connectPort(object sender, RoutedEventArgs e)
        {
            _serialPort = new SerialPort(ConectionWindow._port, 
                                         ConectionWindow._baudRate,
                                         (Parity)Enum.Parse(typeof(Parity), ConectionWindow._parity, true),
                                         ConectionWindow._dataBits,
                                         (StopBits)Enum.Parse(typeof(StopBits), ConectionWindow._stopBits, true));
            _serialPort.Open();
        }
    }
}
