using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO.Model
{
    public class AfdelingDTO
    {
        public int Id { get; set; }
        public string Navn { get; set; }

        public AfdelingDTO(int id, string navn)
        {
            Id = id;
            Navn = navn;
        }

        public AfdelingDTO()
        {
        }
    }
}
