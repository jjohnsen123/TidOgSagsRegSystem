using BusinessLogic.BLL;
using DTO.Model;

namespace MauiAppAdmin;

public partial class AddMedarbejderPage : ContentPage
{
    private MedarbejderBLL _medarbejderBLL = new MedarbejderBLL();
    private AfdelingBLL _afdelingBLL = new AfdelingBLL();


    public AddMedarbejderPage()
    {
        InitializeComponent();
        LoadAfdelinger();
    }

    private void LoadAfdelinger()
    {
        try
        {
            var afdelinger = _afdelingBLL.GetAllAfdelinger();
            AfdelingPicker.ItemsSource = afdelinger;
            AfdelingPicker.ItemDisplayBinding = new Binding("Navn"); // Viser afdelingens navn i picker
        }
        catch (Exception ex)
        {
            DisplayAlert("Fejl", ex.Message, "OK");
        }
    }

    private async void OnSaveClicked(object sender, EventArgs e)
    {
        try
        {
            if (string.IsNullOrEmpty(NavnEntry.Text) ||
                string.IsNullOrEmpty(InitialerEntry.Text) ||
                string.IsNullOrEmpty(CprEntry.Text) ||
                AfdelingPicker.SelectedItem == null)
            {
                await DisplayAlert("Fejl", "Alle felter skal udfyldes.", "OK");
                return;
            }

            if (!long.TryParse(CprEntry.Text, out long cprNummer) || CprEntry.Text.Length != 10)
            {
                await DisplayAlert("Fejl", "CPR-nummer skal være 10 cifre.", "OK");
                return;
            }

            var valgtAfdeling = (AfdelingDTO)AfdelingPicker.SelectedItem;

            var medarbejder = new MedarbejderDTO((int)cprNummer, InitialerEntry.Text, NavnEntry.Text, valgtAfdeling);

            _medarbejderBLL.AddMedarbejder(medarbejder);
            await Navigation.PopAsync();
        }
        catch (Exception ex)
        {
            await DisplayAlert("Fejl", ex.Message, "OK");
        }
    }
}
