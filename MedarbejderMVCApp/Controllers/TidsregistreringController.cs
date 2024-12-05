using BusinessLogic.BLL;
using DTO.Model;
using MedarbejderMVCApp.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace MedarbejderMVCApp.Controllers
{
    public class TidsregistreringController : Controller
    {
        private SagBLL _sagBLL = new SagBLL();
        private MedarbejderBLL _medarbejderBLL = new MedarbejderBLL();

        [HttpGet]
        public IActionResult CreateTidsregistrering(int medarbejderId)
        {
            // Hent medarbejderen
            var medarbejder = _medarbejderBLL.GetMedarbejder(medarbejderId);

            // Opret en ViewModel for at inkludere både medarbejderinfo og sager
            var sager = _sagBLL.GetAllSager();

            var viewModel = new CreateTidsregistreringViewModel
            {
                Medarbejder = medarbejder,
                Sager = sager,
                Tidsregistrering = new TidsregistreringDTO { MedarbejderId = medarbejderId }
            };

            return View(viewModel);
        }

        [HttpPost]
        public IActionResult CreateTidsregistrering(CreateTidsregistreringViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                _medarbejderBLL.AddTidsregs(viewModel.Tidsregistrering.MedarbejderId, viewModel.Tidsregistrering);
                return RedirectToAction("Index", "Home");
            }
            return View(viewModel);
        }
    }
}
