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
    
    public partial class TIPO_HABITACION
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public TIPO_HABITACION()
        {
            this.HABITACION = new HashSet<HABITACION>();
        }
    
        public decimal TIPO_HABITACION_ID { get; set; }
        public string TIPO_HABITACION_NOMBRE { get; set; }
        public decimal TIPO_HABITACION_VALOR { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<HABITACION> HABITACION { get; set; }
    }
}
