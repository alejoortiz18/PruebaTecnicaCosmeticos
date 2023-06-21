

namespace Belleza.Models
{
    public class ProductosE
    {
        public int ProductoID { get; set; }
        public string Nombre { get; set; }

        public virtual ICollection<DetalleFacturaE> DetalleFactura { get; set; }
        public virtual ICollection<ProductoXColorE> ProductoXColor { get; set; }
        public virtual ICollection<PromocionesE> Promociones { get; set; }
    }
}
