using ItAcademy.Application.Infrastructure.Errors.CustomExceptions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Net;


namespace ItAcademy.Application.Infrastructure.Errors
{
    public class ApiErrors : ProblemDetails
    {
        private readonly HttpContext _context;
        private readonly Exception _exception;
        public LogLevel LogLevel { get; set; }
        public string TraceId
        {
            get
            {
                if (Extensions.TryGetValue("TraceId", out var traceId))
                    return traceId.ToString();
                return null;
            }
            set => Extensions["TraceId"] = value;
        }
        public ApiErrors(HttpContext context, Exception exception)
        {
            _context = context;
            _exception = exception;
            TraceId = context.TraceIdentifier;
            Status = (int)HttpStatusCode.InternalServerError;
            Title = exception.Message;
            LogLevel = LogLevel.Error;
            Instance = context.Request.Path;
            HandleException((dynamic)exception);
        }
        private void HandleException(DoesntExistsException ex)
        {
            Status = (int)HttpStatusCode.NotFound;
            Title = ex.Message;
            LogLevel = LogLevel.Error;
        }
        private void HandleException(AlreadyExistsException ex)
        {
            Status = (int)HttpStatusCode.Conflict;
            Title = ex.Message;
            LogLevel = LogLevel.Error;
        }
        private void HandleException(IncorrectInfoException ex)
        {
            Status = (int)HttpStatusCode.Forbidden;
            Title = ex.Message;
            LogLevel = LogLevel.Error;
        }
        private void HandleException(DoesNotHaveAccessException ex)
        {
            Status = (int)HttpStatusCode.Unauthorized;
            Title = ex.Message;
            LogLevel = LogLevel.Error;
        }
        private void HandleException(ImageNotUploadedException ex)
        {
            Status = (int)HttpStatusCode.UnprocessableEntity;
            Title = ex.Message;
            LogLevel = LogLevel.Error;
        }
        //private void HandleException(SizeException ex)
        //{
        //    Status = (int)HttpStatusCode.BadRequest;
        //    Title = ex.Message;
        //    LogLevel = LogLevel.Error;
        //}
        private void HandleException(SaveToDbException ex)
        {
            Status = (int)HttpStatusCode.InternalServerError;
            Title = ex.Message;
            LogLevel = LogLevel.Error;
        }
        private void HandleException(Exception ex)
        {
            Status = (int)HttpStatusCode.InternalServerError;
            Title = ex.Message;
            LogLevel = LogLevel.Error;
        }
    }
}
