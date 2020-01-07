using System;
using System.Collections.Generic;
using System.Linq;
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

namespace Cancella_Task
{
    /// <summary>
    /// Logica di interazione per MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        bool stop;
        private void Btn_Start1_Click(object sender, RoutedEventArgs e)
        {
            Task.Factory.StartNew(() => DoWork(100,1000, Txt_Countdown1));
        }
        private void Btn_Start2_Click(object sender, RoutedEventArgs e)
        {
            int max = Convert.ToInt32(Txt_MAX1.Text);
            Task.Factory.StartNew(() => DoWork(max, 1000, Txt_Countdown2 ));
        }

        private void Btn_Start3_Click(object sender, RoutedEventArgs e)
        {
            if (stop)
                stop = false;
            int max = Convert.ToInt32(Txt_MAX2.Text);
            int delay = Convert.ToInt32(Txt_Delay.Text);
            Task.Factory.StartNew(() => DoWork(max, delay, Txt_Countdown3));
        }

        private void DoWork(int max,int delay, TextBox txt)
        {
            for(int i=0; i<=100; i++)
            {
               Dispatcher.Invoke(()=> UpdateUI(i, txt));

                Thread.Sleep(delay);

                if (stop)
                    break;
            }
        }

        private void UpdateUI(int i, TextBox txt)
        {
            txt.Text = i.ToString();
        }

        private void Btn_Stop1_Click(object sender, RoutedEventArgs e)
        {
            stop = true;
        }

        private void Btn_Stop2_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Btn_Stop3_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
