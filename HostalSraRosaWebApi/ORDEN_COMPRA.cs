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
    
    public partial class ORDEN_COMPRA
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public ORDEN_COMPRA()
        {
            this.DETALLE_COMPRA = new HashSet<DETALLE_COMPRA>();
        }
    
        public decimal ORDEN_COMPRA_ID { get; set; }
        public System.DateTime ORDEN_COMPRA_FECHA_INICIO { get; set; }
        public System.DateTime ORDEN_COMPRA_FECHA_TERMINO { get; set; }
        public decimal EMPRESA_RUT { get; set; }
    
        public virtual EMPRESA EMPRESA { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DETALLE_COMPRA> DETALLE_COMPRA { get; set; }
    }
}
