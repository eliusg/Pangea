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
    
    public partial class Trabajador
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Trabajador()
        {
            this.Ausencia = new HashSet<Ausencia>();
            this.Solicitud_Ausencia = new HashSet<Solicitud_Ausencia>();
            this.TrabajadorDestino = new HashSet<TrabajadorDestino>();
            this.Turno = new HashSet<Turno>();
        }
    
        public int id { get; set; }
        public int id_rol { get; set; }
        public int id_sucursal { get; set; }
        public string nombre { get; set; }
        public string apellido1 { get; set; }
        public string apellido2 { get; set; }
        public string telefono { get; set; }
        public string telefono2 { get; set; }
        public bool habilitado { get; set; }
        public int id_trabajador_crea { get; set; }
        public System.DateTime fecha_crea { get; set; }
        public int id_trabajador_modif { get; set; }
        public System.DateTime fecha_modif { get; set; }
        public int id_usuario { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Ausencia> Ausencia { get; set; }
        public virtual Rol Rol { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Solicitud_Ausencia> Solicitud_Ausencia { get; set; }
        public virtual Sucursal Sucursal { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TrabajadorDestino> TrabajadorDestino { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Turno> Turno { get; set; }
    }
}
