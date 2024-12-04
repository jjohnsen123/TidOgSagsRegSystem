using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Model
{
    public class Afdeling
    {
        public int Id { get; set; }
        public string Navn { get; set; }
        //public List<Medarbejder> MedarbList { get; set; } = new List<Medarbejder>();
        // Ikke rigtig nødvendig, men kan bruges senere

        public Afdeling(int afdNr, string navn)
        {
            Id = afdNr;
            Navn = navn;
        }

        public Afdeling()
        {
        }
    }
}
