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
    public class AfdelingRepository
    {
        public static AfdelingDTO GetAfdeling(int afdNr)
        {
            using (TidSagRegDbContext context = new TidSagRegDbContext())
            {
                var afd = context.Afdelinger.Find(afdNr);

                if (afd == null)
                {
                    throw new KeyNotFoundException($"Afdeling med nummer '{afdNr}' blev ikke fundet.");
                }

                return AfdelingMapper.Map(afd);
            }
        }

        public static void AddAfdeling(AfdelingDTO afdDTO)
        {
            using (TidSagRegDbContext context = new TidSagRegDbContext())
            {
                var afd = AfdelingMapper.Map(afdDTO);
                context.Afdelinger.Add(afd);
                context.SaveChanges();
            }
        }

        public static void EditAfdeling(AfdelingDTO afdDTO)
        {
            using (TidSagRegDbContext context = new TidSagRegDbContext())
            {
                var afd = context.Afdelinger.Find(afdDTO.Id);

                if (afd == null)
                {
                    throw new KeyNotFoundException($"Afdeling med nummer '{afdDTO.Id}' blev ikke fundet.");
                }

                AfdelingMapper.Update(afd, afdDTO);

                context.SaveChanges();
            }
        }

        public static void DeleteAfdeling(int afdNr)
        {
            using (TidSagRegDbContext context = new TidSagRegDbContext())
            {
                var afd = context.Afdelinger.FirstOrDefault(a => a.AfdelingId == afdNr);

                if (afd == null)
                {
                    throw new KeyNotFoundException($"Afdeling med nummer '{afdNr}' blev ikke fundet.");
                }

                context.Afdelinger.Remove(afd);
                context.SaveChanges();
            }
        }

        public static List<AfdelingDTO> GetAllAfdelinger()
        {
            using (TidSagRegDbContext context = new TidSagRegDbContext())
            {
                var afd = context.Afdelinger;

                return afd.Select(AfdelingMapper.Map).ToList();
            }
        }
    }
}
