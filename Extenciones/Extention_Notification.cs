using Microsoft.JSInterop;
namespace F_NF_Negocio.Extenciones
{
    public static class Extention_Notificacion
    {
        public static Task MostrarMensaje(this IJSRuntime js, string titulo, string mensaje, TipoMensajeSweetAlert tipoMensajeSweetAlert)
        {
            //Convertir de ValueTask a Task
            Task task = Task.FromResult(js.InvokeAsync<object>("Swal.fire", titulo, mensaje, tipoMensajeSweetAlert.ToString()));
            //Returnando el Task
            return task;
        }
    }
    public enum TipoMensajeSweetAlert
    {
        question, warning, error, success, info
    }
}