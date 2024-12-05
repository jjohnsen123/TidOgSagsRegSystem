using BusinessLogic.BLL;
using DTO.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace MedarbejderMVCApp.Controllers
{
    public class TidsregistreringController : Controller
    {
        private MedarbejderBLL _medarbejderBLL = new MedarbejderBLL();
        private SagBLL _sagBLL = new SagBLL();

        // GET: Tidsregistrering/Create
        public ActionResult Create(int medarbejderId)
        {
            var medarbejder = _medarbejderBLL.GetMedarbejder(medarbejderId);
            ViewBag.Medarbejder = medarbejder;
            ViewBag.Sager = new SelectList(_sagBLL.GetAllSager(), "Id", "Overskrift");
            return View();
        }

        // POST: Tidsregistrering/Create
        [HttpPost]
        public ActionResult Create(TidsregistreringDTO tidsregistrering)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _medarbejderBLL.AddTidsregs(tidsregistrering.MedarbejderId, tidsregistrering);
                    return RedirectToAction("Details", "Medarbejder", new { id = tidsregistrering.MedarbejderId });
                }
                ViewBag.Sager = new SelectList(_sagBLL.GetAllSager(), "Id", "Overskrift", tidsregistrering.SagId);
                return View(tidsregistrering);
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                return View(tidsregistrering);
            }
        }
    }
}