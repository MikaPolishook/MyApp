namespace MyApp
{
    public partial class MainPage : ContentPage
    {
        int count = 0;

        public MainPage()
        {
            InitializeComponent();
        }

        private async void SignUpPage(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Signup());
        }

        private async void LogInPage(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Login());
        }


    }
}
