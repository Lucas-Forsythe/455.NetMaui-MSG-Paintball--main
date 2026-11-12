
using System.Net.Http;
using System.Text;
using System.Text.Json;
using Microsoft.Maui.Storage;

namespace MSG_Paintball;

public partial class MSG_Login : ContentPage
{
    private static readonly HttpClient client = new HttpClient();

    // Android emulator address for your XAMPP website
    private const string ApiUrl = "http://10.0.2.2/MSG/api/login.php";

    public MSG_Login()
    {
        InitializeComponent();
    }

    private async void LoginButton_Clicked(object sender, EventArgs e)
    {
        string email = EmailEntry.Text?.Trim() ?? "";
        string password = PasswordEntry.Text ?? "";

        if (email == "" || password == "")
        {
            MessageLabel.Text = "Please enter your email and password.";
            return;
        }

        LoginButton.IsEnabled = false;
        LoadingIndicator.IsVisible = true;
        LoadingIndicator.IsRunning = true;
        MessageLabel.Text = "";

        try
        {
            var loginData = new
            {
                email = email,
                password = password
            };

            string json = JsonSerializer.Serialize(loginData);

            var content = new StringContent(
                json,
                Encoding.UTF8,
                "application/json"
            );

            HttpResponseMessage response = await client.PostAsync(ApiUrl, content);

            string result = await response.Content.ReadAsStringAsync();

            using JsonDocument document = JsonDocument.Parse(result);

            JsonElement root = document.RootElement;

            bool success = root.GetProperty("success").GetBoolean();

            if (success)
            {
                JsonElement player = root.GetProperty("player");

                string playerId = player.GetProperty("player_id").ToString();
                string firstName = player.GetProperty("first_name").GetString() ?? "";
                string lastName = player.GetProperty("last_name").GetString() ?? "";
                string playerEmail = player.GetProperty("email").GetString() ?? "";

                // Save player information for other MAUI pages
                Preferences.Set("Player_ID", playerId);
                Preferences.Set("First_Name", firstName);
                Preferences.Set("Last_Name", lastName);
                Preferences.Set("Player_Email", playerEmail);
                Preferences.Set("IsLoggedIn", true);

                await DisplayAlert(
                    "Login Successful",
                    "Welcome " + firstName + " " + lastName + "!",
                    "Continue"
                );

                // Navigate to your home page
                await DisplayAlert("Welcome", "You are logged in!", "OK");
            }
            else
            {
                string message = root.TryGetProperty("message", out JsonElement error)
                    ? error.GetString() ?? "Login failed."
                    : "Login failed.";

                MessageLabel.Text = message;
            }
        }
        catch (HttpRequestException)
        {
            MessageLabel.Text = "Cannot connect to the PHP server. Check XAMPP.";
        }
        catch (JsonException)
        {
            MessageLabel.Text = "The PHP server returned an invalid response.";
        }
        catch (Exception ex)
        {
            MessageLabel.Text = "Error: " + ex.Message;
        }
        finally
        {
            LoadingIndicator.IsRunning = false;
            LoadingIndicator.IsVisible = false;
            LoginButton.IsEnabled = true;
        }
    }
}
