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

    private void OnAddAfdelingClicked(object sender, EventArgs e)
    {
        string afdelingNavn = NavnEntry.Text;

        try
        {
            if (string.IsNullOrEmpty(afdelingNavn))
            {
                DisplayAlert("Fejl", "Alle felter skal udfyldes.", "OK");
                return;
            }

            var newAfdeling = new AfdelingDTO
            {
                Navn = afdelingNavn
            };


            _afdelingBLL.AddAfdeling(newAfdeling);
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
