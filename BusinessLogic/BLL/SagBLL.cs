using DataAccess.Repositories;
using DTO.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.BLL
{
    public class SagBLL
    {
        public SagDTO GetSag(int sagsNr)
        {
            try
            {
                return SagRepository.GetSag(sagsNr);
            }
            catch (KeyNotFoundException ex)
            {
                // Håndter undtagelsen ved at kaste en mere brugervenlig besked
                throw new KeyNotFoundException($"Kunne ikke finde sagen: {ex.Message}");
            }
        }

        public void AddSag(SagDTO sag)
        {
            // Tilføj forretningslogik: Valider at nødvendige data er udfyldt
            if (string.IsNullOrEmpty(sag.Overskrift))
            {
                throw new ArgumentException("Sagens overskrift skal udfyldes.");
            }

            SagRepository.AddSag(sag);
        }

        public void EditSag(SagDTO sag)
        {
            // Valider at sagens nødvendige data er udfyldt
            if (string.IsNullOrEmpty(sag.Overskrift))
            {
                throw new ArgumentException("Sagens overskrift skal udfyldes.");
            }

            try
            {
                SagRepository.EditSag(sag);
            }
            catch (KeyNotFoundException ex)
            {
                throw new KeyNotFoundException($"Kunne ikke finde sagen: {ex.Message}");
            }
        }

        public void DeleteSag(int sagsNr)
        {
            try
            {
                SagRepository.DeleteSag(sagsNr);
            }
            catch (KeyNotFoundException ex)
            {
                // Håndter undtagelsen, hvis sagen ikke findes
                throw new KeyNotFoundException($"Kunne ikke finde sagen: {ex.Message}");
            }
        }

        public List<SagDTO> GetAllSager()
        {
            return SagRepository.GetAllSager();
        }
    }
}
