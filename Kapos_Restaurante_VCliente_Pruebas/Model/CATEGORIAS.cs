//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Kapos_Restaurante_VCliente_Pruebas.Model
{
    using System;
    using System.Collections.Generic;
    
    public partial class CATEGORIAS
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public CATEGORIAS()
        {
            this.ELEMENTOS = new HashSet<ELEMENTOS>();
        }
    
        public int IdCategoria { get; set; }
        public string NombreCategoria { get; set; }
        public string ImagenCategoriaURL { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ELEMENTOS> ELEMENTOS { get; set; }
    }
}
