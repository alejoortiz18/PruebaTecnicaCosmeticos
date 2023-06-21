using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ApiBelleza.Models.Dto
{
    public class ClienteDto
    {
        public int ClienteID { get; set; }
        [Required]
        public string Nombre { get; set; }
        [Required]
        public int Cedula { get; set; }
    }
}