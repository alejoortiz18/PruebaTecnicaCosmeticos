
namespace Belleza.Models
{
    public class DetallePlanSepareXProductoE
    {
        public int PlanSepareID { get; set; }
        public int ProductoXColorID { get; set; }
        public int Cantidad { get; set; }

        public virtual PlanSepareE PlanSepare { get; set; }
        public virtual ProductoXColorE ProductoXColor { get; set; }
    }

}
