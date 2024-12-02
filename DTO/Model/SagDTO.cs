using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO.Model
{
    public class SagDTO
    {
        public int SagsNr { get; set; }
        public string Overskrift {  get; set; }
        public string Beskrivelse { get; set; }
        public AfdelingDTO Afd { get; set; }
        public List<TidsregistreringDTO> TidsregList { get; set; } = new List<TidsregistreringDTO>();


        public SagDTO(int sagsNr, string overskrift, string beskrivelse, AfdelingDTO afd)
        {
            SagsNr = sagsNr;
            Overskrift = overskrift;
            Beskrivelse = beskrivelse;
            Afd = afd;
        }
    }
}
