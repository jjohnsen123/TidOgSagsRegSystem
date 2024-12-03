using BusinessLogic.BLL;

namespace MauiApp;

public partial class TidsregistreringPage : ContentPage
{
    private MedarbejderBLL _medarbejderBLL = new MedarbejderBLL();
    private string _medarbejderInitialer;

    public TidsregistreringPage(string initialer)
    {
        InitializeComponent();
        _medarbejderInitialer = initialer;
        LoadTidsregistreringer();
    }

    private void LoadTidsregistreringer()
    {
        try
        {
            var tidsregistreringer = _medarbejderBLL.GetAllTidRegInMedarb(_medarbejderInitialer);
            TidsregListView.ItemsSource = tidsregistreringer;
        }
        catch (Exception ex)
        {
            DisplayAlert("Fejl", ex.Message, "OK");
        }
    }

    //private async void AddTidsregClicked(object sender, EventArgs e)
    //{
    //    await Navigation.PushAsync(new AddTidsregistreringPage(_medarbejderInitialer));
    //}
}

