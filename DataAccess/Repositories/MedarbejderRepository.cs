using DataAccess.Context;
using DataAccess.Mappers;
using DataAccess.Model;
using DTO.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repositories
{
    public class MedarbejderRepository
    {
        public static MedarbejderDTO GetMedarbejder(int id)
        {
            using (TidSagRegDbContext context = new TidSagRegDbContext())
            {
                var ma = context.Medarbejdere.Find(id);

                if (ma == null)
                {
                    throw new KeyNotFoundException($"Medarbejder med id '{id}' blev ikke fundet.");
                }

                return MedarbejderMapper.Map(ma);
            }
        }
        public static void AddMedarbejder(MedarbejderDTO medarbejder)
        {
            using (TidSagRegDbContext context = new TidSagRegDbContext())
            {
                var ma = new Medarbejder
                {
                    CprNr = medarbejder.CprNr,
                    Initialer = medarbejder.Initialer,
                    Navn = medarbejder.Navn,
                    AfdelingId = medarbejder.AfdelingId
                };
                var afd = context.Afdelinger.Find(ma.AfdelingId);

                context.Medarbejdere.Add(ma);
                context.SaveChanges();
            }
        }


        public static void EditMedarbejder(MedarbejderDTO maDTO)
        {
            using (TidSagRegDbContext context = new TidSagRegDbContext())
            {
                var ma = context.Medarbejdere.Find(maDTO.Id);

                if (ma == null)
                {
                    throw new KeyNotFoundException($"Medarbejder med initialer '{maDTO.Initialer}' blev ikke fundet.");
                }

                MedarbejderMapper.Update(ma, maDTO);

                context.SaveChanges();
            }
        }

        public static void DeleteMedarbejder(int id)
        {
            using (TidSagRegDbContext context = new TidSagRegDbContext())
            {
                var ma = context.Medarbejdere.Find(id);

                if (ma == null)
                {
                    throw new KeyNotFoundException($"Medarbejder med id '{id}' blev ikke fundet.");
                }


                context.Medarbejdere.Remove(ma);
                context.SaveChanges();
            }
        }

        public static List<MedarbejderDTO> GetAllMedarbejdere()
        {
            using (TidSagRegDbContext context = new TidSagRegDbContext())
            {
                var ma = context.Medarbejdere;

                return ma.Select(MedarbejderMapper.Map).ToList();
            }
        }

        public static List<TidsregistreringDTO> GetAllTidReg()
        {
            using (TidSagRegDbContext context = new TidSagRegDbContext())
            {
                var tr = context.Tidsregistreringer;

                return tr.Select(TidsregistreringMapper.Map).ToList();
            }
        }

        public static void AddTidsReg(int id, TidsregistreringDTO tidsreg)
        {
            using (TidSagRegDbContext context = new TidSagRegDbContext())
            {
                var tr = TidsregistreringMapper.Map(tidsreg);
                var ma = context.Medarbejdere.Find(id);

                if (ma == null)
                {
                    throw new KeyNotFoundException($"Medarbejder med id '{id}' blev ikke fundet.");
                }

                context.Tidsregistreringer.Add(tr);
                
                context.SaveChanges();
            }
        }

        public static void DeleteTidsReg(int id)
        {
            using (TidSagRegDbContext context = new TidSagRegDbContext())
            {
                var tr = context.Tidsregistreringer.Find(id);
                var medarb = context.Medarbejdere.Find(id);

                if (tr == null)
                {
                    throw new KeyNotFoundException($"Tidsregistrering med id '{id}' blev ikke fundet.");
                }

                context.Tidsregistreringer.Remove(tr);
                context.SaveChanges();
            }
        }
    }
}
