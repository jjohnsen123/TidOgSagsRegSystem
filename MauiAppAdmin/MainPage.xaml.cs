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
            LoadMedarbAfd();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            LoadMedarbAfd();
        }

        private void LoadMedarbAfd()
        {
            try
            {
                var medarbejdere = _medarbejderBLL.GetAllMedarbejdere();
                var afdelinger = _afdelingBLL.GetAllAfdelinger();
                MedarbejderListView.ItemsSource = medarbejdere;
                AfdelingListView.ItemsSource = afdelinger;
            }
            catch (Exception ex)
            {
                DisplayAlert("Fejl", ex.Message, "OK");
            }
        }

        private void EditMedarbejderClicked(object sender, EventArgs e)
        {
            var medarbejder = (sender as Button)?.CommandParameter as DTO.Model.MedarbejderDTO;
            if (medarbejder != null)
            {
                Navigation.PushAsync(new EditMedarbejderPage(medarbejder));
            }
        }
        private async void DeleteMedarbejderClicked(object sender, EventArgs e)
        {
            var medarbejder = (sender as Button)?.CommandParameter as DTO.Model.MedarbejderDTO;
            if (medarbejder != null)
            {
                bool confirmDelete = await DisplayAlert("Bekræft Sletning", $"Er du sikker på, at du vil slette {medarbejder.Navn}?", "Ja", "Nej");
                if (confirmDelete)
                {
                    try
                    {
                        _medarbejderBLL.DeleteMedarbejder(medarbejder.Id);
                        LoadMedarbAfd(); // Opdater listen efter sletning
                    }
                    catch (Exception ex)
                    {
                        await DisplayAlert("Fejl", ex.Message, "OK");
                    }
                }
            }
        }

        private void AddMedarbejderClicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new AddMedarbejderPage());
        }

        private void AddAfdelingClicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new AddAfdelingPage());
        }

        private void EditAfdelingClicked(object sender, EventArgs e)
        {
            var afdeling = (sender as Button)?.CommandParameter as DTO.Model.AfdelingDTO;
            if (afdeling != null)
            {
                Navigation.PushAsync(new EditAfdelingPage(afdeling));
            }
        }
    }
}