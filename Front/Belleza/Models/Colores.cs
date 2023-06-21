

namespace Belleza.Models
{
    public class Colores
    {
        public int ColorID { get; set; }
        public string Color { get; set; }

        public virtual ICollection<ProductoXColorE> ProductoXColor { get; set; }
    }
}
