using DataAccess.Context;
using DataAccess.Mappers;
using DTO.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repositories
{
    public class SagRepository
    {
        public static SagDTO GetSag(int sagsNr)
        {
            using (TidSagRegDbContext context = new TidSagRegDbContext())
            {
                var sag = context.Sager.Find(sagsNr);

                if (sag == null)
                {
                    throw new KeyNotFoundException($"Sag med nummer '{sagsNr}' blev ikke fundet.");
                }

                return SagMapper.Map(sag);
            }
        }

        public static void AddSag(SagDTO sagDTO)
        {
            using (TidSagRegDbContext context = new TidSagRegDbContext())
            {
                var sag = SagMapper.Map(sagDTO);
                context.Sager.Add(sag);
                context.SaveChanges();
            }
        }

        public static void EditSag(SagDTO sagDTO)
        {
            using (TidSagRegDbContext context = new TidSagRegDbContext())
            {
                var sag = context.Sager.Find(sagDTO);

                if (sag == null)
                {
                    throw new KeyNotFoundException($"Sag med nummer '{sagDTO.SagsNr}' blev ikke fundet.");
                }

                SagMapper.Update(sag, sagDTO);

                context.SaveChanges();
            }
        }

        public static void DeleteSag(int sagsNr)
        {
            using (TidSagRegDbContext context = new TidSagRegDbContext())
            {
                var sag = context.Sager.FirstOrDefault(s => s.SagsNr == sagsNr);

                if (sag == null)
                {
                    throw new KeyNotFoundException($"Sag med nummer '{sagsNr}' blev ikke fundet.");
                }

                context.Sager.Remove(sag);
                context.SaveChanges();
            }
        }

        public static List<SagDTO> GetAllSager()
        {
            using (TidSagRegDbContext context = new TidSagRegDbContext())
            {
                var sager = context.Sager;

                return sager.Select(SagMapper.Map).ToList();
            }
        }
    }
}
