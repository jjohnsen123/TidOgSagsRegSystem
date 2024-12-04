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
                var ma = new Medarbejder
                {
                    CprNr = medarbejder.CprNr,
                    Initialer = medarbejder.Initialer,
                    Navn = medarbejder.Navn,
                    AfdelingId = medarbejder.AfdelingId
                };
                var afd = context.Afdelinger.Find(ma.AfdelingId);

                context.Attach(afd);
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
                var ma = context.Medarbejdere;

                return ma.Select(MedarbejderMapper.Map).ToList();
            }
        }

        public static List<TidsregistreringDTO> GetAllTidRegInMedarb(string initialer)
        {
            using (TidSagRegDbContext context = new TidSagRegDbContext())
            {
                List<TidsregistreringDTO> tidsregList = new List<TidsregistreringDTO>();
                var ma = context.Medarbejdere.Find(initialer);

                if (ma == null)
                {
                    throw new KeyNotFoundException($"Medarbejder med initialer '{initialer}' blev ikke fundet.");
                }

                foreach (var tr in ma.TidsregList)
                {
                    tidsregList.Add(TidsregistreringMapper.Map(tr));
                }

                return tidsregList;
            }
        }

        public static void AddTidsReg(string initialer, TidsregistreringDTO tidsreg)
        {
            using (TidSagRegDbContext context = new TidSagRegDbContext())
            {
                var tr = TidsregistreringMapper.Map(tidsreg);
                var ma = context.Medarbejdere.Find(initialer);

                if (ma == null)
                {
                    throw new KeyNotFoundException($"Medarbejder med initialer '{initialer}' blev ikke fundet.");
                }

                ma.TidsregList.Add(tr);
                context.Tidsregistreringer.Add(tr);
                
                context.SaveChanges();
            }
        }

        public static void DeleteTidsReg(int id)
        {
            using (TidSagRegDbContext context = new TidSagRegDbContext())
            {
                var tr = context.Tidsregistreringer.Find(id);

                if (tr == null)
                {
                    throw new KeyNotFoundException($"Tidsregistrering med initialer '{id}' blev ikke fundet.");
                }

                tr.Medarbejder.TidsregList.Remove(tr);
                context.Tidsregistreringer.Remove(tr);
                context.SaveChanges();
            }
        }
    }
}
