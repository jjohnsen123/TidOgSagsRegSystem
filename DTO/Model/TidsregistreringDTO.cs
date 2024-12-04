using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO.Model
{
    public class TidsregistreringDTO
    {
        public int TidregId { get; set; }
        public MedarbejderDTO Medarbejder { get; set; }
        public SagDTO? Sag { get; set; }
        public DateTime StartTid { get; set; }
        public DateTime SlutTid { get; set; }

        public TidsregistreringDTO(int id, MedarbejderDTO medarbejder, SagDTO? sag, DateTime startTid, DateTime slutTid)
        {
            TidregId = id;
            Medarbejder = medarbejder;
            Sag = sag;
            StartTid = startTid;
            SlutTid = slutTid;
        }

        public TidsregistreringDTO()
        {
        }
    }
}
