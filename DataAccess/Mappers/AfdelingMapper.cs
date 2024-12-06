using DataAccess.Model;
using DTO.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Mappers
{
    internal class AfdelingMapper
    {
        public static AfdelingDTO Map(Afdeling afd)
        {
            var afdeling = new AfdelingDTO(afd.Id, afd.Navn);

            return afdeling;

        }

        public static Afdeling Map(AfdelingDTO afd)
        {
            var afdeling = new Afdeling(afd.Id, afd.Navn);

            return afdeling;
        }


        public static void Update(Afdeling afd, AfdelingDTO afdDTO)
        {
            afd.Navn = afdDTO.Navn;
        }
    }
}
