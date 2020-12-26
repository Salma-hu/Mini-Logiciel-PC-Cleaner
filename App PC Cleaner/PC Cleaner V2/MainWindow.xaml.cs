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
using System.Diagnostics;
using System.IO;
using System.Threading;

namespace UpdateApp
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
            lbl_analyse2.Content = "Analyse en cours";
            btn_analyse2.Content = "Analyse en cours";
            btn_analyse2.IsEnabled = false;


            ProgressBar2.Visibility = Visibility.Visible;

            Thread.Sleep(1000);
            ProgressBar2.Value = 0;

            Task.Run(() =>
            {
                for (int i = 0; i < 100; i++)
                {
                    Thread.Sleep(50);
                    this.Dispatcher.Invoke(() => //Use Dispather to Update UI Immediately  
                    {
                        ProgressBar2.Value = i;
                        if (i == 99)
                        {
                            lbl_analyse2.Content = "Analyse terminée !";
                            btn_analyse2.IsEnabled = true;
                            btn_analyse2.Content = "Analyser";
                            ProgressBar2.Visibility = Visibility.Hidden;
                            txt_analyse2.Visibility = Visibility.Visible;

                        }
                        /*lbl_CountDownTimer.Text = i.ToString();*/
                    });
                }
            });



            DirectoryInfo di = new DirectoryInfo(@"C:\Users\Youcode\Desktop\Nouveau dossier");
            FileInfo[] fiArr = di.GetFiles();
            long b = 0;
            foreach (var fi in fiArr)
            {
                b += fi.Length;
            }
            txt_analyse2.Visibility = Visibility.Hidden;
            txt_analyse2.Content = "The size of " + di.Name + " is " + b / 100 + " MB.\n";
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            string lines = DateTime.UtcNow.ToString("f");
            using (System.IO.StreamWriter file =
            new System.IO.StreamWriter(@"C:\Users\Youcode\Desktop\Nouveau dossier\analyse.txt", true))
            {
                file.WriteLine(lines);
            }

            string text = System.IO.File.ReadAllLines(@"C:\Users\Youcode\Desktop\Nouveau dossier\analyse.txt").Last();
            lbl_lastDate2.Content = text;

        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {

        }
    }
}
