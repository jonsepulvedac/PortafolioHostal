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
    
    public partial class EMPLEADO
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public EMPLEADO()
        {
            this.ORDEN_PEDIDO = new HashSet<ORDEN_PEDIDO>();
            this.RECEPCION_PRODUCTO = new HashSet<RECEPCION_PRODUCTO>();
        }
    
        public decimal EMPLEADO_RUT { get; set; }
        public string EMPLEADO_RUT_DV { get; set; }
        public string EMPLEADO_NOMBRE { get; set; }
        public string EMPLEADO_DIRECCION { get; set; }
        public decimal EMPLEADO_TELEFONO { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ORDEN_PEDIDO> ORDEN_PEDIDO { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<RECEPCION_PRODUCTO> RECEPCION_PRODUCTO { get; set; }
    }
}
