namespace MyApp;

public partial class Login : ContentPage
{
    private readonly HttpClient client = new HttpClient();
    public Login()
	{
		InitializeComponent();
	}

    private async void OnLoginClicked(object sender, EventArgs e)
    {
        string name = UsernameEntry.Text;
        string password = PasswordEntry.Text;

        if (string.IsNullOrWhiteSpace(name) ||
            string.IsNullOrWhiteSpace(password))
        {
            await DisplayAlert("Error", "Please enter username and password", "OK");
            return; 
        }

        string url =
            $"http://localhost:5263/login?name={Uri.EscapeDataString(name)}&password={Uri.EscapeDataString(password)}";

        try
        {
            HttpResponseMessage response = await client.GetAsync(url);

            string result = await response.Content.ReadAsStringAsync();

            if (response.IsSuccessStatusCode)
            {
                await DisplayAlert("Success", "You have logged in successfully!", "OK");
                await Navigation.PushAsync(new MainPage());
            }
            else
            {
                await DisplayAlert("Error", result, "OK");
            }
        }
        catch (Exception ex)
        {
            await DisplayAlert("Error", ex.Message, "OK");
        }
    }

    private async void ReturnMain(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new MainPage());
    }
    }