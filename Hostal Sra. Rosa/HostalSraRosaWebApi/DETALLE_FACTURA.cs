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
    
    public partial class DETALLE_FACTURA
    {
        public decimal DETALLE_FACTURA_ID { get; set; }
        public decimal DETALLE_FACTURA_PRECIO { get; set; }
        public decimal DETALLE_FACTURA_ESTADIA { get; set; }
        public decimal FACTURA_ID { get; set; }
        public decimal TIPO_MENU_ID { get; set; }
    
        public virtual FACTURA FACTURA { get; set; }
        public virtual TIPO_MENU TIPO_MENU { get; set; }
        public virtual HABITACION HABITACION { get; set; }
    }
}
