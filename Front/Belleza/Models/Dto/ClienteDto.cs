using Belleza.Interfaces;
using Microsoft.AspNetCore.Components;
using System.ComponentModel.DataAnnotations;

namespace Belleza.Models.Dto
{
    public class ClienteDto
    {
        public int ClienteID { get; set; }
        [Required]
        public string Nombre { get; set; }
        [Required]
        public int Cedula { get; set; }

        public List<ClienteDto> listCliente { get; set; }   

     
    }
}
