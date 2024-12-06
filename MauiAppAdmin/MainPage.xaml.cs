using BusinessLogic.BLL;
using DTO.Model;

namespace MauiAppAdmin
{
    public partial class MainPage : ContentPage
    {
        private MedarbejderBLL _medarbejderBLL = new MedarbejderBLL();
        private AfdelingBLL _afdelingBLL = new AfdelingBLL();
        private SagBLL _sagBLL = new SagBLL();

        public MainPage()
        {
            InitializeComponent();
            LoadMedarbAfdSag();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            LoadMedarbAfdSag();
        }

        // Henter data fra Medarbejder, Afdelinger og Sager og sørger for at listviews kan opdateres
        private void LoadMedarbAfdSag()
        {
            try
            {
                var medarbejdere = _medarbejderBLL.GetAllMedarbejdere();
                var afdelinger = _afdelingBLL.GetAllAfdelinger();
                var sager = _sagBLL.GetAllSager();
                MedarbejderListView.ItemsSource = medarbejdere;
                AfdelingListView.ItemsSource = afdelinger;
                SagListView.ItemsSource = sager;
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
            var medarbejder = (sender as Button)?.CommandParameter as MedarbejderDTO;
            if (medarbejder != null)
            {
                Navigation.PushAsync(new EditMedarbejderPage(medarbejder));
            }
        }

        private void ViewDetailsClicked(object sender, EventArgs e)
        {
            var medarbejder = (sender as Button)?.CommandParameter as MedarbejderDTO;
            if (medarbejder != null)
            {
                Navigation.PushAsync(new MedarbejderDetailPage(medarbejder));
            }
        }


        private async void DeleteMedarbejderClicked(object sender, EventArgs e)
        {
            var medarbejder = (sender as Button)?.CommandParameter as MedarbejderDTO;
            if (medarbejder != null)
            {
                bool confirmDelete = await DisplayAlert("Bekræft Sletning", $"Er du sikker på, at du vil slette {medarbejder.Navn}?", "Ja", "Nej");
                if (confirmDelete)
                {
                    try
                    {
                        _medarbejderBLL.DeleteMedarbejder(medarbejder.Id);
                        LoadMedarbAfdSag();
                    }
                    catch (Exception ex)
                    {
                        await DisplayAlert("Fejl", ex.Message, "OK");
                    }
                }
            }
        }

        private void AddAfdelingClicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new AddAfdelingPage());
        }

        private void EditAfdelingClicked(object sender, EventArgs e)
        {
            var afdeling = (sender as Button)?.CommandParameter as AfdelingDTO;
            if (afdeling != null)
            {
                Navigation.PushAsync(new EditAfdelingPage(afdeling));
            }
        }

        private async void DeleteAfdelingClicked(object sender, EventArgs e)
        {
            var afdeling = (sender as Button)?.CommandParameter as AfdelingDTO;
            if (afdeling != null)
            {
                bool confirmDelete = await DisplayAlert("Bekræft Sletning", $"Er du sikker på, at du vil slette {afdeling.Navn}?", "Ja", "Nej");
                if (confirmDelete)
                {
                    try
                    {
                        _afdelingBLL.DeleteAfdeling(afdeling.Id);
                        LoadMedarbAfdSag();
                    }
                    catch (Exception ex)
                    {
                        await DisplayAlert("Fejl", ex.Message, "OK");
                    }
                }
            }
        }
        private void AddSagClicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new AddSagPage());
        }

        private void EditSagClicked(object sender, EventArgs e)
        {
            var sag = (sender as Button)?.CommandParameter as SagDTO;
            if (sag != null)
            {
                Navigation.PushAsync(new EditSagPage(sag));
            }
        }

        private async void DeleteSagClicked(object sender, EventArgs e)
        {
            var sag = (sender as Button)?.CommandParameter as SagDTO;
            if (sag != null)
            {
                var confirmed = await DisplayAlert("Bekræftelse", "Er du sikker på, at du vil slette denne sag?", "Ja", "Nej");
                if (confirmed)
                {
                    try
                    {
                        _sagBLL.DeleteSag(sag.Id);
                        LoadMedarbAfdSag();
                    }
                    catch (Exception ex)
                    {
                        await DisplayAlert("Fejl", ex.Message, "OK");
                    }
                }
            }
        }
    }
}