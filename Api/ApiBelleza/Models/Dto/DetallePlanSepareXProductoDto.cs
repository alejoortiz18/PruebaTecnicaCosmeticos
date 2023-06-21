using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ApiBelleza.Models.Dto
{
    public class DetallePlanSepareXProductoDto
    {
        public int PlanSepareID { get; set; }
        public int ProductoXColorID { get; set; }
        public int Cantidad { get; set; }
    }
}