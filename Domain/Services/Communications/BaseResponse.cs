using System;
namespace PosiPrice.API.Domain.Services.Communications
{
    // Si piden un recurso proporciona el recurso sino manda mensaje de error (STATUS)
    public abstract class BaseResponse<T>
    {
        public bool Success { get; set; }
        //no cualquiera modifica el mensaje
        public string Message { get; protected set; }
        public T Resource { get; set; }
        // =)
        public BaseResponse(T resource)
        {
            Resource = resource;
            Success = true;
            Message = string.Empty;
        }
        // =(
        public BaseResponse(string message)
        {
            Success = false;
            Message = message;
        }
    }
}