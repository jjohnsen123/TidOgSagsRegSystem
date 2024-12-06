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
            AfdelingPicker.ItemDisplayBinding = new Binding("Navn");
        }
        catch (Exception ex)
        {
            DisplayAlert("Fejl", ex.Message, "OK");
        }
    }

    private void OnSaveClicked(object sender, EventArgs e)
    {
        try
        {
            if (string.IsNullOrEmpty(NavnEntry.Text) ||
                string.IsNullOrEmpty(InitialerEntry.Text) ||
                string.IsNullOrEmpty(CprEntry.Text) ||
                AfdelingPicker.SelectedItem == null)
            {
                DisplayAlert("Fejl", "Alle felter skal udfyldes.", "OK");
                return;
            }

            if (!long.TryParse(CprEntry.Text, out long cprNummer) || CprEntry.Text.Length != 10)
            {
                DisplayAlert("Fejl", "CPR-nummer skal være 10 cifre.", "OK");
                return;
            }

            var valgtAfdeling = (AfdelingDTO)AfdelingPicker.SelectedItem;

            var medarbejder = new MedarbejderDTO(cprNummer, InitialerEntry.Text, NavnEntry.Text, valgtAfdeling.Id);

            _medarbejderBLL.AddMedarbejder(medarbejder);
            Navigation.PopAsync();
        }
        catch (Exception ex)
        {
            DisplayAlert("Fejl", ex.Message, "OK");
        }
    }

    private void OnCancelClicked(object sender, EventArgs e)
    {
        Navigation.PopAsync();
    }
}
