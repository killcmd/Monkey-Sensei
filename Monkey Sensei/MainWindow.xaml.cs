using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net.Http;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media.Imaging;

namespace Monkey_Sensei
{
    public partial class MainWindow : Window
    {
        private static int page = 0;
        private static string search = "";

        private static readonly HttpClient client = new HttpClient();

        public MainWindow()
        {
            InitializeComponent();
        }

        // Model classes for JSON
        public class User
        {
            public string? steam_name { get; set; }
        }

        public class Post
        {
            public string? title { get; set; }
            public string? thumbnail { get; set; }
            public User? user { get; set; }
        }

        public class ApiResponse
        {
            public List<Post>? posts { get; set; }
        }

        private async void Window_Loaded(object sender, RoutedEventArgs e)
        {
            await LoadPosts();
        }

        private async Task LoadPosts()
        {
            string searchQuery = !string.IsNullOrEmpty(search) ? $"&search={search}" : "";
            string url = $"https://steamdeckrepo.com/api/posts?page={page + 1}{searchQuery}";

            HttpResponseMessage response = await client.GetAsync(url);
            response.EnsureSuccessStatusCode();
            string responseBody = await response.Content.ReadAsStringAsync();

            var apiResponse = JsonConvert.DeserializeObject<ApiResponse>(responseBody);
            var posts = apiResponse?.posts ?? new List<Post>();

            // Clear images
            for (int i = 1; i <= 12; i++)
            {
                Image img = (Image)this.FindName("staticimg" + i.ToString());
                if (img != null)
                {
                    img.Source = null;
                    img.ToolTip = null;
                }
            }

            // Populate images
            for (int i = 1; i <= posts.Count && i <= 12; i++)
            {
                Image img = (Image)this.FindName("staticimg" + i.ToString());
                if (img != null)
                {
                    try
                    {
                        BitmapImage bitmap = new BitmapImage();
                        bitmap.BeginInit();
                        bitmap.UriSource = new Uri(posts[i - 1].thumbnail, UriKind.Absolute);
                        bitmap.CacheOption = BitmapCacheOption.OnLoad;
                        bitmap.EndInit();

                        img.Source = bitmap;
                        img.ToolTip = $"Title: {posts[i - 1].title}\nSteamID: {posts[i - 1].user?.steam_name}";
                    }
                    catch (Exception ex)
                    {
                        Debug.WriteLine($"Image load failed: {ex.Message}");
                    }
                }
            }
        }

        private async void Previous_Click(object sender, RoutedEventArgs e)
        {
            if (page > 0) page--;
            await LoadPosts();
        }

        private async void Next_Click(object sender, RoutedEventArgs e)
        {
            page++;
            await LoadPosts();
        }

        private async void submit_Click(object sender, RoutedEventArgs e)
        {
            page = 0;
            search = searchBox.Text;
            await LoadPosts();
        }

        private async void clear_Click(object sender, RoutedEventArgs e)
        {
            var RandText = new Random().Next(1, 8);
            page = 0;
            search = String.Empty;
            searchBox.Clear();
            await LoadPosts();

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

        private async void searchBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                search = searchBox.Text;
                await LoadPosts();
            }
        }


        private async void InitPlayer(string search2, int page2, int vid2)
        {

            await Dispatcher.BeginInvoke(new Action(() =>
            {
                try
                {

                    Player results1 = new Player();
                    results1.prevTask(search2, page2, vid2).ConfigureAwait(false);
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
