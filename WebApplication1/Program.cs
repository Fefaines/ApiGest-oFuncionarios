using Microsoft.EntityFrameworkCore;
using WebApplication1.DataContext;
using WebApplication1.Service.FuncionarioService;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//Quando for feita uma injeção de dependência do tipo "IFuncionarioInterface", significa que eu quero utilizar os métodos do "FuncionarioService"
builder.Services.AddScoped<IFuncionarioInterface, FuncionarioService>();

//Estamos dizendo ao "options" que vamos usar o banco de dados SQL Server, e que a string de conexão está vindo do arquivo "appsettings.json (Configuration= appsettings.json)"
builder.Services.AddDbContext<ApplicationDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
