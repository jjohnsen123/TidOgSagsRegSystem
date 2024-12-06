using DataAccess.Model;
using DTO.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Mappers
{
    internal class SagMapper
    {
        public static SagDTO Map(Sag sag)
        {
            var sa = new SagDTO
            {
                Id = sag.Id,
                Overskrift = sag.Overskrift,
                Beskrivelse = sag.Beskrivelse,
                AfdelingId = sag.AfdelingId
            };

            return sa;
        }

        public static Sag Map(SagDTO sag)
        {
            var sa = new Sag
            {
                Id = sag.Id,
                Overskrift = sag.Overskrift,
                Beskrivelse = sag.Beskrivelse,
                AfdelingId = sag.AfdelingId
            };

            return sa;
        }


        public static void Update(Sag sag, SagDTO sagDTO)
        {
            sag.Id = sagDTO.Id;
            sag.Overskrift = sagDTO.Overskrift;
            sag.Beskrivelse = sagDTO.Beskrivelse;
            sag.AfdelingId = sagDTO.AfdelingId;
        }
    }
}
