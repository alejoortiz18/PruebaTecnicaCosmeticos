using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ApiBelleza.Models.Dto
{
    public class PlanSepareDetalleDto
    {
        public int ClienteID { get; set; }
        public DateTime FechaSepare { get; set; }
        public double TotalPrecioSepare { get; set; }
        public double ValorMinimo { get; set; }
        public int PlanSepareID { get; set; }
        public int Cantidad { get; set; }
        public int CantidadStock { get; set; }
        public double PrecioUnidad { get; set; }
        public string Referencia { get; set; }
        public int ProductoXColorID { get; set; }
    }
}