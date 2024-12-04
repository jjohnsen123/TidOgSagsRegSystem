using BusinessLogic.BLL;

namespace MauiAppAdmin;

public partial class TidsregistreringPage : ContentPage
{
    private MedarbejderBLL _medarbejderBLL = new MedarbejderBLL();
    private int _medarbejderId;

    public TidsregistreringPage(int id)
    {
        InitializeComponent();
        _medarbejderId = id;
        LoadTidsregistreringer();
    }

    private void LoadTidsregistreringer()
    {
        try
        {
            var tidsregistreringer = _medarbejderBLL.GetAllTidRegInMedarb(_medarbejderId);
            TidsregListView.ItemsSource = tidsregistreringer;
        }
        catch (Exception ex)
        {
            DisplayAlert("Fejl", ex.Message, "OK");
        }
    }

    private void AddTidsregClicked(object sender, EventArgs e)
    {
        Navigation.PushAsync(new TidsregistreringPage(_medarbejderId));
    }
}

