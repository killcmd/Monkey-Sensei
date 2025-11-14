using Newtonsoft.Json.Linq;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Windows;

namespace Monkey_Sensei
{
    public partial class Player : Window
    {
        private static readonly HttpClient client = new HttpClient();
        private static readonly WebClient web = new();
        public static int page = 0;
        public static int vid = 0;
        private string search { get; set; }

        public async Task prevTask(string search1, int page1, int vid1)
        {
            search = search1;
            page = page1;
            vid = vid1;

            string searchQuery = !string.IsNullOrEmpty(search) ? $"&search={search}" : "";
            string url = $"https://steamdeckrepo.com/api/posts?page={page + 1}{searchQuery}";

            HttpResponseMessage response = await client.GetAsync(url);
            response.EnsureSuccessStatusCode();
            string responseBody = await response.Content.ReadAsStringAsync();

            // ✅ Use JObject
            JObject json = JObject.Parse(responseBody);
            JArray posts = (JArray)json["posts"];

            if (posts != null && posts.Count > vid)
            {
                player1.Source = new Uri(posts[vid]["video_preview"]?.ToString() ?? "");
                player1.Volume = 0.2;

                string title = posts[vid1]["title"]?.ToString() ?? "Untitled";
                string user = posts[vid1]["user"]?["steam_name"]?.ToString() ?? "Unknown";

                this.Title = $"{title} by {user}";
                subtitles.Content = $"{title}\nby {user}";
            }
        }

        public Player()
        {
            InitializeComponent();
        }

        private async void Next_Click(object sender, RoutedEventArgs e)
        {
            string searchQuery = !string.IsNullOrEmpty(search) ? $"&search={search}" : "";
            string url = $"https://steamdeckrepo.com/api/posts?page={page + 1}{searchQuery}";

            HttpResponseMessage response = await client.GetAsync(url);
            response.EnsureSuccessStatusCode();
            string responseBody = await response.Content.ReadAsStringAsync();

            JObject json = JObject.Parse(responseBody);
            JArray posts = (JArray)json["posts"];

            string? programs = Environment.GetEnvironmentVariable("ProgramFiles(x86)");

            if (programs != null && Directory.Exists(programs + "\\Steam\\"))
            {
                string moviesPath = programs + "\\Steam\\config\\uioverrides\\movies";
                Directory.CreateDirectory(moviesPath);

                if (posts != null && posts.Count > vid && posts[vid]["video"] != null)
                {
                    string videoUrl = posts[vid]["video"]?.ToString();
                    string slug = posts[vid]["slug"]?.ToString() ?? Guid.NewGuid().ToString();

                    web.DownloadFile(videoUrl, Path.Combine(moviesPath, slug + ".webm"));

                    MessageBox.Show(posts[vid]["title"]?.ToString() + " added.\n",
                        "Monkey Sensei Says:", MessageBoxButton.OK, MessageBoxImage.Information);
                }
            }
            else
            {
                MessageBox.Show("Please install Steam in the default location.",
                    "Steam is not installed...", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
