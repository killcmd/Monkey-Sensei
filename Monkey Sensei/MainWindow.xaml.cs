using Newtonsoft.Json;
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
        public static int page = 0;
        private string search {  get; set; }

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
                MediaElement img = (MediaElement)this.FindName("img_" + i.ToString());

                img.Source = null;
                img.ToolTip = null;

            }

            for (int i = 1; i <= posts.Count; i++)
            {
                MediaElement img = (MediaElement)this.FindName("img_" + i.ToString());

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
                MediaElement img = (MediaElement)this.FindName("img_" + i.ToString());

                img.Source = null;
                img.ToolTip = null;

            }

            for (int i = 1; i <= posts.Count; i++)
            {
                MediaElement img = (MediaElement)this.FindName("img_" + i.ToString());

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

        private async void three_MouseDown(object sender, MouseButtonEventArgs e)
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

                            if (posts[2].video != null)
                            {
                            web.DownloadFile(posts[2].video.ToString(), programs + "\\Steam\\config\\uioverrides\\movies\\" + posts[2].slug.ToString() + ".webm");


                            MessageBox.Show(posts[2].title.ToString() + " added.\n", "Monkey Sensei Says:", MessageBoxButton.OK, MessageBoxImage.Information);


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

        private async void two_MouseDown(object sender, MouseButtonEventArgs e)
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

                        if (posts[1].video != null)
                        {
                            web.DownloadFile(posts[1].video.ToString(), programs + "\\Steam\\config\\uioverrides\\movies\\" + posts[1].slug.ToString() + ".webm");


                            MessageBox.Show(posts[1].title.ToString() + " added.\n", "Monkey Sensei Says:", MessageBoxButton.OK, MessageBoxImage.Information);


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

        private async void one_MouseDown(object sender, MouseButtonEventArgs e)
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

                        if (posts[0].video != null)
                        {
                            web.DownloadFile(posts[0].video.ToString(), programs + "\\Steam\\config\\uioverrides\\movies\\" + posts[0].slug.ToString() + ".webm");
                            

                            MessageBox.Show(posts[0].title.ToString() + " added.\n", "Monkey Sensei Says:", MessageBoxButton.OK, MessageBoxImage.Information);


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

        private async void six_MouseDown(object sender, MouseButtonEventArgs e)
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

                        if (posts[5].video != null)
                        {
                            web.DownloadFile(posts[5].video.ToString(), programs + "\\Steam\\config\\uioverrides\\movies\\" + posts[5].slug.ToString() + ".webm");


                            MessageBox.Show(posts[5].title.ToString() + " added.\n", "Monkey Sensei Says:", MessageBoxButton.OK, MessageBoxImage.Information);


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

        private async void five_MouseDown(object sender, MouseButtonEventArgs e)
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

                        if (posts[1].video != null)
                        {
                            web.DownloadFile(posts[4].video.ToString(), programs + "\\Steam\\config\\uioverrides\\movies\\" + posts[4].slug.ToString() + ".webm");


                            MessageBox.Show(posts[4].title.ToString() + " added.\n", "Monkey Sensei Says:", MessageBoxButton.OK, MessageBoxImage.Information);


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

        private async void four_MouseDown(object sender, MouseButtonEventArgs e)
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

                        if (posts[3].video != null)
                        {
                            web.DownloadFile(posts[3].video.ToString(), programs + "\\Steam\\config\\uioverrides\\movies\\" + posts[3].slug.ToString() + ".webm");


                            MessageBox.Show(posts[3].title.ToString() + " added.\n", "Monkey Sensei Says:", MessageBoxButton.OK, MessageBoxImage.Information);


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

        private async void nine_MouseDown(object sender, MouseButtonEventArgs e)
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

                        if (posts[8].video != null)
                        {
                            web.DownloadFile(posts[8].video.ToString(), programs + "\\Steam\\config\\uioverrides\\movies\\" + posts[8].slug.ToString() + ".webm");


                            MessageBox.Show(posts[8].title.ToString() + " added.\n", "Monkey Sensei Says:", MessageBoxButton.OK, MessageBoxImage.Information);


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

        private async void eight_MouseDown(object sender, MouseButtonEventArgs e)
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

                        if (posts[7].video != null)
                        {
                            web.DownloadFile(posts[7].video.ToString(), programs + "\\Steam\\config\\uioverrides\\movies\\" + posts[7].slug.ToString() + ".webm");


                            MessageBox.Show(posts[7].title.ToString() + " added.\n", "Monkey Sensei Says:", MessageBoxButton.OK, MessageBoxImage.Information);


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

        private async void seven_MouseDown(object sender, MouseButtonEventArgs e)
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

                        if (posts[6].video != null)
                        {
                            web.DownloadFile(posts[6].video.ToString(), programs + "\\Steam\\config\\uioverrides\\movies\\" + posts[6].slug.ToString() + ".webm");


                            MessageBox.Show(posts[6].title.ToString() + " added.\n", "Monkey Sensei Says:", MessageBoxButton.OK, MessageBoxImage.Information);


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

        private async void twelve_MouseDown(object sender, MouseButtonEventArgs e)
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

                        if (posts[11].video != null)
                        {
                            web.DownloadFile(posts[11].video.ToString(), programs + "\\Steam\\config\\uioverrides\\movies\\" + posts[11].slug.ToString() + ".webm");


                            MessageBox.Show(posts[11].title.ToString() + " added.\n", "Monkey Sensei Says:", MessageBoxButton.OK, MessageBoxImage.Information);


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

        private async void eleven_MouseDown(object sender, MouseButtonEventArgs e)
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

                        if (posts[1].video != null)
                        {
                            web.DownloadFile(posts[10].video.ToString(), programs + "\\Steam\\config\\uioverrides\\movies\\" + posts[10].slug.ToString() + ".webm");


                            MessageBox.Show(posts[10].title.ToString() + " added.\n", "Monkey Sensei Says:", MessageBoxButton.OK, MessageBoxImage.Information);


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

        private async void ten_MouseDown(object sender, MouseButtonEventArgs e)
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

                        if (posts[9].video != null)
                        {
                            web.DownloadFile(posts[9].video.ToString(), programs + "\\Steam\\config\\uioverrides\\movies\\" + posts[9].slug.ToString() + ".webm");


                            MessageBox.Show(posts[9].title.ToString() + " added.\n", "Monkey Sensei Says:",MessageBoxButton.OK,MessageBoxImage.Information);


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
                MessageBox.Show("Please install Steam in the default location.", "Steam is not installed...",MessageBoxButton.OK,MessageBoxImage.Error);
            }
        }

        private async void three_MouseEnter(object sender, MouseEventArgs e)
        {
            
           
            string searchQuery = !string.IsNullOrEmpty(search) ? $"&search={search}" : "";
            string url = $"https://steamdeckrepo.com/api/posts?page={page + 1}{searchQuery}";
            HttpResponseMessage response = await client.GetAsync(url);
            response.EnsureSuccessStatusCode();
            string responseBody = await response.Content.ReadAsStringAsync();
            dynamic posts = JsonConvert.DeserializeObject<dynamic>(responseBody).posts;
            img_3.Source = posts[2].video_preview;
            img_3.Volume = 0.03;
            
        }

        private void three_MouseLeave(object sender, MouseEventArgs e)
        {
            img_3.Volume = 0;

        }

        private async void two_MouseEnter(object sender, MouseEventArgs e)
        {
            string searchQuery = !string.IsNullOrEmpty(search) ? $"&search={search}" : "";
            string url = $"https://steamdeckrepo.com/api/posts?page={page + 1}{searchQuery}";
            HttpResponseMessage response = await client.GetAsync(url);
            response.EnsureSuccessStatusCode();
            string responseBody = await response.Content.ReadAsStringAsync();
            dynamic posts = JsonConvert.DeserializeObject<dynamic>(responseBody).posts;
            img_2.Source = posts[1].video_preview;
            img_2.Volume = 0.03;
        }

        private void two_MouseLeave(object sender, MouseEventArgs e)
        {
            img_2.Volume = 0;

        }

        private async void one_MouseEnter(object sender, MouseEventArgs e)
        {
            string searchQuery = !string.IsNullOrEmpty(search) ? $"&search={search}" : "";
            string url = $"https://steamdeckrepo.com/api/posts?page={page + 1}{searchQuery}";
            HttpResponseMessage response = await client.GetAsync(url);
            response.EnsureSuccessStatusCode();
            string responseBody = await response.Content.ReadAsStringAsync();
            dynamic posts = JsonConvert.DeserializeObject<dynamic>(responseBody).posts;
            img_1.Source = posts[0].video_preview;
            img_1.Volume = 0.03;

        }

        private void one_MouseLeave(object sender, MouseEventArgs e)
        {
            img_1.Volume = 0;
        }

        private async void six_MouseEnter(object sender, MouseEventArgs e)
        {
            string searchQuery = !string.IsNullOrEmpty(search) ? $"&search={search}" : "";
            string url = $"https://steamdeckrepo.com/api/posts?page={page + 1}{searchQuery}";
            HttpResponseMessage response = await client.GetAsync(url);
            response.EnsureSuccessStatusCode();
            string responseBody = await response.Content.ReadAsStringAsync();
            dynamic posts = JsonConvert.DeserializeObject<dynamic>(responseBody).posts;
            img_6.Source = posts[5].video_preview;
            img_6.Volume = 0.03;

        }

        private void six_MouseLeave(object sender, MouseEventArgs e)
        {
            img_6.Volume = 0;

        }

        private async void five_MouseEnter(object sender, MouseEventArgs e)
        {
            string searchQuery = !string.IsNullOrEmpty(search) ? $"&search={search}" : "";
            string url = $"https://steamdeckrepo.com/api/posts?page={page + 1}{searchQuery}";
            HttpResponseMessage response = await client.GetAsync(url);
            response.EnsureSuccessStatusCode();
            string responseBody = await response.Content.ReadAsStringAsync();
            dynamic posts = JsonConvert.DeserializeObject<dynamic>(responseBody).posts;
            img_5.Source = posts[4].video_preview;
            img_5.Volume = 0.03;

        }

        private void five_MouseLeave(object sender, MouseEventArgs e)
        {
            img_5.Volume = 0;

        }

        private async void four_MouseEnter(object sender, MouseEventArgs e)
        {
            string searchQuery = !string.IsNullOrEmpty(search) ? $"&search={search}" : "";
            string url = $"https://steamdeckrepo.com/api/posts?page={page + 1}{searchQuery}";
            HttpResponseMessage response = await client.GetAsync(url);
            response.EnsureSuccessStatusCode();
            string responseBody = await response.Content.ReadAsStringAsync();
            dynamic posts = JsonConvert.DeserializeObject<dynamic>(responseBody).posts;
            img_4.Source = posts[3].video_preview;
            img_4.Volume = 0.03;

        }

        private void four_MouseLeave(object sender, MouseEventArgs e)
        {
            img_4.Volume = 0;

        }

        private async void nine_MouseEnter(object sender, MouseEventArgs e)
        {
            string searchQuery = !string.IsNullOrEmpty(search) ? $"&search={search}" : "";
            string url = $"https://steamdeckrepo.com/api/posts?page={page + 1}{searchQuery}";
            HttpResponseMessage response = await client.GetAsync(url);
            response.EnsureSuccessStatusCode();
            string responseBody = await response.Content.ReadAsStringAsync();
            dynamic posts = JsonConvert.DeserializeObject<dynamic>(responseBody).posts;
            img_9.Source = posts[8].video_preview;
            img_9.Volume = 0.03;

        }

        private void nine_MouseLeave(object sender, MouseEventArgs e)
        {

            img_9.Volume = 0;

        }

        private async void eight_MouseEnter(object sender, MouseEventArgs e)
        {
            string searchQuery = !string.IsNullOrEmpty(search) ? $"&search={search}" : "";
            string url = $"https://steamdeckrepo.com/api/posts?page={page + 1}{searchQuery}";
            HttpResponseMessage response = await client.GetAsync(url);
            response.EnsureSuccessStatusCode();
            string responseBody = await response.Content.ReadAsStringAsync();
            dynamic posts = JsonConvert.DeserializeObject<dynamic>(responseBody).posts;
            img_8.Source = posts[7].video_preview;
            img_8.Volume = 0.03;
           

        }

        private void eight_MouseLeave(object sender, MouseEventArgs e)
        {
            img_8.Volume = 0;

        }

        private async void seven_MouseEnter(object sender, MouseEventArgs e)
        {
            string searchQuery = !string.IsNullOrEmpty(search) ? $"&search={search}" : "";
            string url = $"https://steamdeckrepo.com/api/posts?page={page + 1}{searchQuery}";
            HttpResponseMessage response = await client.GetAsync(url);
            response.EnsureSuccessStatusCode();
            string responseBody = await response.Content.ReadAsStringAsync();
            dynamic posts = JsonConvert.DeserializeObject<dynamic>(responseBody).posts;
            img_7.Source = posts[6].video_preview;
            img_7.Volume = 0.03;

        }

        private void seven_MouseLeave(object sender, MouseEventArgs e)
        {
            img_7.Volume = 0;

        }

        private async void twelve_MouseEnter(object sender, MouseEventArgs e)
        {
            string searchQuery = !string.IsNullOrEmpty(search) ? $"&search={search}" : "";
            string url = $"https://steamdeckrepo.com/api/posts?page={page + 1}{searchQuery}";
            HttpResponseMessage response = await client.GetAsync(url);
            response.EnsureSuccessStatusCode();
            string responseBody = await response.Content.ReadAsStringAsync();
            dynamic posts = JsonConvert.DeserializeObject<dynamic>(responseBody).posts;
            img_12.Source = posts[11].video_preview;
            img_12.Volume = 0.03;

        }

        private void twelve_MouseLeave(object sender, MouseEventArgs e)
        {
            img_12.Volume = 0;

        }

        private async void eleven_MouseEnter(object sender, MouseEventArgs e)
        {
            string searchQuery = !string.IsNullOrEmpty(search) ? $"&search={search}" : "";
            string url = $"https://steamdeckrepo.com/api/posts?page={page + 1}{searchQuery}";
            HttpResponseMessage response = await client.GetAsync(url);
            response.EnsureSuccessStatusCode();
            string responseBody = await response.Content.ReadAsStringAsync();
            dynamic posts = JsonConvert.DeserializeObject<dynamic>(responseBody).posts;
            img_11.Source = posts[10].video_preview;
            img_11.Volume = 0.03;

        }

        private void eleven_MouseLeave(object sender, MouseEventArgs e)
        {
            img_11.Volume = 0;

        }

        private async void ten_MouseEnter(object sender, MouseEventArgs e)
        {
            string searchQuery = !string.IsNullOrEmpty(search) ? $"&search={search}" : "";
            string url = $"https://steamdeckrepo.com/api/posts?page={page + 1}{searchQuery}";
            HttpResponseMessage response = await client.GetAsync(url);
            response.EnsureSuccessStatusCode();
            string responseBody = await response.Content.ReadAsStringAsync();
            dynamic posts = JsonConvert.DeserializeObject<dynamic>(responseBody).posts;
            img_10.Source = posts[9].video_preview;
            img_10.Volume = 0.03;

        }

        private void ten_MouseLeave(object sender, MouseEventArgs e)
        {
            img_10.Volume = 0;

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
    }
}