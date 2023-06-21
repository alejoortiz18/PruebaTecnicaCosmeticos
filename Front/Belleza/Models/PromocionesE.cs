namespace Belleza.Models
{
    public class PromocionesE
    {
        public int PromocionID { get; set; }
        public int ProductoID { get; set; }
        public int PorcentajeDescuento { get; set; }

        public virtual ProductosE Productos { get; set; }
    }
}
