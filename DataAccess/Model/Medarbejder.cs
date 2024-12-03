using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Model
{
    public class Medarbejder
    {
        public int CprNr { get; set; }
        public string Initialer { get; set; }
        public string Navn { get; set; }
        public Afdeling Afdeling { get; set; }
        public List<Tidsregistrering> TidsregList { get; set; } = new List<Tidsregistrering>();

        public Medarbejder(int cprNr, string initialer, string navn, Afdeling afdeling)
        {
            CprNr = cprNr;
            Initialer = initialer;
            Navn = navn;
            Afdeling = afdeling;
        }

        public Medarbejder()
        {
        }
    }
}
