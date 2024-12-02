using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO.Model
{
    public class MedarbejderDTO
    {
        public int CprNr { get; set; }
        public string Initialer {  get; set; }
        public string Navn { get; set; }
        public List<AfdelingDTO> AfdList { get; set; } = new List<AfdelingDTO>();
        public List<TidsregistreringDTO> TidsregList { get; set; } = new List<TidsregistreringDTO>();


        public MedarbejderDTO(int cprNr, string initialer, string navn)
        {
            CprNr = cprNr;
            Initialer = initialer;
            Navn = navn;
        }
    }
}
