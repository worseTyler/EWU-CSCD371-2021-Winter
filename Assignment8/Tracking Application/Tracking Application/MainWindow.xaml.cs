using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
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

namespace TrackingApplication
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private const string StartTimer = "0:00:00";
        public Timer Timer { get; set; }

        public List<(string Timer, string Description)> Records { get; private set; }

        public string CurrentDescription { get => DescriptionBox.Text; }

        public MainWindow()
        {
            InitializeComponent();
            Records = new();
            Timer = new(1000);
            Timer.Elapsed += Timer_Tick;
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            TimerAttributes.IncrementSecond();
            Dispatcher.Invoke(() => TimerText.Text = TimerAttributes.GetString());
        }

        private void StartButton_Click(object sender, RoutedEventArgs e) => Timer.Start();

        private void StopButton_Click(object sender, RoutedEventArgs e) => Timer.Stop();

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            if(CurrentDescription.Length == 0 && TimerText.Text == StartTimer)
                    return;
            Timer.Stop();
            Records.Add((TimerAttributes.GetString(), CurrentDescription));
            TimerAttributes.ResetTimer();
            DescriptionBox.Text = String.Empty;
            TimerText.Text = StartTimer;
            RecordsToApplication();
        }

        private void RecordsToApplication()
        {
            if(Records.Count > 0)
            {
                SavedTimerOne.Text = Records[^1].Timer;
                SavedDescriptionOne.Text = Records[^1].Description;
            }
            else
            {
                SavedTimerOne.Text = String.Empty;
                SavedDescriptionOne.Text = String.Empty;
            }

            if (Records.Count > 1)
            {
                SavedTimerTwo.Text = Records[^2].Timer;
                SavedDescriptionTwo.Text = Records[^2].Description;
            }
            else
            {
                SavedTimerTwo.Text = String.Empty;
                SavedDescriptionTwo.Text = String.Empty;
            }

            if (Records.Count > 2)
            {
                SavedTimerThree.Text = Records[^3].Timer;
                SavedDescriptionThree.Text = Records[^3].Description;
            }
            else
            {
                SavedTimerThree.Text = String.Empty;
                SavedDescriptionThree.Text = String.Empty;
            }
        }

        // This feels really gross, I wish I could make a collection or array of
        // delete buttons and then use the index to reduce code repetition
        private void DeleteTop_Click(object sender, RoutedEventArgs e)
        {
            if (Records.Count > 0)
                Records.RemoveAt(Records.Count - 1);
            RecordsToApplication();
                
        }

        private void DeleteMiddle_Click(object sender, RoutedEventArgs e)
        {
            if (Records.Count > 1)
                Records.RemoveAt(Records.Count - 2);
            RecordsToApplication();
        }

        private void DeleteBottom_Click(object sender, RoutedEventArgs e)
        {
            if (Records.Count > 2)
                Records.RemoveAt(Records.Count - 3);
            RecordsToApplication();
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
