using BusinessLogic.BLL;
using DTO.Model;

namespace MauiAppAdmin;

public partial class EditMedarbejderPage : ContentPage
{
    private MedarbejderBLL _medarbejderBLL = new MedarbejderBLL();
    private AfdelingBLL _afdelingBLL = new AfdelingBLL();
    private MedarbejderDTO _medarbejder;

    public EditMedarbejderPage(MedarbejderDTO medarbejder)
    {
        InitializeComponent();
        _medarbejder = medarbejder;

        LoadAfdelinger();
        LoadMedarbejderData();
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

    private void LoadMedarbejderData()
    {
        NavnEntry.Text = _medarbejder.Navn;
        InitialerEntry.Text = _medarbejder.Initialer;
        CprEntry.Text = _medarbejder.CprNr.ToString();

        // Sætter den valgte afdeling i Picker
        var valgtAfdeling = ((List<AfdelingDTO>)AfdelingPicker.ItemsSource).FirstOrDefault(a => a.Id == _medarbejder.AfdelingId);
        if (valgtAfdeling != null)
        {
            AfdelingPicker.SelectedItem = valgtAfdeling;
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

            if (!long.TryParse(CprEntry.Text, out long cprNummer))
            {
                DisplayAlert("Fejl", "CPR-nummer skal være et validt tal.", "OK");
                return;
            }

            var valgtAfdeling = (AfdelingDTO)AfdelingPicker.SelectedItem;

            // Opdaterer medarbejderens data
            _medarbejder.Navn = NavnEntry.Text;
            _medarbejder.Initialer = InitialerEntry.Text;
            _medarbejder.CprNr = cprNummer;
            _medarbejder.AfdelingId = valgtAfdeling.Id;

            _medarbejderBLL.EditMedarbejder(_medarbejder);
            Navigation.PopAsync();
        }
        catch (Exception ex)
        {
            DisplayAlert("Fejl", ex.Message, "OK");
        }
    }
}