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
    
    public partial class Libros
    {
        public Libros()
        {
            this.Venta_Detalle = new HashSet<Venta_Detalle>();
        }
    
        public int LibroID { get; set; }
        public string Titulo { get; set; }
        public string ISBN { get; set; }
        public Nullable<int> CategoriaID { get; set; }
        public Nullable<int> AutorID { get; set; }
        public Nullable<int> EditorialID { get; set; }
        public Nullable<int> LenguajeID { get; set; }
        public Nullable<int> Stock { get; set; }
        public string Tipo { get; set; }
        public Nullable<decimal> Precio { get; set; }
    
        public virtual Autores Autores { get; set; }
        public virtual Categorias Categorias { get; set; }
        public virtual Editoriales Editoriales { get; set; }
        public virtual Lenguajes Lenguajes { get; set; }
        public virtual ICollection<Venta_Detalle> Venta_Detalle { get; set; }
    }
}
