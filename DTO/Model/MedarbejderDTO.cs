using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO.Model
{
    public class MedarbejderDTO
    {
        public double CprNr { get; set; }
        public string Initialer {  get; set; }
        public string Navn { get; set; }
        [ForeignKey ("Afdeling")]
        public int AfdelingId { get; set; }
        public AfdelingDTO Afdeling { get; set; }
        public List<TidsregistreringDTO> TidsregList { get; set; } = new List<TidsregistreringDTO>();


        public MedarbejderDTO(double cprNr, string initialer, string navn, AfdelingDTO afdeling, int afdNr)
        {
            CprNr = cprNr;
            Initialer = initialer;
            Navn = navn;
            Afdeling = afdeling;
            AfdelingId = afdNr;
        }

        public MedarbejderDTO(double cprNr, string initialer, string navn, int afdelingId)
        {
            CprNr = cprNr;
            Initialer = initialer;
            Navn = navn;
            AfdelingId = afdelingId;
        }

        public MedarbejderDTO()
        {
        }
    }
}
