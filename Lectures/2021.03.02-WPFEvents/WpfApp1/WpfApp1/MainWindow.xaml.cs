using System;
using System.Collections.Generic;
using System.DirectoryServices;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading;
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

namespace WpfApp1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public delegate void MyAction(string s);
        public event MyAction MyEvent;

        private Timer Timer { get; }
        private DispatcherTimer DispatcherTimer { get; }

        public MainWindow()
        {
            InitializeComponent();
            Action action = () => { };

            MyAction myAction = new MyAction(s => { });

            int count = 0;
            var handler1 = new MyAction(s =>
            {
                count++;
            });

            MyEvent += handler1;
            MyEvent -= handler1;
            MyEvent?.Invoke("42");

            MyTextBlock.Text = $"Count is {count}";

            //MyButton.Click += MyButton_Click;

            //Timer = new Timer(OnTimerTick, null, TimeSpan.Zero, TimeSpan.FromSeconds(1));

            DispatcherTimer = new();
            DispatcherTimer.Interval = TimeSpan.FromSeconds(1);
            DispatcherTimer.Tick += DispatcherTimer_Tick;
            //DispatcherTimer.Start();

        }

        private void DispatcherTimer_Tick(object sender, EventArgs e)
        {
            MyTextBlock.Text = $"{DateTime.Now}";
        }

        private void OnTimerTick(object state)
        {
            Dispatcher.Invoke(() => MyTextBlock.Text = $"{DateTime.Now}");
        }

        private int Counter { get; set; }
        private void MyButton_Click(object sender, RoutedEventArgs e)
        {
            //await Task.Delay(50);
            var counter = Counter++;
            MyTextBlock.Text = $"{counter}";
            MyListBox.Items.Add($"{counter}");
            //try
            //{
            //await HandleButtonClick();
            //}
            //catch(Exception)
            //{
            //    //TODO Logging etc
            //}
        }

        private async Task HandleButtonClick()
        {
            MyTextBlock.Text = $"Waiting...";

            //await Task.Delay(TimeSpan.FromSeconds(1));
            await Task.Run(() => 
            {
                //Cannot do this on a background thread!
                //MyTextBlock.Text = $"Doing work...";

                Dispatcher.Invoke(() => MyTextBlock.Text = $"Doing work...");
            
                //Contemplate the meaning of life
                Thread.Sleep(1000);
            });

            MyTextBlock.Text = $"Done";
        }

        private void CloseButton_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void MyListBox_KeyDown(object sender, KeyEventArgs e)
        {
            e.Handled = true;
            if (e.Key == Key.Delete)
            {
                MyListBox.Items.Remove(MyListBox.Items.OfType<object>().Last());
            }
        }
    }
}
