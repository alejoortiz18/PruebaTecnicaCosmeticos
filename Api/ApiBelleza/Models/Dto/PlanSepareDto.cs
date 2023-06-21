using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ApiBelleza.Models.Dto
{
    public class PlanSepareDto
    {
        public int PlanSepareID { get; set; }
        public int ClienteID { get; set; }
        public System.DateTime FechaSepare { get; set; }
        public decimal TotalPrecioSepare { get; set; }
        public decimal ValorMinimo { get; set; }

        public virtual List<DetallePlanSepareXProductoE> DetallePlanSepareXProducto { get; set; }
    }
}