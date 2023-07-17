using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;


#nullable disable // Para quitar el aviso de nulls

namespace F_NF_Negocio.Models
{
    public class Preguntas_Respuestas // Entidad Articulo
    {
        [Key]
        public int PreguntaR_ID { get; set; }
        public string Preguntas { get; set; }
        public bool Respuestas { get; set; }
        public string Explicacion { get; set; }
        public bool Estado { get; set; } = true;
    }
}