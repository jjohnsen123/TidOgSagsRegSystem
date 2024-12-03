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
            var sa = new SagDTO(sag.SagsNr, sag.Overskrift, sag.Beskrivelse, AfdelingMapper.Map(sag.Afd));

            if (sag.TidsregList != null)
            {
                foreach (var tr in sag.TidsregList)
                {
                    sa.TidsregList.Add(TidsregistreringMapper.Map(tr));
                }
            }

            return sa;
        }

        public static Sag Map(SagDTO sag)
        {
            var sa = new Sag(sag.SagsNr, sag.Overskrift, sag.Beskrivelse, AfdelingMapper.Map(sag.Afd));

            if (sag.TidsregList != null)
            {
                foreach (var tr in sag.TidsregList)
                {
                    sa.TidsregList.Add(TidsregistreringMapper.Map(tr));
                }
            }

            return sa;
        }
    }
}
