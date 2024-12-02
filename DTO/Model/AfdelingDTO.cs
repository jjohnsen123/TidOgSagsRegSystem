using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO.Model
{
    public class AfdelingDTO
    {
        public int AfdNr { get; set; }
        public string Navn { get; set; }
        public List<MedarbejderDTO> MedarbList { get; set; } = new List<MedarbejderDTO>();


        public AfdelingDTO(int afdNr, string navn)
        {
            AfdNr = afdNr;
            Navn = navn;
        }
    }
}
