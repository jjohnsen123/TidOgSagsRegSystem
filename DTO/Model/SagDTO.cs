using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO.Model
{
    public class SagDTO
    {
        public int Id { get; set; }
        public string Overskrift {  get; set; }
        public string Beskrivelse { get; set; }
        [ForeignKey ("AfdelingId")]
        public int AfdelingId { get; set; }

        public SagDTO(string overskrift, string beskrivelse, int afdId)
        {
            Overskrift = overskrift;
            Beskrivelse = beskrivelse;
            AfdelingId = afdId;
        }

        public SagDTO()
        {
        }
    }
}
