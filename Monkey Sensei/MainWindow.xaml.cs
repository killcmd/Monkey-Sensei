using Newtonsoft.Json;
using System.Data;
using System.Diagnostics;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace Monkey_Sensei
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {



        private static int page = 0;
        private static string search = "";

        public MainWindow()
        {
            InitializeComponent();
        }

        private static readonly HttpClient client = new HttpClient();
        private static readonly WebClient web = new WebClient();


        private async void Window_Loaded(object sender, RoutedEventArgs e)
        {
            string searchQuery = !string.IsNullOrEmpty(search) ? $"&search={search}" : "";
            string url = $"https://steamdeckrepo.com/api/posts?page={page + 1}{searchQuery}";
            HttpResponseMessage response = await client.GetAsync(url);
            response.EnsureSuccessStatusCode();
            string responseBody = await response.Content.ReadAsStringAsync();
            dynamic posts = JsonConvert.DeserializeObject<dynamic>(responseBody).posts;

            for (int i = 1; i <= 12; i++)
            {
                Image img = (Image)this.FindName("staticimg" + i.ToString());

                img.Source = null;
                img.ToolTip = null;

            }

            for (int i = 1; i <= posts.Count; i++)
            {
                Image img = (Image)this.FindName("staticimg" + i.ToString());

                img.Source = posts[i - 1].thumbnail;
                img.ToolTip = "Title: " + posts[i - 1].title + "\nSteamID: " + posts[i - 1].user.steam_name;

            }
        

        }

        private async void Window_Refresh()
        {
            string searchQuery = !string.IsNullOrEmpty(search) ? $"&search={search}" : "";
            string url = $"https://steamdeckrepo.com/api/posts?page={page + 1}{searchQuery}";
            HttpResponseMessage response = await client.GetAsync(url);
            response.EnsureSuccessStatusCode();
            string responseBody = await response.Content.ReadAsStringAsync();
            dynamic posts = JsonConvert.DeserializeObject<dynamic>(responseBody).posts;

            for (int i = 1; i <= 12; i++)
            {
                Image img = (Image)this.FindName("staticimg" + i.ToString());

                img.Source = null;
                img.ToolTip = null;

            }

            for (int i = 1; i <= posts.Count; i++)
            {
                Image img = (Image)this.FindName("staticimg" + i.ToString());

                img.Source = posts[i - 1].thumbnail;
                img.ToolTip = "Title: " + posts[i - 1].title + "\nSteamID: " + posts[i - 1].user.steam_name;

            }

        }

        private void Previous_Click(object sender, RoutedEventArgs e)
        {
            page -=1;
            Window_Refresh();
        }

        private void Next_Click(object sender, RoutedEventArgs e)
        {
            page +=1;
            Window_Refresh();

        }


        private async void submit_Click(object sender, RoutedEventArgs e)
        {
            page = 0;
            search = searchBox.Text;
            Window_Refresh();

        }

        private async void clear_Click(object sender, RoutedEventArgs e)
        {
            var RandText = new Random().Next(1, 8);
            page = 0;
            search = null;
            searchBox.Clear();
            Window_Refresh();
            searchBox.Text = RandText switch
            { 
            1 => "Top 10 Anime Betrayals",
            2 => "How not to get catfished",
            3 => "Boku no Pico",
            4 => "iPhone used as a ballistic missile",
            5 => "Hoodrat shit",
            6 => "Booty Warrior",
            7 => "Muscle Mommies",
            8 => "Boomer Shit",
            _ => "Top 10 Anime Betrayals"
            
            };
        }

        private void Monkey_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
         

            Process.Start(new ProcessStartInfo("https://github.com/killcmd") { UseShellExecute = true });

        }

        private void searchBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                search = searchBox.Text;
                Window_Refresh();
            }
        }

        private async void InitPlayer (string search2, int page2 , int vid2)
        {

            await Dispatcher.BeginInvoke(new Action(() =>
            {
                try
                {

                        Player results1 = new Player();
                        results1.prevTask(search2, page2,vid2);
                        results1.Owner = this;
                        results1.Topmost = true;
                        results1.ShowDialog();


                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }));
        }

        Player PlayerOne = new Player()
        {
            Topmost = true
        };
        private async void staticimg3_MouseDown(object sender, MouseButtonEventArgs e)
        {

                InitPlayer(search, page, 2);



        }

        private async void staticimg2_MouseDown(object sender, MouseButtonEventArgs e)
        {

                InitPlayer(search, page, 1);



        }

        private async void staticimg1_MouseDown(object sender, MouseButtonEventArgs e)
        {

            
                InitPlayer(search, page, 0);



        }

        private async void staticimg6_MouseDown(object sender, MouseButtonEventArgs e)
        {

            
                InitPlayer(search, page, 5);



        }

        private async void staticimg5_MouseDown(object sender, MouseButtonEventArgs e)
        {

            
                InitPlayer(search, page, 4);



        }

        private async void staticimg4_MouseDown(object sender, MouseButtonEventArgs e)
        {

            
                InitPlayer(search, page, 3);



        }

        private async void staticimg9_MouseDown(object sender, MouseButtonEventArgs e)
        {

            
                InitPlayer(search, page, 8);



        }

        private async void staticimg8_MouseDown(object sender, MouseButtonEventArgs e)
        {

            
                InitPlayer(search, page, 7);



        }

        private async void staticimg7_MouseDown(object sender, MouseButtonEventArgs e)
        {

            
                InitPlayer(search, page, 6);



        }

        private async void staticimg12_MouseDown(object sender, MouseButtonEventArgs e)
        {

            
                InitPlayer(search, page, 11);



        }

        private async void staticimg11_MouseDown(object sender, MouseButtonEventArgs e)
        {

            
                InitPlayer(search, page, 10);



        }

        private async void staticimg10_MouseDown(object sender, MouseButtonEventArgs e)
        {

            
                InitPlayer(search, page, 9);



        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            Environment.Exit(0);
        }

        private void searchBox_GotFocus(object sender, RoutedEventArgs e)
        {
        searchBox.Clear();
        }
    }
}