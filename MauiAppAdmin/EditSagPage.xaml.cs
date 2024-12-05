using BusinessLogic.BLL;
using DataAccess.Model;
using DTO.Model;

namespace MauiAppAdmin;

public partial class EditSagPage : ContentPage
{
    private SagBLL _sagBLL = new SagBLL();
    private AfdelingBLL _afdelingBLL = new AfdelingBLL();
    private SagDTO _sag;

    public EditSagPage(SagDTO sag)
    {
        InitializeComponent();
        _sag = sag;
        LoadAfdelinger();
        LoadSagData();
    }

    private void LoadAfdelinger()
    {
        var afdelinger = _afdelingBLL.GetAllAfdelinger();
        AfdelingPicker.ItemsSource = afdelinger;
        AfdelingPicker.ItemDisplayBinding = new Binding("Navn"); // Viser afdelingens navn
    }

    private void LoadSagData()
    {
        OverskriftEntry.Text = _sag.Overskrift;
        BeskrivelseEntry.Text = _sag.Beskrivelse;

        // Sætter den valgte afdeling i Picker
        var valgtAfdeling = ((List<AfdelingDTO>)AfdelingPicker.ItemsSource).FirstOrDefault(a => a.Id == _sag.AfdelingId);
        if (valgtAfdeling != null)
        {
            AfdelingPicker.SelectedItem = valgtAfdeling;
        }
    }

    private void OnSaveClicked(object sender, EventArgs e)
    {
        if (string.IsNullOrEmpty(OverskriftEntry.Text))
        {
            DisplayAlert("Fejl", "Overskriften skal udfyldes.", "OK");
            return;
        }

        var valgtAfdeling = (AfdelingDTO)AfdelingPicker.SelectedItem;

        _sag.Overskrift = OverskriftEntry.Text;
        _sag.Beskrivelse = BeskrivelseEntry.Text;
        _sag.AfdelingId = valgtAfdeling.Id;

        try
        {
            _sagBLL.EditSag(_sag);
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

