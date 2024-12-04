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
        public int Id { get; set; }
        public double CprNr { get; set; }
        public string Initialer {  get; set; }
        public string Navn { get; set; }
        [ForeignKey ("AfdelingId")]
        public int AfdelingId { get; set; }
        public AfdelingDTO Afdeling { get; set; }
        public List<TidsregistreringDTO> TidsregList { get; set; } = new List<TidsregistreringDTO>();


        public MedarbejderDTO(double cprNr, string initialer, string navn, int afdId)
        {
            CprNr = cprNr;
            Initialer = initialer;
            Navn = navn;
            AfdelingId = afdId;

        }


        public MedarbejderDTO()
        {
        }
    }
}
