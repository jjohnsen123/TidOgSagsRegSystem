using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Model
{
    public class Afdeling
    {

        public int AfdelingId { get; set; }
        public string Navn { get; set; }
        public List<Medarbejder> MedarbList { get; set; } = new List<Medarbejder>();

        public Afdeling(int id,  string navn)
        {
            AfdelingId = id;
            Navn = navn;
        }

        public Afdeling()
        {
        }
    }
}
