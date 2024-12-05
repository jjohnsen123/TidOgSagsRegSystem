using DataAccess.Model;
using DTO.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Mappers
{
    internal class TidsregistreringMapper
    {
        public static TidsregistreringDTO Map(Tidsregistrering tr)
        {
            return new TidsregistreringDTO(tr.MedarbejderId, tr.SagId, tr.StartTid, tr.SlutTid);
        }

        public static Tidsregistrering Map(TidsregistreringDTO tr)
        {
            return new Tidsregistrering(tr.MedarbejderId, tr.SagId, tr.StartTid, tr.SlutTid);
        }
    }
}
