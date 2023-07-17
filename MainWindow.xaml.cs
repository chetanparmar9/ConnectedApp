using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
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
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Configuration;
using System.Web;
using System.Net;
using Newtonsoft.Json;
using System.Windows.Media.Effects;

namespace WpfApp17
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        HttpClient client;
        string client_id;
        string client_secret;
        string client_secretToken;
        string instance_url;
        string token_type;
        string access_token;
        HttpResponseMessage responseMsg;
        HttpCookie cookie = new HttpCookie("cookies");
       
        public MainWindow()
        {
            InitializeComponent();
            client = new HttpClient();
            client_id = ConfigurationManager.AppSettings["client_id"];
            client_secret = ConfigurationManager.AppSettings["client_secret"];
            client_secretToken= ConfigurationManager.AppSettings["secret_token"];
            instance_url = "";
            token_type = "";
            access_token = "";

        }

        private async Task<bool> getAuthToken()
        {
            bool res = false;
            try
            {
                string pass_secret = passwordTxt.Text + client_secretToken;
                var content = new FormUrlEncodedContent(new[]
                {
                     new KeyValuePair<string, string>("grant_type","password"),
                     new KeyValuePair<string, string>("client_id", client_id),
                     new KeyValuePair<string, string>("client_secret", client_secret),
                     new KeyValuePair<string, string>("username", usernameTxt.Text),
                     new KeyValuePair<string, string>("password", pass_secret)
                });
                responseMsg = await client.PostAsync("https://login.salesforce.com/services/oauth2/token", content);
                var responseCnt = await responseMsg.Content.ReadAsStringAsync();
                dynamic response = JsonConvert.DeserializeObject(responseCnt);
                instance_url = response["instance_url"];
                token_type = response["token_type"];
                access_token = response["access_token"];
                res = true;
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return res;
            
        }

        private async void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {


                bool res = await getAuthToken();
                if (res && access_token != null)
                {
                    Dispatcher.Invoke(() =>
                    {
                        loginPanel.Visibility = Visibility.Hidden;
                    });
                    client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue(token_type, access_token);
                    responseMsg = await client.GetAsync(instance_url + "/services/data");
                    var responseCnt = await responseMsg.Content.ReadAsStringAsync();
                    Dispatcher.Invoke(() =>
                    {
                        resPanel.Visibility = Visibility.Visible;
                        ListView lv = new ListView();
                        StackPanel st_panel = new StackPanel();
                        st_panel.Orientation = Orientation.Vertical;
                        st_panel.HorizontalAlignment = HorizontalAlignment.Stretch;
                        st_panel.Margin = new Thickness(50, 10, 0, 0);
                        dynamic obj = JsonConvert.DeserializeObject(responseCnt);

                        foreach(dynamic dobj in obj)
                        {
                            //Console.WriteLine(dobj);
                            Button btn = new Button();
                            btn.Height = 45;
                            btn.Width = 100;
                            btn.FontWeight = FontWeights.Bold;
                            btn.Content = dobj["version"];
                            Color color = (Color)ColorConverter.ConvertFromString("#FF7BE6A2");
                            btn.Background = new SolidColorBrush(color);
                            btn.HorizontalAlignment = HorizontalAlignment.Left;
                            btn.Margin = new Thickness(0, 10, 0, 0);
                            DropShadowBitmapEffect shadoweffect = new DropShadowBitmapEffect();
                            btn.BorderBrush = new SolidColorBrush(color);
                            shadoweffect.Direction = 300;
                            shadoweffect.Color = (Color)ColorConverter.ConvertFromString("#FFC9C9C9");
                            btn.BitmapEffect = shadoweffect;
                            st_panel.Children.Add(btn);
                        }
                        resPanel.Children.Add(st_panel);
                       
                    });
                    
                    //Console.WriteLine(responseCnt);
                }
                else
                {
                    Dispatcher.Invoke(()=>{
                        usernameTxt.Text = "";
                        passwordTxt.Text = "";
                        MessageBox.Show("invalid credential try to login again ");
                    });
                }
            
            }
            catch (HttpRequestException ex)
            {
                Console.WriteLine("\nException Caught!");
                Console.WriteLine("Message :{0} ", ex.Message);
            }
        }

        private void mouseEnter(object sender, MouseEventArgs e)
        {
            Button btn = (Button)sender;
            Color color = (Color)ColorConverter.ConvertFromString("#FF7BE6A2");
            btn.Background = new SolidColorBrush(color);
        }

        private void focus_GotFocus(object sender, RoutedEventArgs e)
        {
            Button btn = (Button)sender;
            Color color = (Color)ColorConverter.ConvertFromString("#FF7BE6A2");
            btn.Background = new SolidColorBrush(color);
        }
    }
}
