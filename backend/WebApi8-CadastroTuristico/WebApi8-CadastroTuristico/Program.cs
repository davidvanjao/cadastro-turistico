//arquivo que inicia o projeto

using Microsoft.EntityFrameworkCore;
using WebApi8_CadastroTuristico.Data;
using WebApi8_CadastroTuristico.Services.Estado;
using WebApi8_CadastroTuristico.Services.PontoTuristico;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//informa que os metodos de interface estao implementados dentro de servicos
builder.Services.AddScoped<IEstadoInterface, EstadoService>();
builder.Services.AddScoped<IPontoTuristicoInterface, PontoTuristicoService>(); //lembrar de ligar service:interface

//conexao com o banco. Entra no epsettings e pega as configuracoes do banco.
builder.Services.AddDbContext<AppDbContext>(options => {
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
