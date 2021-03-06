using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace Tracking_Application
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            DispatcherTimer timer = new DispatcherTimer();
            timer.Interval = TimeSpan.FromMilliseconds(.5);
            timer.Tick += Timer_Tick;
            timer.Start();
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            TimerAttributes.IncrementSecond();
            TimerText.Text = TimerAttributes.GetString();
        }
    }

    public static class TimerAttributes
    {
        public static int TotalTime { get; private set; }
        public static string Description { get; set; }

        public static string GetString()
        {
            string HoursSection = $"{TotalTime / 3600}:";
            string MinutesSection = ((TotalTime / 60) % 60) > 9 ? $"{TotalTime / 60 % 60}:" : $"0{TotalTime / 60 % 60}:";
            string SecondsSection = (TotalTime % 60) > 9 ? $"{TotalTime % 60}" : $"0{TotalTime % 60}";

            return $"{HoursSection}{MinutesSection}{SecondsSection}";
        }

        public static void IncrementSecond()
        {
            TotalTime++;
        }
    }
}
