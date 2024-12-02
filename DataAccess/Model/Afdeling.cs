using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Model
{
    public class Afdeling
    {
        public int AfdNr { get; set; }
        public string Navn { get; set; }
        public List<Medarbejder> MedarbList { get; set; } = new List<Medarbejder>();


        public Afdeling(int afdNr, string navn)
        {
            AfdNr = afdNr;
            Navn = navn;
        }
    }
}
