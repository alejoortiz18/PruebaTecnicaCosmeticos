

namespace Belleza.Models.Dto
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
