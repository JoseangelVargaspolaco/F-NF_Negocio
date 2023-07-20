using Microsoft.EntityFrameworkCore;
using F_NF_Negocio.Models;

namespace F_NF_Negocio.DAL
{
    public class Contexto : DbContext
    {
        public DbSet<Preguntas> Preguntas_Respuestas { get; set; }
        public DbSet<OpcionSeleccionada> Respuestas { get; set; }
        public Contexto(DbContextOptions<Contexto> options) : base(options)
        {
        }

    }
}