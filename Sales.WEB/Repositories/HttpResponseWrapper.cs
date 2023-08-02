using System.Net;

namespace Sales.WEB.Repositories
{
    // Tls : Envoltorio de respuesta Http
    public class HttpResponseWrapper<T>
    {
        public HttpResponseWrapper(T? response, bool error, HttpResponseMessage httpResponseMessage)
        {
            Response = response;
            Error = error;
            HttpResponseMessage = httpResponseMessage;
        }

        public bool Error { get; set; }

        public T? Response { get; set; }

        public HttpResponseMessage HttpResponseMessage { get; set; }

        public async Task<string?> GetErrorMessageAsync()
        {
            if (!Error)
            {
                return null;
            }

            var StatusCode = HttpResponseMessage.StatusCode;
            if (StatusCode == HttpStatusCode.NotFound)
            {
                return "Recurso no encontrado";
            }
            else if (StatusCode == HttpStatusCode.BadRequest)
            {
                return await HttpResponseMessage.Content.ReadAsStringAsync();
            }
            else if (StatusCode == HttpStatusCode.Unauthorized)
            {
                return "Tienes que logearte para hacer esta operación";
            }
            else if (StatusCode == HttpStatusCode.Forbidden)
            {
                return "No tienes permisos para hacer esta operación";
            }

            return "Ha ocurrido un error inesperado";
        }
    }

}
