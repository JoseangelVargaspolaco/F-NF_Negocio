using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;


#nullable disable // Para quitar el aviso de nulls

namespace F_NF_Negocio.Models
{

    public class Preguntas
    {
        [Key]
        public int PreguntaId { get; set; }
        public string Enunciado { get; set; }
        public List<OpcionSeleccionada> OpcionesSeleccionadas { get; set; } = new List<OpcionSeleccionada>();
        
        [NotMapped]
        public List<string> Opciones { get; set; } = new List<string>();
    }

    public class OpcionSeleccionada
    {
        [Key]
        public int Id { get; set; }
        public string Opcion { get; set; }
        public bool Seleccionada { get; set; }
        public int PreguntaId { get; set; }
        public Preguntas Pregunta { get; set; }
    }
}