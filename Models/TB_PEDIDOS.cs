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
    
    public partial class TB_PEDIDOS
    {
        public int PED_COD { get; set; }
        public int PROV_COD { get; set; }
        public int GERE_COD { get; set; }
        public int AGEN_COD { get; set; }
        public string PED_DESCR { get; set; }
        public double PED_PRECIO_UNITA { get; set; }
        public int PED_CANTID { get; set; }
        public double PED_TOTAL { get; set; }
        public Nullable<System.DateTime> PED_FECH { get; set; }
    
        public virtual TB_AGENTE TB_AGENTE { get; set; }
        public virtual TB_GERENTE TB_GERENTE { get; set; }
        public virtual TB_PROVEEDORES TB_PROVEEDORES { get; set; }
    }
}