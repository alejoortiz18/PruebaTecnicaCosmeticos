namespace Belleza.Models
{
    public class ProductoXColorE
    {
        public int ProductoXColorID { get; set; }
        public int ProductoID { get; set; }
        public int ColorID { get; set; }
        public int CantidadStock { get; set; }
        public decimal PrecioUnidad { get; set; }
        public string Referencia { get; set; }

        public virtual Colores Colores { get; set; }
        public virtual ProductosE Productos { get; set; }
        public virtual ICollection<DetallePlanSepareXProductoE> DetallePlanSepareXProducto { get; set; }
    }
}
