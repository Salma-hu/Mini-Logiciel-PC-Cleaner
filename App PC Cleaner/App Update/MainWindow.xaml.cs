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
using System.Net;
using System.IO;
using System.Diagnostics;
using System.IO.Compression;
using System.Threading;

namespace DemoUpdate
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();




        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }

        private void MessageBoxButtons_Click(object sender, RoutedEventArgs e)
        {

        }

        private void ProgressBar_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {

        }

        private void MessageBoxButtons_Click_1(object sender, RoutedEventArgs e)
        {
            MessageBoxButtons.Visibility = Visibility.Hidden;
            ProgressBar2.Visibility = Visibility.Visible;
            /* txt.Visibility = Visibility.Visible;*/


            Thread.Sleep(1000);
            ProgressBar2.Value = 0;

            Task.Run(() =>
            {
                for (int i = 0; i <= 100; i++)
                {
                    Thread.Sleep(50);
                    this.Dispatcher.Invoke(() => //Use Dispather to Update UI Immediately  
                    {
                        ProgressBar2.Value = i;
                        if (i == 100)
                        {
                            WebClient webClient = new WebClient();
                            var client = new WebClient();

                            string[] files = Directory.GetFiles(@"C:\Users\Youcode\Desktop\App PC Cleaner\App PC Cleaner\bin\Release\netcoreapp3.1");

                            foreach (string file in files)
                            {
                                File.Delete(file);
                            }
                           
                            client.DownloadFile("https://download1350.mediafire.com/fbybm36fzrgg/lvt7sddcb9fay5c/Desktop.zip", @"C:\Users\Youcode\Desktop\App PC Cleaner\App PC Cleaner\bin\Release\netcoreapp3.1\Desktop.zip");
                            string zipPath = @"C:\Users\Youcode\Desktop\App PC Cleaner\App PC Cleaner\bin\Release\netcoreapp3.1\Desktop.zip";
                            //. pour racourcir 
                            string extractPath = @"C:\Users\Youcode\Desktop\App PC Cleaner\App PC Cleaner\bin\Release\netcoreapp3.1";
                            ZipFile.ExtractToDirectory(zipPath, extractPath);
                            File.Delete(@"C:\Users\Youcode\Desktop\App PC Cleaner\App PC Cleaner\bin\Release\netcoreapp3.1\Desktop.zip");
                            Process.Start(@"C:\Users\Youcode\Desktop\App PC Cleaner\App PC Cleaner\bin\Release\netcoreapp3.1\PC Cleaner V2.exe");
                            this.Close();



                        }
                        //lbl_CountDownTimer.Text = i.ToString();
                    });
                }
            });

        }
    }
}
