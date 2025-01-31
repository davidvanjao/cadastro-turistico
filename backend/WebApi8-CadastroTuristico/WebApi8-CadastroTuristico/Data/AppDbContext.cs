using Microsoft.EntityFrameworkCore;
using WebApi8_CadastroTuristico.Models;

namespace WebApi8_CadastroTuristico.Data {
    public class AppDbContext : DbContext { //DbContext vem herdado dos frameworks

        //construtor recebe opcoes de conexao. Optios recebe as informacoes. Configuracoes iniciais
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options){

        }

        //criacao da tabela. Estado model e a forma para a criacao da tabela. > Nome da tabela;
        public DbSet<EstadoModel> Estados { get; set; }
        public DbSet<PontoTuristicoModel> PontosTuristicos { get; set; }
    }
}
