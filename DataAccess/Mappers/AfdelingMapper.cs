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
            return new AfdelingDTO(afd.AfdNr, afd.Navn);
        }

        public static Afdeling Map(AfdelingDTO afd)
        {
            return new Afdeling(afd.AfdNr, afd.Navn);
        }
    }
}
