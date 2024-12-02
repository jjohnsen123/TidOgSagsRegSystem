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
            return new MedarbejderDTO(ma.CprNr, ma.Initialer, ma.Navn, AfdelingMapper.Map(ma.Afdeling));
        }

        public static Medarbejder Map(MedarbejderDTO ma)
        {
            return new Medarbejder(ma.CprNr, ma.Initialer, ma.Navn, AfdelingMapper.Map(ma.Afdeling));
        }


    }
}
