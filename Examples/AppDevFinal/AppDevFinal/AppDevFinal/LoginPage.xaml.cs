using AppDevFinal.Model;
using System.Text.Json;
using System.Text;

namespace AppDevFinal;

public partial class LoginPage : ContentPage
{
	public LoginPage()
	{
		InitializeComponent();
	}

    private async void OnLoginClicked(object sender, EventArgs e)
    {
        var client = new HttpClient();

        var loginData = new
        {
            STUDENTID = idEntry.Text,
            PASSWORD = passwordEntry.Text
        };

        var json = JsonSerializer.Serialize(loginData);
        var content = new StringContent(json, Encoding.UTF8, "application/json");

        string baseUrl;

        if (DeviceInfo.Platform == DevicePlatform.Android)
        {
            baseUrl = "http://10.0.2.2/CITA355/CITA-355-Final-Project/CITA_355_PROJECT_ONE/";
        }
        else if (DeviceInfo.Platform == DevicePlatform.WinUI)
        {
            baseUrl = "http://localhost/CITA355/CITA-355-Final-Project/CITA_355_PROJECT_ONE/";
        }
        else
        {
            baseUrl = "http://192.168.X.X/CITA355/CITA-355-Final-Project/CITA_355_PROJECT_ONE/";
        }

        string url = baseUrl + "mauiLogin.php";

        var response = await client.PostAsync(url, content);
        var result = await response.Content.ReadAsStringAsync();

        var loginResponse = JsonSerializer.Deserialize<LoginResponse>(result);


        if (loginResponse.status == "success")
        {
            await Navigation.PushAsync(new HomePage(loginResponse.student));
        }
        else
        {
            await DisplayAlert("Login Failed", loginResponse.message, "OK");
        }
    }
}