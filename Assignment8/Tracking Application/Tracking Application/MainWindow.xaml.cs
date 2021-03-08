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
        public DispatcherTimer Timer = new DispatcherTimer();

        public List<(string Timer, string Description)> Records = new();

        public string CurrentDescription
        {
            get => DescriptionBox.Text;
        }

        public MainWindow()
        {
            InitializeComponent();

            Timer.Interval = new TimeSpan(0, 0, 1);
            Timer.Tick += Timer_Tick;
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            TimerAttributes.IncrementSecond();
            TimerText.Text = TimerAttributes.GetString();
        }

        private void StartButton_Click(object sender, RoutedEventArgs e) => Timer.Start();


        private void StopButton_Click(object sender, RoutedEventArgs e) => Timer.Stop();

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            if(CurrentDescription == string.Empty && TimerText.Text == "0:00:00")
                    return;
            Timer.Stop();
            Records.Add((TimerAttributes.GetString(), CurrentDescription));
            TimerAttributes.ResetTimer();
            DescriptionBox.Text = String.Empty;
            TimerText.Text = "0:00:00";
            RecordsToApplication();
        }

        private void RecordsToApplication()
        {
            SavedTimerOne.Text = Records[^1].Timer;
            SavedDescriptionOne.Text = Records[^1].Description;

            if (Records.Count > 1)
            {
                SavedTimerTwo.Text = Records[^2].Timer;
                SavedDescriptionTwo.Text = Records[^2].Description;
            }

            if (Records.Count > 2)
            {
                SavedTimerThree.Text = Records[^3].Timer;
                SavedDescriptionThree.Text = Records[^3].Description;
            }
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

        public static void IncrementSecond() => TotalTime++;

        public static void ResetTimer() => TotalTime = 0;
    }
}
