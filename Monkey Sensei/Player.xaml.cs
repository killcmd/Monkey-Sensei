using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using Windows.Media.Protection.PlayReady;

namespace Monkey_Sensei
{
    /// <summary>
    /// Interaction logic for Player.xaml
    /// </summary>
    public partial class Player : Window
    {
        private static readonly HttpClient client = new HttpClient();
        private static readonly WebClient web = new WebClient();
        public static int page = 0;
        public static int vid = 0;
        private string search { get; set; }
        public async Task prevTask(string search1,int page1,int vid1)
        {
            search = search1;
            page = page1;
            vid = vid1;
            string searchQuery = !string.IsNullOrEmpty(search) ? $"&search={search}" : "";
            string url = $"https://steamdeckrepo.com/api/posts?page={page + 1}{searchQuery}";
            HttpResponseMessage response = await client.GetAsync(url);
            response.EnsureSuccessStatusCode();
            string responseBody = await response.Content.ReadAsStringAsync();
            dynamic posts = JsonConvert.DeserializeObject<dynamic>(responseBody).posts;
            player1.Source = posts[vid].video_preview;
            
            player1.Volume = 0.2;
            this.Title = posts[vid1].title + " by " + posts[vid1].user.steam_name;
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
            dynamic posts = JsonConvert.DeserializeObject<dynamic>(responseBody).posts;
            string programs = System.Environment.GetEnvironmentVariable("ProgramFiles(x86)");

            if (Directory.Exists(programs + "\\Steam\\"))
            {
                if (Directory.Exists(programs + "\\Steam\\config\\uioverrides"))
                {
                    if (Directory.Exists(programs + "\\Steam\\config\\uioverrides\\movies"))
                    {

                        if (posts[vid].video != null)
                        {
                            web.DownloadFile(posts[vid].video.ToString(), programs + "\\Steam\\config\\uioverrides\\movies\\" + posts[vid].slug.ToString() + ".webm");


                            MessageBox.Show(posts[vid].title.ToString() + " added.\n", "Monkey Sensei Says:", MessageBoxButton.OK, MessageBoxImage.Information);


                        }



                    }
                    else
                    {
                        Directory.CreateDirectory(programs + "\\Steam\\config\\uioverrides\\movies");
                    }

                }
                else
                {
                    Directory.CreateDirectory(programs + "\\Steam\\config\\uioverrides");
                    Directory.CreateDirectory(programs + "\\Steam\\config\\uioverrides\\movies");
                }

            }
            else
            {
                MessageBox.Show("Please install Steam in the default location.", "Steam is not installed...", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
        }
    }
}
