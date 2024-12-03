using BusinessLogic.BLL;

namespace MauiGUI
{
    public partial class MainPage : ContentPage
    {
        private MedarbejderBLL _medarbejderBLL = new MedarbejderBLL();

        public MainPage()
        {
            InitializeComponent();
            LoadMedarbejdere();
        }

        private void LoadMedarbejdere()
        {
            try
            {
                var medarbejdere = _medarbejderBLL.GetAllMedarbejdere();
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
    }
}