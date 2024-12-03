using DataAccess.Repositories;
using DTO.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.BLL
{
    public class AfdelingBLL
    {
        public AfdelingDTO GetAfdeling(int afdNr)
        {
            try
            {
                return AfdelingRepository.GetAfdeling(afdNr);
            }
            catch (KeyNotFoundException ex)
            {
                // Håndter undtagelsen, f.eks. log fejl eller returnér en brugervenlig besked
                throw new KeyNotFoundException($"Kunne ikke finde afdelingen: {ex.Message}");
            }
        }

        public void AddAfdeling(AfdelingDTO afdeling)
        {
            // Tilføj forretningslogik: valider afdelingens data før tilføjelse
            if (string.IsNullOrEmpty(afdeling.Navn))
            {
                throw new ArgumentException("Afdelingens navn skal udfyldes.");
            }

            AfdelingRepository.AddAfdeling(afdeling);
        }

        public void EditAfdeling(AfdelingDTO afdeling)
        {
            // Valider at nødvendige data er til stede
            if (string.IsNullOrEmpty(afdeling.Navn))
            {
                throw new ArgumentException("Afdelingens navn skal udfyldes.");
            }

            try
            {
                AfdelingRepository.EditAfdeling(afdeling);
            }
            catch (KeyNotFoundException ex)
            {
                throw new KeyNotFoundException($"Kunne ikke finde afdelingen: {ex.Message}");
            }
        }

        public void DeleteAfdeling(int afdNr)
        {
            try
            {
                AfdelingRepository.DeleteAfdeling(afdNr);
            }
            catch (KeyNotFoundException ex)
            {
                // Behandle undtagelsen, hvis afdelingen ikke findes
                throw new KeyNotFoundException($"Kunne ikke finde afdelingen: {ex.Message}");
            }
        }

        public List<AfdelingDTO> GetAllAfdelinger()
        {
            return AfdelingRepository.GetAllAfdelinger();
        }
    }
}
