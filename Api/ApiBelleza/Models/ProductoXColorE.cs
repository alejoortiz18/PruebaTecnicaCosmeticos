//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ApiBelleza.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class ProductoXColorE
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public ProductoXColorE()
        {
            this.DetallePlanSepareXProducto = new HashSet<DetallePlanSepareXProductoE>();
        }
    
        public int ProductoXColorID { get; set; }
        public int ProductoID { get; set; }
        public int ColorID { get; set; }
        public int CantidadStock { get; set; }
        public decimal PrecioUnidad { get; set; }
        public string Referencia { get; set; }
    
        public virtual Colores Colores { get; set; }
        public virtual ProductosE Productos { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DetallePlanSepareXProductoE> DetallePlanSepareXProducto { get; set; }
    }
}
