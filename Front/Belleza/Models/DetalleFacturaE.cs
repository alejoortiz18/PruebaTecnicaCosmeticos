

namespace Belleza.Models
{
    public class DetalleFacturaE
    {
        public int FacturaID { get; set; }
        public int ProductoID { get; set; }
        public int Cantidad { get; set; }

        public virtual FacturasE Facturas { get; set; }
        public virtual ProductosE Productos { get; set; }
    }
}
