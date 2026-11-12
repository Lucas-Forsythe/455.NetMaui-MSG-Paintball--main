namespace msg_MAUI2;

public partial class MSG_Login : ContentPage
{
	public MSG_Login()
	{
		InitializeComponent();
    }


    private async void OnLoginClicked(object sender, EventArgs e)
	{
		await Shell.Current.GoToAsync(nameof(MainPage));

	}
}
