using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Model
{
    public class Tidsregistrering
    {
        public int TidregId { get; set; }
        public Medarbejder Medarbejder { get; set; }
        public Sag? Sag { get; set; }
        public DateTime StartTid { get; set; }
        public DateTime SlutTid { get; set; }

        public Tidsregistrering(int id,Medarbejder medarbejder, Sag? sag, DateTime startTid, DateTime slutTid)
        {
            TidregId = id;
            Medarbejder = medarbejder;
            Sag = sag;
            StartTid = startTid;
            SlutTid = slutTid;
        }

    }
}
