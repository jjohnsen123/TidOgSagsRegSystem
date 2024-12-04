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
                throw new KeyNotFoundException($"Kunne ikke finde medarbejderen: {ex.Message}");
            }
        }

        public void AddMedarbejder(MedarbejderDTO ma)
        {
            if (string.IsNullOrEmpty(ma.Initialer) || string.IsNullOrEmpty(ma.Navn))
            {
                throw new ArgumentException("Medarbejderens initialer og navn skal udfyldes.");
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

        public void DeleteMedarbejder(string initialer)
        {
            try
            {
                MedarbejderRepository.DeleteMedarbejder(initialer);
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

        public List<TidsregistreringDTO> GetAllTidRegInMedarb(string initialier)
        {
            return MedarbejderRepository.GetAllTidRegInMedarb(initialier);
        }

        public void AddTidsregs(string initialer, TidsregistreringDTO tr)
        {
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
