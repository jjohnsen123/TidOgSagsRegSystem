using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
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
        [ForeignKey ("AfdelingId")]
        public int AfdelingId { get; set; }
        public Afdeling Afd { get; set; }

        public Sag(string overskrift, string beskrivelse, int afdId)
        {
            Overskrift = overskrift;
            Beskrivelse = beskrivelse;
            AfdelingId = afdId;
        }

        public Sag()
        {
        }
    }
}
