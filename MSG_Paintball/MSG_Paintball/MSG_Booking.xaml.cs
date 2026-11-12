
using System.Net.Http;
using System.Text;
using System.Text.Json;
using Microsoft.Maui.Storage;

namespace MSG_Paintball;

public partial class MSG_Booking : ContentPage
{
    private static readonly HttpClient client = new HttpClient();

    private const string ApiUrl =
        "http://10.0.2.2/MSGPaintball/MSG/api/booking.php";

    public MSG_Booking()
    {
        InitializeComponent();

        BookingDatePicker.MinimumDate = DateTime.Today;
        BookingDatePicker.Date = DateTime.Today;
    }

    private async void BookingButton_Clicked(object sender, EventArgs e)
    {
        string playerID = Preferences.Get("Player_ID", "");

        string time = TimePicker.SelectedItem?.ToString() ?? "";
        string gameType = GameTypePicker.SelectedItem?.ToString() ?? "";
        string location = LocationPicker.SelectedItem?.ToString() ?? "";
        string date = BookingDatePicker.Date.ToString("yyyy-MM-dd");

        if (playerID == "")
        {
            MessageLabel.Text = "Please log in before making a booking.";
            return;
        }

        if (time == "" || gameType == "" || location == "")
        {
            MessageLabel.Text = "Please complete all booking fields.";
            return;
        }

        BookingButton.IsEnabled = false;
        LoadingIndicator.IsVisible = true;
        LoadingIndicator.IsRunning = true;
        MessageLabel.Text = "";

        try
        {
            var bookingData = new
            {
                player_id = playerID,
                time = time,
                game_type = gameType,
                date = date,
                location = location
            };

            string json = JsonSerializer.Serialize(bookingData);

            var content = new StringContent(
                json,
                Encoding.UTF8,
                "application/json"
            );

            HttpResponseMessage response =
                await client.PostAsync(ApiUrl, content);

            string result = await response.Content.ReadAsStringAsync();

            using JsonDocument document = JsonDocument.Parse(result);

            JsonElement root = document.RootElement;

            bool success = root.GetProperty("success").GetBoolean();

            string message = root.TryGetProperty(
                "message",
                out JsonElement messageElement)
                    ? messageElement.GetString() ?? ""
                    : "Booking request completed.";

            if (success)
            {
                await DisplayAlert(
                    "Booking Successful",
                    message,
                    "Continue"
                );

                await Navigation.PopAsync();
            }
            else
            {
                MessageLabel.Text = message;
            }
        }
        catch (HttpRequestException)
        {
            MessageLabel.Text =
                "Cannot connect to the PHP server. Check XAMPP.";
        }
        catch (JsonException)
        {
            MessageLabel.Text =
                "The PHP server returned an invalid response.";
        }
        catch (Exception ex)
        {
            MessageLabel.Text = "Error: " + ex.Message;
        }
        finally
        {
            LoadingIndicator.IsRunning = false;
            LoadingIndicator.IsVisible = false;
            BookingButton.IsEnabled = true;
        }
    }
}
