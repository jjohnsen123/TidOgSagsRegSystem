using DTO.Model;

namespace MedarbejderMVCApp.ViewModels
{
    public class CreateTidsregistreringViewModel
    {
        public MedarbejderDTO Medarbejder { get; set; }
        public List<SagDTO> Sager { get; set; }
        public TidsregistreringDTO Tidsregistrering { get; set; }
    }
}
