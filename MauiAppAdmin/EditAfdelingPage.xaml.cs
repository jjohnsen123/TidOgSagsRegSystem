using BusinessLogic.BLL;
using DTO.Model;

namespace MauiAppAdmin;

public partial class EditAfdelingPage : ContentPage
{
    private AfdelingBLL _afdelingBLL = new AfdelingBLL();
    private AfdelingDTO _afdeling;

    public EditAfdelingPage(AfdelingDTO afdeling)
    {
        InitializeComponent();
        _afdeling = afdeling;
        LoadAfdelingData();
    }

    private void LoadAfdelingData()
    {
        NavnEntry.Text = _afdeling.Navn;
    }

    private async void OnSaveClicked(object sender, EventArgs e)
    {
        try
        {
            if (string.IsNullOrEmpty(NavnEntry.Text))
            {
                await DisplayAlert("Fejl", "Afdelingens navn skal udfyldes.", "OK");
                return;
            }

            _afdeling.Navn = NavnEntry.Text;

            _afdelingBLL.EditAfdeling(_afdeling);

            await Navigation.PopAsync();
        }
        catch (Exception ex)
        {
            await DisplayAlert("Fejl", ex.Message, "OK");
        }
    }
    private void OnCancelClicked(object sender, EventArgs e)
    {
        Navigation.PopAsync();
    }
}