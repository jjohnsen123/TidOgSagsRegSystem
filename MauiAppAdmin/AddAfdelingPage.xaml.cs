using BusinessLogic.BLL;
using DataAccess.Model;
using DTO.Model;

namespace MauiAppAdmin;

public partial class AddAfdelingPage : ContentPage
{
    private AfdelingBLL _afdelingBLL;

    public AddAfdelingPage()
    {
        InitializeComponent();
        _afdelingBLL = new AfdelingBLL();
    }

    private async void OnAddAfdelingClicked(object sender, EventArgs e)
    {
        string afdelingNavn = NavnEntry.Text;

        if (string.IsNullOrEmpty(afdelingNavn))
        {
            ResultLabel.Text = "Afdelingens navn må ikke være tomt.";
            return;
        }

        var newAfdeling = new AfdelingDTO
        {
            Navn = afdelingNavn
        };

        try
        {
            _afdelingBLL.AddAfdeling(newAfdeling);
            ResultLabel.TextColor = Colors.Green;
            ResultLabel.Text = "Afdelingen blev tilføjet succesfuldt.";
        }
        catch (Exception ex)
        {
            ResultLabel.TextColor = Colors.Red;
            ResultLabel.Text = $"Fejl ved tilføjelse af afdeling: {ex.Message}";
        }

        await Navigation.PopAsync();
    }
    private void OnCancelClicked(object sender, EventArgs e)
    {
        Navigation.PopAsync();
    }
}
