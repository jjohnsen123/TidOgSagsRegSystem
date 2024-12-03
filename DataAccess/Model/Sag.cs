using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Model
{
    public class Sag
    {
        public int SagsNr { get; set; }
        public string Overskrift {  get; set; }
        public string Beskrivelse { get; set; }
        public Afdeling Afd { get; set; }
        public List<Tidsregistrering> TidsregList { get; set; } = new List<Tidsregistrering>(); //Måske ikke nødvednigt

        public Sag(int sagsNr, string overskrift, string beskrivelse, Afdeling afd)
        {
            SagsNr = sagsNr;
            Overskrift = overskrift;
            Beskrivelse = beskrivelse;
            Afd = afd;
        }
    }
}
