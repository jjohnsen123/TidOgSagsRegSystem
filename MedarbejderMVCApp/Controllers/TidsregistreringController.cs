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
            var medarbejder = _medarbejderBLL.GetMedarbejder(medarbejderId);
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
            var tidreg = new TidsregistreringDTO(viewModel.Tidsregistrering.MedarbejderId, viewModel.Tidsregistrering.SagId,
            viewModel.Tidsregistrering.StartTid, viewModel.Tidsregistrering.SlutTid);

            _medarbejderBLL.AddTidsregs(tidreg.MedarbejderId, tidreg);
            return RedirectToAction("Index", "Home");
        }
    }
}
