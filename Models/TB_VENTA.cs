//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ProyectoNexus.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class TB_VENTA
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public TB_VENTA()
        {
            this.TB_CLIENTE = new HashSet<TB_CLIENTE>();
        }
    
        public int VEN_COD { get; set; }
        public int AGEN_COD { get; set; }
        public int AUT_COD { get; set; }
        public int GERE_COD { get; set; }
        public string VEN_DES { get; set; }
        public double VEN_PREC_UNITA { get; set; }
        public int VEN_CANT { get; set; }
        public double VEN_TOTAL { get; set; }
        public Nullable<System.DateTime> VEN_FECH { get; set; }
    
        public virtual TB_AGENTE TB_AGENTE { get; set; }
        public virtual TB_AUTOS TB_AUTOS { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TB_CLIENTE> TB_CLIENTE { get; set; }
        public virtual TB_GERENTE TB_GERENTE { get; set; }
    }
}
