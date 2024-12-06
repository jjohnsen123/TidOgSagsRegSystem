using BusinessLogic.BLL;
using DTO.Model;

namespace MauiAppAdmin;

public partial class MedarbejderDetailPage : ContentPage
{
    private MedarbejderBLL _medarbejderBLL = new MedarbejderBLL();
    private AfdelingBLL _afdelingBLL = new AfdelingBLL();
    private int _medarbejderId;

    public MedarbejderDetailPage(MedarbejderDTO medarbejder)
    {
        InitializeComponent();
        _medarbejderId = medarbejder.Id;
        LoadMedarbejderDetails(medarbejder);
        LoadTidsregistreringer(_medarbejderId);
    }

    private void LoadMedarbejderDetails(MedarbejderDTO medarbejder)
    {
        NavnLabel.Text = medarbejder.Navn;
        InitialerLabel.Text = medarbejder.Initialer;
        CprLabel.Text = medarbejder.CprNr.ToString();
        AfdelingLabel.Text = _afdelingBLL.GetAfdeling(medarbejder.AfdelingId).Navn;
    }

    private void LoadTidsregistreringer(int medarbId)
    {
        try
        {
            // Henter alle tidsregristreringer med matchende medarbejderId
            var tidsregistreringer = _medarbejderBLL.GetAllTidReg()
                .Where(tr => tr.MedarbejderId == medarbId);


            // Beregn ugentlige tidsregistreringer
            var thisWeek = DateTime.Now.StartOfWeek(DayOfWeek.Monday);
            var weeklyRegistrations = tidsregistreringer
                .Where(tr => tr.StartTid >= thisWeek && tr.StartTid < thisWeek.AddDays(7))
                .ToList();
            WeeklyRegistrationsList.ItemsSource = weeklyRegistrations;

            // Beregn månedlige tidsregistreringer
            var thisMonth = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
            var monthlyRegistrations = tidsregistreringer
                .Where(tr => tr.StartTid >= thisMonth && tr.StartTid < thisMonth.AddMonths(1))
                .ToList();
            MonthlyRegistrationsList.ItemsSource = monthlyRegistrations;

            // Beregn total tid
            TimeSpan totalTid = TimeSpan.Zero;
            foreach (var tr in tidsregistreringer)
            {
                totalTid += tr.SlutTid - tr.StartTid;
            }
            TotalTimeLabel.Text = $"Total tid: {totalTid.TotalHours} timer";

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

public static class DateTimeExtension
{
    public static DateTime StartOfWeek(this DateTime dt, DayOfWeek startOfWeek)
    {
        int diff = (7 + (dt.DayOfWeek - startOfWeek)) % 7;
        return dt.AddDays(-1 * diff).Date;
    }
}