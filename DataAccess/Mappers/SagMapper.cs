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
            return new SagDTO(sag.SagsNr, sag.Overskrift, sag.Beskrivelse, AfdelingMapper.Map(sag.Afd));
        }

        public static Sag Map(SagDTO sag)
        {
            return new Sag(sag.SagsNr, sag.Overskrift, sag.Beskrivelse, AfdelingMapper.Map(sag.Afd));
        }
    }
}
