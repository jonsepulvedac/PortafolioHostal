//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace HostalSraRosaWebApi
{
    using System;
    using System.Collections.Generic;
    
    public partial class PROVEEDOR
    {
        public decimal PROVEEDOR_ID { get; set; }
        public string PROVEEDOR_NOMBRE { get; set; }
        public decimal PROVEEDOR_TELEFONO { get; set; }
        public string PROVEEDOR_EMAIL { get; set; }
        public decimal RUBRO_ID { get; set; }
    
        public virtual RUBRO RUBRO { get; set; }
    }
}
