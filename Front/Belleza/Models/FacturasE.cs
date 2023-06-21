namespace Belleza.Models
{
    public class FacturasE
    {
        public int FacturaID { get; set; }
        public int ClienteID { get; set; }
        public System.DateTime Fecha { get; set; }
        public decimal Total { get; set; }

        public virtual ClientesE Clientes { get; set; }
        public virtual ICollection<DetalleFacturaE> DetalleFactura { get; set; }
    }
}
