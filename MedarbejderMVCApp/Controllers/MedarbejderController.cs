using BusinessLogic.BLL;
using Microsoft.AspNetCore.Mvc;

namespace MedarbejderMVCApp.Controllers
{
    public class MedarbejderController : Controller
    {
        private MedarbejderBLL _medarbejderBLL = new MedarbejderBLL();

        // GET: Medarbejder
        public ActionResult Index()
        {
            var medarbejdere = _medarbejderBLL.GetAllMedarbejdere();
            return View(medarbejdere);
        }

        // GET: Medarbejder/Details/5
        public ActionResult Details(int id)
        {
            var medarbejder = _medarbejderBLL.GetMedarbejder(id);
            var tidsregistreringer = _medarbejderBLL.GetAllTidRegInMedarb(id);
            ViewBag.Tidsregistreringer = tidsregistreringer;
            return View(medarbejder);
        }
    }
}
