//------------------------------------------------------------------------------
// <auto-generated>
//    Este código se generó a partir de una plantilla.
//
//    Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//    Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace biblioteca.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Autores
    {
        public Autores()
        {
            this.Libros = new HashSet<Libros>();
        }
    
        public int AutorID { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
    
        public virtual ICollection<Libros> Libros { get; set; }
    }
}
