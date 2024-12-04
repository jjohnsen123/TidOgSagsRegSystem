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
        public MedarbejderDTO GetMedarbejder(int id)
        {
            try
            {
                return MedarbejderRepository.GetMedarbejder(id);
            }
            catch (KeyNotFoundException ex)
            {
                throw new KeyNotFoundException($"Kunne ikke finde medarbejderen: {ex.Message}");
            }
        }

        public void AddMedarbejder(MedarbejderDTO ma)
        {
            if (string.IsNullOrEmpty(ma.Initialer) || string.IsNullOrEmpty(ma.Navn))
            {
                throw new ArgumentException("Medarbejderens initialer og navn skal udfyldes.");
            }

            // Tjek om CPR eller Initialer allerede eksisterer
            var eksisterendeMedarbejdere = GetAllMedarbejdere();
            if (eksisterendeMedarbejdere.Exists(m => m.CprNr == ma.CprNr))
            {
                throw new Exception("En medarbejder med det samme CPR-nummer eksisterer allerede.");
            }

            if (eksisterendeMedarbejdere.Exists(m => m.Initialer == ma.Initialer))
            {
                throw new Exception("En medarbejder med de samme initialer eksisterer allerede.");
            }



            MedarbejderRepository.AddMedarbejder(ma);
        }

        public void EditMedarbejder(MedarbejderDTO ma)
        {
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

        public void DeleteMedarbejder(int id)
        {
            try
            {
                MedarbejderRepository.DeleteMedarbejder(id);
            }
            catch (KeyNotFoundException ex)
            {
                throw new KeyNotFoundException($"Kunne ikke finde medarbejderen: {ex.Message}");
            }
        }

        public List<MedarbejderDTO> GetAllMedarbejdere()
        {
            return MedarbejderRepository.GetAllMedarbejdere();
        }

        public List<TidsregistreringDTO> GetAllTidRegInMedarb(int id)
        {
            return MedarbejderRepository.GetAllTidRegInMedarb(id);
        }

        public void AddTidsregs(int id, TidsregistreringDTO tr)
        {
            if (tr.StartTid == default || tr.SlutTid == default)
            {
                throw new ArgumentException("Start- og sluttidspunkt skal udfyldes korrekt.");
            }

            MedarbejderRepository.AddTidsReg(id, tr);
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
