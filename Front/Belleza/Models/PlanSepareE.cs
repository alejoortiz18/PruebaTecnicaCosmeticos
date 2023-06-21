namespace Belleza.Models
{
    public class PlanSepareE
    {
        public int PlanSepareID { get; set; }
        public int ClienteID { get; set; }
        public System.DateTime FechaSepare { get; set; }
        public decimal TotalPrecioSepare { get; set; }
        public decimal ValorMinimo { get; set; }

        public virtual ClientesE Clientes { get; set; }
        public virtual ICollection<DetallePlanSepareXProductoE> DetallePlanSepareXProducto { get; set; }
    }
}
