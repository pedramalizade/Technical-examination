using App.Domain.Core.Confrig;

namespace App.EndPoints.Api.Car.Middelware
{

    public class ApiKeyMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly SettingsSite _siteSettings;


        public ApiKeyMiddleware(RequestDelegate next, SettingsSite siteSettings)
        {
            _next = next;
            _siteSettings = siteSettings;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            var path = context.Request.Path.ToString().ToLower();
            if (path.StartsWith("/model"))
            {

                if (!context.Request.Headers.TryGetValue("ApiKey", out var apiKey) || string.IsNullOrEmpty(apiKey))
                {

                    await context.Response.WriteAsync("کلید نادرست است.");
                    return;

                }
                if (apiKey != _siteSettings.ApiKey)
                {
                    await context.Response.WriteAsync("کلید ارسال نشده است.");
                    return;
                }

            }
            await _next(context);
        }
    }
}
