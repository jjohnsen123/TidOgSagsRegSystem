using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO.Model
{
    public class TidsregistreringDTO
    {
        public int Id { get; set; }
        public int MedarbejderId { get; set; }
        public int? SagId { get; set; }
        public DateTime StartTid { get; set; }
        public DateTime SlutTid { get; set; }

        public TidsregistreringDTO(int medarbId, int? sagId, DateTime startTid, DateTime slutTid)
        {
            MedarbejderId = medarbId;
            SagId = sagId;
            StartTid = startTid;
            SlutTid = slutTid;
        }

        public TidsregistreringDTO()
        {
        }
    }
}
