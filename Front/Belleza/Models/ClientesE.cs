

namespace Belleza.Models
{
    public class ClientesE
    {
        public int ClienteID { get; set; }
        public string Nombre { get; set; }
        public int Identificacion { get; set; }

        public virtual ICollection<FacturasE> Facturas { get; set; }
        public virtual ICollection<PlanSepareE> PlanSepare { get; set; }
    }
}
