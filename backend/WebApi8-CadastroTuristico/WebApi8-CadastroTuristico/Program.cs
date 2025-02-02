using Microsoft.EntityFrameworkCore;
using WebApi8_CadastroTuristico.Data;
using WebApi8_CadastroTuristico.Services.Estado;
using WebApi8_CadastroTuristico.Services.PontoTuristico;

var builder = WebApplication.CreateBuilder(args);

// Configuração do CORS
builder.Services.AddCors(options => {
    options.AddPolicy("PermitirFrontend",
        policy => {
            policy.AllowAnyOrigin() // Permite qualquer origem
                //.WithOrigins("http://localhost:5173")  // Permite uma origem específica
                  .AllowAnyMethod()
                  .AllowAnyHeader()
                //.AllowCredentials() // NÃO pode ser usado junto com AllowAnyOrigin()
                  ;
        });
});

// Adiciona serviços ao container
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Serviços da aplicação
builder.Services.AddScoped<IEstadoInterface, EstadoService>();
builder.Services.AddScoped<IPontoTuristicoInterface, PontoTuristicoService>();

// Conexão com o banco de dados
builder.Services.AddDbContext<AppDbContext>(options => {
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});

var app = builder.Build();

// Configuração do pipeline HTTP
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
