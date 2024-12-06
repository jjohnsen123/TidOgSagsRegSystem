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
            try
            {
                // Validering af Start- og SlutTid
                if (viewModel.Tidsregistrering.StartTid == default || viewModel.Tidsregistrering.SlutTid == default)
                {
                    ModelState.AddModelError(string.Empty, "Starttid og sluttid skal udfyldes.");
                    viewModel = LoadCreateTidsregistreringViewModel(viewModel.Tidsregistrering.MedarbejderId);
                    return View(viewModel);
                }

                if (viewModel.Tidsregistrering.StartTid >= viewModel.Tidsregistrering.SlutTid)
                {
                    ModelState.AddModelError(string.Empty, "Starttid skal være før sluttid.");
                    viewModel = LoadCreateTidsregistreringViewModel(viewModel.Tidsregistrering.MedarbejderId);
                    return View(viewModel);
                }

                int? sagId = string.IsNullOrEmpty(viewModel.Tidsregistrering.SagId.ToString()) ? (int?)null : viewModel.Tidsregistrering.SagId;

                var tidreg = new TidsregistreringDTO(viewModel.Tidsregistrering.MedarbejderId, sagId,
                    viewModel.Tidsregistrering.StartTid, viewModel.Tidsregistrering.SlutTid);

                _medarbejderBLL.AddTidsregs(tidreg.MedarbejderId, tidreg);
                return RedirectToAction("Index", "Home");
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, $"Der opstod en fejl: {ex.Message}");
                viewModel = LoadCreateTidsregistreringViewModel(viewModel.Tidsregistrering.MedarbejderId);
                return View(viewModel);
            }
        }

        // Henter nødvendig data og opretter ViewModel til Exception Handling.
        private CreateTidsregistreringViewModel LoadCreateTidsregistreringViewModel(int medarbejderId)
        {
            var medarbejder = _medarbejderBLL.GetMedarbejder(medarbejderId);
            var sager = _sagBLL.GetAllSager();

            return new CreateTidsregistreringViewModel
            {
                Medarbejder = medarbejder,
                Sager = sager ?? new List<SagDTO>(),
                Tidsregistrering = new TidsregistreringDTO { MedarbejderId = medarbejderId }
            };
        }
    }
}
