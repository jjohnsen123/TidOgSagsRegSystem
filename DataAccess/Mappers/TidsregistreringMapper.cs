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
            return new TidsregistreringDTO(tr.TidregId, MedarbejderMapper.Map(tr.Medarbejder), SagMapper.Map(tr.Sag), tr.StartTid, tr.SlutTid);
        }

        public static Tidsregistrering Map(TidsregistreringDTO tr)
        {
            return new Tidsregistrering(tr.TidregId, MedarbejderMapper.Map(tr.Medarbejder), SagMapper.Map(tr.Sag), tr.StartTid, tr.SlutTid);
        }
    }
}
