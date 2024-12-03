using DTO.Model;
using DataAccess.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.BLL
{
    public class MedarbejderBLL
    {
        public MedarbejderDTO GetMedarbejder(string initialer)
        {
            try
            {
                return MedarbejderRepository.GetMedarbejder(initialer);
            }
            catch (KeyNotFoundException ex)
            {
                // Tilføj evt. logik for at logge fejl eller informere brugeren
                throw new KeyNotFoundException($"Kunne ikke finde medarbejderen: {ex.Message}");
            }
        }

        public void AddMedarbejder(MedarbejderDTO ma)
        {
            // Tilføj forretningslogik: valider medarbejderen, før du tilføjer den til databasen
            if (string.IsNullOrEmpty(ma.Initialer) || string.IsNullOrEmpty(ma.Navn))
            {
                throw new ArgumentException("Medarbejderens initialer og navn skal udfyldes.");
            }

            MedarbejderRepository.AddMedarbejder(ma);
        }

        public void EditMedarbejder(MedarbejderDTO ma)
        {
            // Validerer, at medarbejderen eksisterer, og data er gyldige
            if (string.IsNullOrEmpty(ma.Initialer) || string.IsNullOrEmpty(ma.Navn))
            {
                throw new ArgumentException("Medarbejderens initialer og navn skal udfyldes.");
            }

            try
            {
                MedarbejderRepository.EditMedarbejder(ma);
            }
            catch (KeyNotFoundException ex)
            {
                throw new KeyNotFoundException($"Kunne ikke finde medarbejderen: {ex.Message}");
            }
        }

        public void DeleteMedarbejder(string initialer)
        {
            try
            {
                MedarbejderRepository.DeleteMedarbejder(initialer);
            }
            catch (KeyNotFoundException ex)
            {
                // Behandle undtagelsen, hvis medarbejderen ikke findes
                throw new KeyNotFoundException($"Kunne ikke finde medarbejderen: {ex.Message}");
            }
        }

        public List<MedarbejderDTO> GetAllMedarbejdere()
        {
            return MedarbejderRepository.GetAllMedarbejdere();
        }

        // Tilføj en tidsregistrering for en medarbejder
        public void AddTidsregistrering(string initialer, TidsregistreringDTO tr)
        {
            // Valider at tidsregistreringen har de nødvendige data
            if (tr.StartTid == default || tr.SlutTid == default)
            {
                throw new ArgumentException("Start- og sluttidspunkt skal udfyldes korrekt.");
            }

            MedarbejderRepository.AddTidsReg(initialer, tr);
        }

        public void DeleteTidsregistrering(int id)
        {
            try
            {
                MedarbejderRepository.DeleteTidsReg(id);
            }
            catch (KeyNotFoundException ex)
            {
                throw new KeyNotFoundException($"Kunne ikke finde tidsregistreringen: {ex.Message}");
            }
        }
    }
}
