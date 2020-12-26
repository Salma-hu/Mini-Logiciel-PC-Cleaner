using System;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Net;
using System.Diagnostics;
namespace PC_Cleaner
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private object lbl_CountDownTimer;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {


        }
        private void btn_historique_Click(object sender, RoutedEventArgs e)
        {
            string lines = DateTime.UtcNow.ToString("f");
            using (System.IO.StreamWriter file =
            new System.IO.StreamWriter(@"C:\Users\Youcode\Desktop\Nouveau dossier\analyse.txt", true))
            {
                file.WriteLine(lines);
            }

            string text = System.IO.File.ReadAllLines(@"C:\Users\Youcode\Desktop\Nouveau dossier\analyse.txt").Last();
            lbl_lastDate.Content = text;
        }

        private void btn_nttoyer_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                DirectoryInfo di = new DirectoryInfo(@"C:\Users\Youcode\Desktop\Nouveau dossier");
                FileInfo[] fiArr = di.GetFiles();
                foreach (var item in fiArr)
                {
                    item.Delete();

                }
                MessageBox.Show("fechier nttoyer");
            }
            catch (Exception)
            {

                throw new ArgumentNullException("try closing all apps");
            }



        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {

        }

        private void Button_Click_4(object sender, RoutedEventArgs e)
        {


            lbl_analyse.Content = "Analyse en cours";
            btn_analyse.Content = "Analyse en cours";
            btn_analyse.IsEnabled = false;


            ProgressBar.Visibility = Visibility.Visible;

            Thread.Sleep(1000);
            ProgressBar.Value = 0;

            Task.Run(() =>
            {
                for (int i = 0; i < 100; i++)
                {
                    Thread.Sleep(50);
                    this.Dispatcher.Invoke(() => //Use Dispather to Update UI Immediately  
                    {
                        ProgressBar.Value = i;
                        if (i == 99)
                        {
                            lbl_analyse.Content = "Analyse terminée !";
                            btn_analyse.IsEnabled = true;
                            btn_analyse.Content = "Analyser";
                            ProgressBar.Visibility = Visibility.Hidden;
                            txt_analyse.Visibility = Visibility.Visible;

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
            txt_analyse.Visibility = Visibility.Hidden;
            txt_analyse.Content = "The size of " + di.Name + " is " + b / 100 + " MB.\n";






        }





        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void TextBox_TextChanged_1(object sender, TextChangedEventArgs e)
        {

        }

        private void ProgressBar_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {








        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {

        }

        private void btn_historique1_Click(object sender, RoutedEventArgs e)
        {
            WebClient webClient = new WebClient();



            if (!webClient.DownloadString("https://pastebin.com/nXxf9a2T").Contains("1.0.0"))
            {
                if (MessageBox.Show("Looks like there is an update! Do you want to download it?", "Demo", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
                    using (var client = new WebClient())
                    {
                        Process.Start(@"C:\Users\Youcode\Desktop\App PC Cleaner\App Update\bin\Release\netcoreapp3.1\App Update.exe");
                        this.Close();
                    }
            }
            else
            {
                /* System.Windows.Forms.MessageBox.Show("vous etes deja a jour!");*/
            }

        }
    }
}
