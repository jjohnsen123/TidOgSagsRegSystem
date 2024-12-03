using DataAccess.Context;
using DataAccess.Mappers;
using DataAccess.Model;
using DTO.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repositories
{
    internal class MedarbejderRepository
    {

        public static MedarbejderDTO GetMedarbejder(string initialer)
        {
            using (TidSagRegDbContext context = new TidSagRegDbContext())
            {
                var ma = context.Medarbejdere.Find(initialer);

                if (ma == null)
                {
                    throw new KeyNotFoundException($"Medarbejder med initialer '{initialer}' blev ikke fundet.");
                }

                return MedarbejderMapper.Map(ma);
            }
        }

        public static void AddMedarbejder(MedarbejderDTO medarbejder)
        {
            using (TidSagRegDbContext context = new TidSagRegDbContext())
            {
                Medarbejder ma = MedarbejderMapper.Map(medarbejder);
                context.Medarbejdere.Add(ma);
                context.SaveChanges();
            }
        }

        public static void EditMedarbejder(MedarbejderDTO maDTO)
        {
            using (TidSagRegDbContext context = new TidSagRegDbContext())
            {
                var ma = context.Medarbejdere.Find(maDTO.Initialer);

                if (ma == null)
                {
                    throw new KeyNotFoundException($"Medarbejder med initialer '{maDTO.Initialer}' blev ikke fundet.");
                }

                MedarbejderMapper.Update(ma, maDTO);

                context.SaveChanges();
            }
        }

        public static void DeleteMedarbejder(string initialer)
        {
            using (TidSagRegDbContext context = new TidSagRegDbContext())
            {
                var ma = context.Medarbejdere.Find(initialer);

                if (ma == null)
                {
                    throw new KeyNotFoundException($"Medarbejder med initialer '{initialer}' blev ikke fundet.");
                }

                context.Medarbejdere.Remove(ma);
                context.SaveChanges();
            }
        }

        public static List<MedarbejderDTO> GetAllMedarbejdere()
        {
            using (TidSagRegDbContext context = new TidSagRegDbContext())
            {
                var medarbejdere = context.Medarbejdere;

                return medarbejdere.Select(MedarbejderMapper.Map).ToList();
            }
        }

        public static List<Tidsregistrering> AllTidReg(Medarbejder ma) //MedarbejderDTO eller Medarbejder?
        {
            List<Tidsregistrering> retur = new List<Tidsregistrering>();

            using (TidSagRegDbContext context = new TidSagRegDbContext())
            {
                foreach (var tr in ma.TidsregList)
                {
                    retur.Add(tr);
                }

                return retur;
            }
        }

        public static void AddTidsReg(string initialer, Tidsregistrering tr)
        {
            using (TidSagRegDbContext context = new TidSagRegDbContext())
            {
                var ma = context.Medarbejdere.Find(initialer);

                if (ma == null)
                {
                    throw new KeyNotFoundException($"Medarbejder med initialer '{initialer}' blev ikke fundet.");
                }

                ma.TidsregList.Add(tr);
                context.SaveChanges();
            }
        }
    }
}
