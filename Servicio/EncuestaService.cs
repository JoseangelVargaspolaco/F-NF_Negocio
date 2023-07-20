using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using F_NF_Negocio.Models;
using F_NF_Negocio.DAL;

namespace F_NF_Negocio.Servicio;
public interface IEncuestaService
{
    Task GuardarRespuestas(List<Preguntas> preguntas);
}

public class EncuestaService : IEncuestaService
{
    private readonly Contexto _dbContext;

    public EncuestaService(Contexto dbContext)
    {
        _dbContext = dbContext;
    }


    public async Task GuardarRespuestas(List<Preguntas> preguntas)
    {
        foreach (var pregunta in preguntas)
        {
            if (pregunta.OpcionesSeleccionadas.Count > 0)
            {
                // Crear una nueva entidad para guardar la pregunta
                var entidadPregunta = new Preguntas
                {
                    PreguntaId = pregunta.PreguntaId,
                    Enunciado = pregunta.Enunciado
                };

                // Agregar la entidad al contexto y guardar en la base de datos
                await _dbContext.Preguntas_Respuestas.AddAsync(entidadPregunta);
                await _dbContext.SaveChangesAsync();

                // Agregar las respuestas relacionadas con la pregunta
                foreach (var respuesta in pregunta.OpcionesSeleccionadas)
                {
                    var entidadRespuesta = new OpcionSeleccionada
                    {
                        Opcion = respuesta.Opcion,
                        PreguntaId = entidadPregunta.PreguntaId
                    };
                    await _dbContext.Respuestas.AddAsync(entidadRespuesta);
                }

                // Guardar los cambios en las respuestas
                await _dbContext.SaveChangesAsync();
            }
        }
    }
}
