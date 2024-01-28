namespace WebApplication1.Properties
{
    public class Middleware
    {
        //Para desbloquear a Requisição cross-origin
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseCors(x => x
                           .AllowAnyOrigin()
                                          .AllowAnyMethod()
                                                         .AllowAnyHeader());
        }
    }
}
