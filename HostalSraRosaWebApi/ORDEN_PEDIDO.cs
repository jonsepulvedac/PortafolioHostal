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
    
    public partial class ORDEN_PEDIDO
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public ORDEN_PEDIDO()
        {
            this.DETALLE_PEDIDO = new HashSet<DETALLE_PEDIDO>();
        }
    
        public decimal ORDEN_PEDIDO_ID { get; set; }
        public decimal ORDEN_PEDIDO_PRECIO_TOTAL { get; set; }
        public System.DateTime ORDEN_PEDIDO_FECHA { get; set; }
        public decimal EMPLEADO_RUT { get; set; }
        public decimal PROVEEDOR_ID { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DETALLE_PEDIDO> DETALLE_PEDIDO { get; set; }
        public virtual EMPLEADO EMPLEADO { get; set; }
        public virtual PROVEEDOR PROVEEDOR { get; set; }
    }
}
