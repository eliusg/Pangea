//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace PangeaProyecto.Datos
{
    using System;
    using System.Collections.Generic;
    
    public partial class Destino
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Destino()
        {
            this.TrabajadorDestino = new HashSet<TrabajadorDestino>();
        }
    
        public int id { get; set; }
        public string nombre { get; set; }
        public string descripcion { get; set; }
        public bool habilitado { get; set; }
        public int id_trabajador_crea { get; set; }
        public System.DateTime fecha_crea { get; set; }
        public int id_trabajador_modif { get; set; }
        public System.DateTime fecha_modif { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TrabajadorDestino> TrabajadorDestino { get; set; }
    }
}
