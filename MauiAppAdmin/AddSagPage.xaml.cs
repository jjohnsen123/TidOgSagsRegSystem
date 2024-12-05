using BusinessLogic.BLL;
using DTO.Model;

namespace MauiAppAdmin;

public partial class AddSagPage : ContentPage
{
    private SagBLL _sagBLL = new SagBLL();
    private AfdelingBLL _afdelingBLL = new AfdelingBLL();

    public AddSagPage()
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

    private void OnSaveClicked(object sender, EventArgs e)
    {
        try
        {
            if (string.IsNullOrEmpty(OverskriftEntry.Text) || string.IsNullOrEmpty(BeskrivelseEditor.Text))
            {
                DisplayAlert("Fejl", "Overskrift og Beskrivelse skal udfyldes.", "OK");
                return;
            }

            var valgtAfdeling = (AfdelingDTO)AfdelingPicker.SelectedItem;

            // Skaber en ny SagDTO og bruger valgt afdelingens Id
            var sag = new SagDTO(OverskriftEntry.Text, BeskrivelseEditor.Text, valgtAfdeling.Id);

            _sagBLL.AddSag(sag);

            // Naviger tilbage efter gem
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