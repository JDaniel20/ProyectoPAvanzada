//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace PrograAvanzadaP.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class ListaReceta
    {
        public int IdListaReceta { get; set; }
        public int IdReceta { get; set; }
        public int IdCurso { get; set; }
    
        public virtual Curso Curso { get; set; }
        public virtual Receta Receta { get; set; }
    }
}
