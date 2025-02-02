using Microsoft.EntityFrameworkCore;
using WebApi8_CadastroTuristico.Data;
using WebApi8_CadastroTuristico.Services.Estado;
using WebApi8_CadastroTuristico.Services.PontoTuristico;

var builder = WebApplication.CreateBuilder(args);

// Configura��o do CORS
builder.Services.AddCors(options => {
    options.AddPolicy("PermitirFrontend",
        policy => {
            policy.AllowAnyOrigin() // Permite qualquer origem
                //.WithOrigins("http://localhost:5173")  // Permite uma origem espec�fica
                  .AllowAnyMethod()
                  .AllowAnyHeader()
                //.AllowCredentials() // N�O pode ser usado junto com AllowAnyOrigin()
                  ;
        });
});

// Adiciona servi�os ao container
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Servi�os da aplica��o
builder.Services.AddScoped<IEstadoInterface, EstadoService>();
builder.Services.AddScoped<IPontoTuristicoInterface, PontoTuristicoService>();

// Conex�o com o banco de dados
builder.Services.AddDbContext<AppDbContext>(options => {
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});

var app = builder.Build();

// Configura��o do pipeline HTTP
if (app.Environment.IsDevelopment()) {
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

// Ativar o CORS antes dos controllers
app.UseCors("PermitirFrontend");

app.UseAuthorization();

app.MapControllers();

app.Run();
