using System;
namespace coreapiapp.CustomMiddleware
{
    public class ErrorEntity
    {
        public int StatucCode { get; set; }
        public string ErrorMessage { get; set; } = string.Empty;
    }

    public class AppExceptionMiddleware
    {
        private RequestDelegate _next;

        public AppExceptionMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        /// <summary>
        /// This method will be invoked by the RequestDelegate
        /// In this HTTP Pipeline when this class is registered as
        /// Middleware
        /// The InvokeAsync method will keep moving to Next Middleware
        /// till the 'EndPoint' middleware is not reached
        /// </summary>
        /// <param name=""></param>
        /// <returns></returns>
        public async Task InvokeAsync(HttpContext context)
        {
            // YOU CAN WRITE LOGIC FOR DATABASE LOGGING
            try
            {
                // If there is not exception, then Move to Next
                // middleware in the Pipeline i.e. HttpContext
                await _next(context);
            }
            catch (Exception ex)
            {
                // otherwise execute a logic for handling an exception and generating
                // response

                // 1. Create a Ststus code
                context.Response.StatusCode = 500;
                // 2. Read an Exception Message
                string errMessage = ex.Message;

                // 3. CReate an instance of ErrorEntity and storeb error data in it
                ErrorEntity entity = new ErrorEntity()
                {
                    StatucCode = context.Response.StatusCode,
                    ErrorMessage = errMessage
                };
                // 4. Write the Response in JSOn form (Added in .NET 6)
                await context.Response.WriteAsJsonAsync(entity);
            }
        }
    }


    // Create a class that will register the AppExceptionMiddleware as the Custom Middleware
    // This will be a Class that will contains a Custom Extension Method
    // to register AppExceptionMiddleware class as Custom Middleware

    public static class ApplicationMiddlewareExtensions
    {
        /// <summary>
        /// The Extension Method that will be sued to Register the AppExceptionMiddleware
        /// class as Middleware
        /// </summary>
        /// <param name="builder"></param>
        public static void UseExceptionHandlerMiddleware(this IApplicationBuilder builder)
        {
            // The 'T' parameter is the class that has
            // Constructor taht injected with 'RequestDelegate'
            builder.UseMiddleware<AppExceptionMiddleware>();
        }
    }
}

