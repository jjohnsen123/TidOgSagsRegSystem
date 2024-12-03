using DataAccess.Model;
using DTO.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Mappers
{
    internal class MedarbejderMapper
    {
        public static MedarbejderDTO Map(Medarbejder ma)
        {
            var medarb = new MedarbejderDTO(ma.CprNr, ma.Initialer, ma.Navn, AfdelingMapper.Map(ma.Afdeling));

            if (ma.TidsregList != null)
            {
                foreach (var tr in ma.TidsregList)
                {
                    medarb.TidsregList.Add(TidsregistreringMapper.Map(tr));
                }
            }

            return medarb;
        }

        public static Medarbejder Map(MedarbejderDTO ma)
        {
            var medarb = new Medarbejder(ma.CprNr, ma.Initialer, ma.Navn, AfdelingMapper.Map(ma.Afdeling));

            if (ma.TidsregList != null)
            {
                foreach (var tr in ma.TidsregList)
                {
                    medarb.TidsregList.Add(TidsregistreringMapper.Map(tr));
                }
            }

            return medarb;
        }

        public static void Update(Medarbejder ma, MedarbejderDTO maDTO)
        {
            ma.CprNr = maDTO.CprNr;
            ma.Initialer = maDTO.Initialer;
            ma.Navn = maDTO.Navn;
            ma.Afdeling = AfdelingMapper.Map(maDTO.Afdeling);
        }

    }
}
