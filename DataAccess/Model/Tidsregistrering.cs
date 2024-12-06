using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Model
{
    public class Tidsregistrering
    {
        public int Id { get; set; }
        [ForeignKey ("MedarbejderId")]
        public int MedarbejderId { get; set; }
        [ForeignKey ("SagId")]
        public int? SagId { get; set; }
        public DateTime StartTid { get; set; }
        public DateTime SlutTid { get; set; }

        public Tidsregistrering(int medarbId, int? sagId, DateTime startTid, DateTime slutTid)
        {
            MedarbejderId = medarbId;
            SagId = sagId;
            StartTid = startTid;
            SlutTid = slutTid;
        }

        public Tidsregistrering()
        {
        }
    }
}
