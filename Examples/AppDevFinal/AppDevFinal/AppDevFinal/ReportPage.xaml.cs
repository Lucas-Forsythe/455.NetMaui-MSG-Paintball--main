using System.Text.Json;

namespace AppDevFinal;

public partial class ReportPage : ContentPage
{
    public ReportPage()
    {
        InitializeComponent();
        LoadData();
    }

    private async void LoadData()
    {
        try
        {
            var client = new HttpClient();
            string baseUrl;

            if (DeviceInfo.Platform == DevicePlatform.Android)
                baseUrl = "http://10.0.2.2/CITA355/CITA-355-Final-Project/CITA_355_PROJECT_ONE/";
            else
                baseUrl = "http://localhost/CITA355/CITA-355-Final-Project/CITA_355_PROJECT_ONE/";

            string url = baseUrl + "resultsdatabase.php";

            var json = await client.GetStringAsync(url);
            var data = JsonSerializer.Deserialize<List<Dictionary<string, string>>>(json);
            var displayList = new List<string>();

            foreach (var item in data)
            {
                displayList.Add(
                    $"Student ID: {item["Student_Id"]}\n" +
                    $"Score: {item["Score"]}\n" +
                    $"Date: {item["Date"]}\n" +
                    $"Time: {item["Time"]}\n"
                );
            }

            ResultsView.ItemsSource = displayList;
        }
        catch (Exception ex)
        {
            await DisplayAlert("Error", ex.Message, "OK");
        }
    }
}