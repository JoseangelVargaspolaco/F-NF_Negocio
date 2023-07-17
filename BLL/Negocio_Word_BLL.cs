using Microsoft.EntityFrameworkCore;
using F_NF_Negocio.Models;
using F_NF_Negocio.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

#nullable disable // Para quitar el aviso de nulls

namespace F_NF_Negocio.BLL
{
    public class Negocio_Word_BLL // BLL Para Articulo
    {
        private Contexto contexto;

        public Negocio_Word_BLL(Contexto _contexto)
        {
            contexto = _contexto;
        }

        private bool Existe(int id)
        {
            bool existe = false;

            try
            {
                existe = contexto.Preguntas_Respuestas.Any(c => c.PreguntaR_ID == id);
            }
            catch (Exception)
            {
                throw;
            }
            return existe;
        }

        public bool Guardar(Preguntas_Respuestas preguntas_respuestas)
        {

            if (!Existe(preguntas_respuestas.PreguntaR_ID))
                return Insertar(preguntas_respuestas);
            else
                return Modificar(preguntas_respuestas);
        }

        private bool Insertar(Preguntas_Respuestas preguntas_respuestas)
        {
            bool Insertado = false;

            try
            {
                if (contexto.Preguntas_Respuestas.Add(preguntas_respuestas) != null)
                {
                    Insertado = contexto.SaveChanges() > 0;
                }
            }
            catch (Exception)
            {
                throw;
            }
            return Insertado;
        }

        private bool Modificar(Preguntas_Respuestas preguntas_respuestas)
        {
            bool Insertado = false;

            try
            {
                contexto.Entry(preguntas_respuestas).State = EntityState.Modified;
                Insertado = contexto.SaveChanges() > 0;
            }
            catch (Exception)
            {
                throw;
            }
            return Insertado;
        }

        public Preguntas_Respuestas Buscar(int id)
        {
            return contexto.Preguntas_Respuestas
                .Where(a => a.PreguntaR_ID == id == true && a.Estado == true)
                .SingleOrDefault();
        }

        public bool Eliminar(int id)
        {
            bool Eliminado = false;

            try
            {
                var pregunta_R = Buscar(id);

                if (pregunta_R != null)
                {
                    pregunta_R.Estado = false;
                    Eliminado = contexto.SaveChanges() > 0;
                }
            }
            catch (Exception)
            {
                throw;
            }
            return Eliminado;
        }

        public List<Preguntas_Respuestas> GetList(Expression<Func<Preguntas_Respuestas, bool>> articulo)
        {
            List<Preguntas_Respuestas> Lista = new List<Preguntas_Respuestas>();
            try
            {
                Lista = contexto.Preguntas_Respuestas
                .Where(a => a.Estado == true)
                .Where(articulo)
                .AsNoTracking()
                .ToList();
            }
            catch (Exception)
            {
                throw;
            }
            return Lista;
        }
    }
}