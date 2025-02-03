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

        //usado para popular as tabelas
        protected override void OnModelCreating(ModelBuilder modelBuilder) {
            base.OnModelCreating(modelBuilder);

            //Populando a tabela Estados
            modelBuilder.Entity<EstadoModel>().HasData(
                new EstadoModel { Id = 1, Nome = "Acre", Sigla = "AC" },
                new EstadoModel { Id = 2, Nome = "Alagoas", Sigla = "AL" },
                new EstadoModel { Id = 3, Nome = "Amapá", Sigla = "AP" },
                new EstadoModel { Id = 4, Nome = "Amazonas", Sigla = "AM" },
                new EstadoModel { Id = 5, Nome = "Bahia", Sigla = "BA" },
                new EstadoModel { Id = 6, Nome = "Ceará", Sigla = "CE" },
                new EstadoModel { Id = 7, Nome = "Distrito Federal", Sigla = "DF" },
                new EstadoModel { Id = 8, Nome = "Espírito Santo", Sigla = "ES" },
                new EstadoModel { Id = 9, Nome = "Goiás", Sigla = "GO" },
                new EstadoModel { Id = 10, Nome = "Maranhão", Sigla = "MA" },
                new EstadoModel { Id = 11, Nome = "Mato Grosso", Sigla = "MT" },
                new EstadoModel { Id = 12, Nome = "Mato Grosso do Sul", Sigla = "MS" },
                new EstadoModel { Id = 13, Nome = "Minas Gerais", Sigla = "MG" },
                new EstadoModel { Id = 14, Nome = "Pará", Sigla = "PA" },
                new EstadoModel { Id = 15, Nome = "Paraíba", Sigla = "PB" },
                new EstadoModel { Id = 16, Nome = "Paraná", Sigla = "PR" },
                new EstadoModel { Id = 17, Nome = "Pernambuco", Sigla = "PE" },
                new EstadoModel { Id = 18, Nome = "Piauí", Sigla = "PI" },
                new EstadoModel { Id = 19, Nome = "Rio de Janeiro", Sigla = "RJ" },
                new EstadoModel { Id = 20, Nome = "Rio Grande do Norte", Sigla = "RN" },
                new EstadoModel { Id = 21, Nome = "Rio Grande do Sul", Sigla = "RS" },
                new EstadoModel { Id = 22, Nome = "Rondônia", Sigla = "RO" },
                new EstadoModel { Id = 23, Nome = "Roraima", Sigla = "RR" },
                new EstadoModel { Id = 24, Nome = "Santa Catarina", Sigla = "SC" },
                new EstadoModel { Id = 25, Nome = "São Paulo", Sigla = "SP" },
                new EstadoModel { Id = 26, Nome = "Sergipe", Sigla = "SE" },
                new EstadoModel { Id = 27, Nome = "Tocantins", Sigla = "TO" }
            );

            //Populando a tabela PontosTuristicos
            modelBuilder.Entity<PontoTuristicoModel>().HasData(
                new PontoTuristicoModel { Id = 1, Nome = "Parque do Povo", Descricao = "Um parque urbano com áreas verdes e quadras esportivas.", Localizacao = "Av. Dom Pedro I, 1000", Cidade = "Tupã", EstadoId = 25, DataInclusao = "2025-02-01" },
                new PontoTuristicoModel { Id = 2, Nome = "Museu Histórico e Pedagógico Índia Vanuíre", Descricao = "Museu que preserva a história e cultura indígena da região.", Localizacao = "Rua Coroados, 521", Cidade = "Tupã", EstadoId = 25, DataInclusao = "2025-02-01" },
                new PontoTuristicoModel { Id = 3, Nome = "Catedral de Santo Antônio", Descricao = "Igreja matriz da cidade, com arquitetura imponente e belos vitrais.", Localizacao = "Praça da Bandeira, s/n", Cidade = "Tupã", EstadoId = 25, DataInclusao = "2025-02-01" },
                new PontoTuristicoModel { Id = 4, Nome = "Parque Aquático Thermas dos Laranjais", Descricao = "Parque aquático com piscinas, toboáguas e áreas de lazer.", Localizacao = "Rodovia SP 294, km 206", Cidade = "Tupã", EstadoId = 25, DataInclusao = "2025-02-01" },
                new PontoTuristicoModel { Id = 5, Nome = "Lagoa do Sinhozinho", Descricao = "Lagoa cercada por natureza, ideal para passeios e piqueniques.", Localizacao = "Rua dos Ipês, s/n", Cidade = "Tupã", EstadoId = 25, DataInclusao = "2025-02-01" },
                new PontoTuristicoModel { Id = 6, Nome = "Praça da Bandeira", Descricao = "Principal praça da cidade, com coreto e área de convivência.", Localizacao = "Centro", Cidade = "Tupã", EstadoId = 25, DataInclusao = "2025-02-01" },
                new PontoTuristicoModel { Id = 7, Nome = "Estação Ferroviária de Tupã", Descricao = "Antiga estação ferroviária, hoje um espaço cultural e histórico.", Localizacao = "Rua da Estação, s/n", Cidade = "Tupã", EstadoId = 25, DataInclusao = "2025-02-01" },
                new PontoTuristicoModel { Id = 8, Nome = "Parque Ecológico Municipal", Descricao = "Área de preservação ambiental com trilhas e fauna local.", Localizacao = "Av. dos Imigrantes, 500", Cidade = "Tupã", EstadoId = 25, DataInclusao = "2025-02-01" },
                new PontoTuristicoModel { Id = 9, Nome = "Teatro Municipal de Tupã", Descricao = "Casa de espetáculos com programação cultural variada.", Localizacao = "Rua dos Artistas, 123", Cidade = "Tupã", EstadoId = 25, DataInclusao = "2025-02-01" },
                new PontoTuristicoModel { Id = 10, Nome = "Feira Livre de Tupã", Descricao = "Feira tradicional com produtos locais e gastronomia típica.", Localizacao = "Av. Tupinambás, s/n", Cidade = "Tupã", EstadoId = 25, DataInclusao = "2025-02-01" }
            );
        }

    }

}
