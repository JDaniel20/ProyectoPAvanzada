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
    
    public partial class VistaCursosActivo
    {
        public int IdCurso { get; set; }
        public string NombreCurso { get; set; }
        public string ProfesorAsignado { get; set; }
        public string Hora { get; set; }
        public string Dia { get; set; }
        public System.DateTime FechaInicio { get; set; }
        public System.DateTime FechaFin { get; set; }
    }
}