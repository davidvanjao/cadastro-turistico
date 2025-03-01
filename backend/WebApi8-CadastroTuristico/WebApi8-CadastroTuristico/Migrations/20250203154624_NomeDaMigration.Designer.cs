﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using WebApi8_CadastroTuristico.Data;

#nullable disable

namespace WebApi8_CadastroTuristico.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20250203154624_NomeDaMigration")]
    partial class NomeDaMigration
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("WebApi8_CadastroTuristico.Models.EstadoModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Sigla")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Estados");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Nome = "Acre",
                            Sigla = "AC"
                        },
                        new
                        {
                            Id = 2,
                            Nome = "Alagoas",
                            Sigla = "AL"
                        },
                        new
                        {
                            Id = 3,
                            Nome = "Amapá",
                            Sigla = "AP"
                        },
                        new
                        {
                            Id = 4,
                            Nome = "Amazonas",
                            Sigla = "AM"
                        },
                        new
                        {
                            Id = 5,
                            Nome = "Bahia",
                            Sigla = "BA"
                        },
                        new
                        {
                            Id = 6,
                            Nome = "Ceará",
                            Sigla = "CE"
                        },
                        new
                        {
                            Id = 7,
                            Nome = "Distrito Federal",
                            Sigla = "DF"
                        },
                        new
                        {
                            Id = 8,
                            Nome = "Espírito Santo",
                            Sigla = "ES"
                        },
                        new
                        {
                            Id = 9,
                            Nome = "Goiás",
                            Sigla = "GO"
                        },
                        new
                        {
                            Id = 10,
                            Nome = "Maranhão",
                            Sigla = "MA"
                        },
                        new
                        {
                            Id = 11,
                            Nome = "Mato Grosso",
                            Sigla = "MT"
                        },
                        new
                        {
                            Id = 12,
                            Nome = "Mato Grosso do Sul",
                            Sigla = "MS"
                        },
                        new
                        {
                            Id = 13,
                            Nome = "Minas Gerais",
                            Sigla = "MG"
                        },
                        new
                        {
                            Id = 14,
                            Nome = "Pará",
                            Sigla = "PA"
                        },
                        new
                        {
                            Id = 15,
                            Nome = "Paraíba",
                            Sigla = "PB"
                        },
                        new
                        {
                            Id = 16,
                            Nome = "Paraná",
                            Sigla = "PR"
                        },
                        new
                        {
                            Id = 17,
                            Nome = "Pernambuco",
                            Sigla = "PE"
                        },
                        new
                        {
                            Id = 18,
                            Nome = "Piauí",
                            Sigla = "PI"
                        },
                        new
                        {
                            Id = 19,
                            Nome = "Rio de Janeiro",
                            Sigla = "RJ"
                        },
                        new
                        {
                            Id = 20,
                            Nome = "Rio Grande do Norte",
                            Sigla = "RN"
                        },
                        new
                        {
                            Id = 21,
                            Nome = "Rio Grande do Sul",
                            Sigla = "RS"
                        },
                        new
                        {
                            Id = 22,
                            Nome = "Rondônia",
                            Sigla = "RO"
                        },
                        new
                        {
                            Id = 23,
                            Nome = "Roraima",
                            Sigla = "RR"
                        },
                        new
                        {
                            Id = 24,
                            Nome = "Santa Catarina",
                            Sigla = "SC"
                        },
                        new
                        {
                            Id = 25,
                            Nome = "São Paulo",
                            Sigla = "SP"
                        },
                        new
                        {
                            Id = 26,
                            Nome = "Sergipe",
                            Sigla = "SE"
                        },
                        new
                        {
                            Id = 27,
                            Nome = "Tocantins",
                            Sigla = "TO"
                        });
                });

            modelBuilder.Entity("WebApi8_CadastroTuristico.Models.PontoTuristicoModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Cidade")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("DataInclusao")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Descricao")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("EstadoId")
                        .HasColumnType("int");

                    b.Property<string>("Localizacao")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("EstadoId");

                    b.ToTable("PontosTuristicos");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Cidade = "Tupã",
                            DataInclusao = "2025-02-01",
                            Descricao = "Um parque urbano com áreas verdes e quadras esportivas.",
                            EstadoId = 25,
                            Localizacao = "Av. Dom Pedro I, 1000",
                            Nome = "Parque do Povo"
                        },
                        new
                        {
                            Id = 2,
                            Cidade = "Tupã",
                            DataInclusao = "2025-02-01",
                            Descricao = "Museu que preserva a história e cultura indígena da região.",
                            EstadoId = 25,
                            Localizacao = "Rua Coroados, 521",
                            Nome = "Museu Histórico e Pedagógico Índia Vanuíre"
                        },
                        new
                        {
                            Id = 3,
                            Cidade = "Tupã",
                            DataInclusao = "2025-02-01",
                            Descricao = "Igreja matriz da cidade, com arquitetura imponente e belos vitrais.",
                            EstadoId = 25,
                            Localizacao = "Praça da Bandeira, s/n",
                            Nome = "Catedral de Santo Antônio"
                        },
                        new
                        {
                            Id = 4,
                            Cidade = "Tupã",
                            DataInclusao = "2025-02-01",
                            Descricao = "Parque aquático com piscinas, toboáguas e áreas de lazer.",
                            EstadoId = 25,
                            Localizacao = "Rodovia SP 294, km 206",
                            Nome = "Parque Aquático Thermas dos Laranjais"
                        },
                        new
                        {
                            Id = 5,
                            Cidade = "Tupã",
                            DataInclusao = "2025-02-01",
                            Descricao = "Lagoa cercada por natureza, ideal para passeios e piqueniques.",
                            EstadoId = 25,
                            Localizacao = "Rua dos Ipês, s/n",
                            Nome = "Lagoa do Sinhozinho"
                        },
                        new
                        {
                            Id = 6,
                            Cidade = "Tupã",
                            DataInclusao = "2025-02-01",
                            Descricao = "Principal praça da cidade, com coreto e área de convivência.",
                            EstadoId = 25,
                            Localizacao = "Centro",
                            Nome = "Praça da Bandeira"
                        },
                        new
                        {
                            Id = 7,
                            Cidade = "Tupã",
                            DataInclusao = "2025-02-01",
                            Descricao = "Antiga estação ferroviária, hoje um espaço cultural e histórico.",
                            EstadoId = 25,
                            Localizacao = "Rua da Estação, s/n",
                            Nome = "Estação Ferroviária de Tupã"
                        },
                        new
                        {
                            Id = 8,
                            Cidade = "Tupã",
                            DataInclusao = "2025-02-01",
                            Descricao = "Área de preservação ambiental com trilhas e fauna local.",
                            EstadoId = 25,
                            Localizacao = "Av. dos Imigrantes, 500",
                            Nome = "Parque Ecológico Municipal"
                        },
                        new
                        {
                            Id = 9,
                            Cidade = "Tupã",
                            DataInclusao = "2025-02-01",
                            Descricao = "Casa de espetáculos com programação cultural variada.",
                            EstadoId = 25,
                            Localizacao = "Rua dos Artistas, 123",
                            Nome = "Teatro Municipal de Tupã"
                        },
                        new
                        {
                            Id = 10,
                            Cidade = "Tupã",
                            DataInclusao = "2025-02-01",
                            Descricao = "Feira tradicional com produtos locais e gastronomia típica.",
                            EstadoId = 25,
                            Localizacao = "Av. Tupinambás, s/n",
                            Nome = "Feira Livre de Tupã"
                        });
                });

            modelBuilder.Entity("WebApi8_CadastroTuristico.Models.PontoTuristicoModel", b =>
                {
                    b.HasOne("WebApi8_CadastroTuristico.Models.EstadoModel", "Estado")
                        .WithMany("PontosTuristicos")
                        .HasForeignKey("EstadoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Estado");
                });

            modelBuilder.Entity("WebApi8_CadastroTuristico.Models.EstadoModel", b =>
                {
                    b.Navigation("PontosTuristicos");
                });
#pragma warning restore 612, 618
        }
    }
}
