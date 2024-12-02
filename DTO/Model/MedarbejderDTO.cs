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
        public AfdelingDTO Afdeling { get; set; }
        public List<TidsregistreringDTO> TidsregList { get; set; } = new List<TidsregistreringDTO>();


        public MedarbejderDTO(int cprNr, string initialer, string navn, AfdelingDTO afdeling)
        {
            CprNr = cprNr;
            Initialer = initialer;
            Navn = navn;
            Afdeling = afdeling;
        }
    }
}
