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
            var medarb = new MedarbejderDTO
            {
                CprNr = ma.CprNr,
                Initialer = ma.Initialer,
                Navn = ma.Navn,
                AfdelingId = ma.AfdelingId,
                Id = ma.Id
            };

            return medarb;
        }

        public static Medarbejder Map(MedarbejderDTO ma)
        {
            var medarb = new Medarbejder
            {
                CprNr = ma.CprNr,
                Initialer = ma.Initialer,
                Navn = ma.Navn,
                AfdelingId = ma.AfdelingId,
                Id = ma.Id
            };

            return medarb;
        }



        public static void Update(Medarbejder ma, MedarbejderDTO maDTO)
        {
            ma.CprNr = maDTO.CprNr;
            ma.Initialer = maDTO.Initialer;
            ma.Navn = maDTO.Navn;
            ma.AfdelingId = maDTO.AfdelingId;
            ma.Id = maDTO.Id;
        }

    }
}
