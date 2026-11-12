namespace AppDevFinal
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private async void Login(object sender, EventArgs e)
        {
            string id = idEntry.Text;
            string password = passwordEntry.Text;

            using HttpClient client = new HttpClient();

            var values = new Dictionary<string, string>
    {
        { "user_id", id },
        { "user_password", password }
    };

            var content = new FormUrlEncodedContent(values);

            // CHANGE THIS to your real server URL
            string url = "http://localhost/CITA355/CITA-355-Final-Project/CITA_355_PROJECT_ONE/mauiLogin.php";

            var response = await client.PostAsync(url, content);
            string result = await response.Content.ReadAsStringAsync();

            await DisplayAlert("Server Response", result, "OK");
        }

    }
}
