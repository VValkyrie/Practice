using System;
using System.ComponentModel;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Xamarin.Forms;

namespace Twitter {
    [DesignTimeVisible(false)]
    public partial class MainPage : ContentPage {
        public TwitAuthenticateResponse auth;

        public MainPage() {
            InitializeComponent();
            this.twitterButton.Clicked += (sender, e) => {
                LoginInTwitterAsync();
            };
        }

        public async Task LoginInTwitterAsync() {
            var oAuthConsumerKey = "XFxFHcAmw0kFnJAJsDTwNnLfE";
            var oAuthConsumerSecret = "ycaxDfgMUB90tXf8uWn6F4AXZjjoxWypaqkQp4DcEvNHDhStFs";
            var oAuthUri = new Uri("https://api.twitter.com/oauth2/token");
            var authHeaderFormat = "Basic {0}";
            var authHeader = string.Format(
                authHeaderFormat,
                Convert.ToBase64String(
                    Encoding.UTF8.GetBytes(Uri.EscapeDataString(oAuthConsumerKey)
                        + ":" +
                        Uri.EscapeDataString((oAuthConsumerSecret))
                    )
                )
            );

            var req = new HttpClient();
            req.DefaultRequestHeaders.Add("Authorization", authHeader);

            HttpRequestMessage msg = new HttpRequestMessage(new HttpMethod("POST"), oAuthUri);
            msg.Content = new StringContent("grant_type=client_credentials");
            msg.Content.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/x-www-form-urlencoded");

            HttpResponseMessage response = await req.SendAsync(msg);

            TwitAuthenticateResponse twitAuthResponse;
            using (response) {
                string objectText = await response.Content.ReadAsStringAsync();
                twitAuthResponse = JsonConvert.DeserializeObject<TwitAuthenticateResponse>(objectText);
                this.auth = twitAuthResponse;
            }

        }
    }

    public class TwitAuthenticateResponse {
        public string token_type { get; set; }
        public string access_token { get; set; }
    }
}
