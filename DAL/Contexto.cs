using Microsoft.EntityFrameworkCore;
using F_NF_Negocio.Models;

namespace F_NF_Negocio.DAL
{
    public class Contexto : DbContext
    {
        public DbSet<Preguntas_Respuestas> Preguntas_Respuestas { get; set; }
        public Contexto(DbContextOptions<Contexto> options) : base(options)
        {
        }

    }
}