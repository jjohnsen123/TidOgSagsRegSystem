using BusinessLogic.BLL;
using MedarbejderMVCApp.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace MedarbejderMVCApp.Controllers
{
    public class HomeController : Controller
    {
        private MedarbejderBLL _medarbejderBLL = new MedarbejderBLL();
        private AfdelingBLL _afdelingBLL = new AfdelingBLL();

        public ActionResult Index()
        {
            var medarbejdere = _medarbejderBLL.GetAllMedarbejdere();
            var afdelinger = _afdelingBLL.GetAllAfdelinger();
            foreach (var medarbejder in medarbejdere)
            {
                medarbejder.Afdeling = afdelinger.FirstOrDefault(a => a.Id == medarbejder.AfdelingId);
            }

            return View(medarbejdere);
        }

        public IActionResult CreateTidsregistrering(int medarbejderId)
        {
            return RedirectToAction("Create", "Tidsregistrering", new { medarbejderId = medarbejderId });
        }
    }
}