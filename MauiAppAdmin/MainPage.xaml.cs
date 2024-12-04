using BusinessLogic.BLL;

namespace MauiAppAdmin
{
    public partial class MainPage : ContentPage
    {
        private MedarbejderBLL _medarbejderBLL = new MedarbejderBLL();
        private AfdelingBLL _afdelingBLL = new AfdelingBLL();

        public MainPage()
        {
            InitializeComponent();
            LoadMedarbejdere();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            LoadMedarbejdere();
        }

        private void LoadMedarbejdere()
        {
            try
            {
                var medarbejdere = _medarbejderBLL.GetAllMedarbejdere();
                var afdelinger = _afdelingBLL.GetAllAfdelinger();
                MedarbejderListView.ItemsSource = medarbejdere;
            }
            catch (Exception ex)
            {
                DisplayAlert("Fejl", ex.Message, "OK");
            }
        }

        private void AddMedarbejderClicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new AddMedarbejderPage());
        }

        private void EditMedarbejderClicked(object sender, EventArgs e)
        {
            var medarbejder = (sender as Button)?.CommandParameter as DTO.Model.MedarbejderDTO;
            if (medarbejder != null)
            {
                // Navigation.PushAsync(new EditMedarbejderPage(medarbejder));
            }
        }

        private void AddAfdelingClicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new AddAfdelingPage());
        }
    }
}