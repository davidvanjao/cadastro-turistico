using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace WebApi8_CadastroTuristico.Migrations
{
    /// <inheritdoc />
    public partial class NomeDaMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Estados",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Nome", "Sigla" },
                values: new object[] { "Acre", "AC" });

            migrationBuilder.UpdateData(
                table: "Estados",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Nome", "Sigla" },
                values: new object[] { "Alagoas", "AL" });

            migrationBuilder.UpdateData(
                table: "Estados",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Nome", "Sigla" },
                values: new object[] { "Amapá", "AP" });

            migrationBuilder.UpdateData(
                table: "Estados",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "Nome", "Sigla" },
                values: new object[] { "Amazonas", "AM" });

            migrationBuilder.UpdateData(
                table: "Estados",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "Nome", "Sigla" },
                values: new object[] { "Bahia", "BA" });

            migrationBuilder.UpdateData(
                table: "Estados",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "Nome", "Sigla" },
                values: new object[] { "Ceará", "CE" });

            migrationBuilder.UpdateData(
                table: "Estados",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "Nome", "Sigla" },
                values: new object[] { "Distrito Federal", "DF" });

            migrationBuilder.UpdateData(
                table: "Estados",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "Nome", "Sigla" },
                values: new object[] { "Espírito Santo", "ES" });

            migrationBuilder.UpdateData(
                table: "Estados",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "Nome", "Sigla" },
                values: new object[] { "Goiás", "GO" });

            migrationBuilder.UpdateData(
                table: "Estados",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "Nome", "Sigla" },
                values: new object[] { "Maranhão", "MA" });

            migrationBuilder.InsertData(
                table: "Estados",
                columns: new[] { "Id", "Nome", "Sigla" },
                values: new object[,]
                {
                    { 11, "Mato Grosso", "MT" },
                    { 12, "Mato Grosso do Sul", "MS" },
                    { 13, "Minas Gerais", "MG" },
                    { 14, "Pará", "PA" },
                    { 15, "Paraíba", "PB" },
                    { 16, "Paraná", "PR" },
                    { 17, "Pernambuco", "PE" },
                    { 18, "Piauí", "PI" },
                    { 19, "Rio de Janeiro", "RJ" },
                    { 20, "Rio Grande do Norte", "RN" },
                    { 21, "Rio Grande do Sul", "RS" },
                    { 22, "Rondônia", "RO" },
                    { 23, "Roraima", "RR" },
                    { 24, "Santa Catarina", "SC" },
                    { 25, "São Paulo", "SP" },
                    { 26, "Sergipe", "SE" },
                    { 27, "Tocantins", "TO" }
                });

            migrationBuilder.UpdateData(
                table: "PontosTuristicos",
                keyColumn: "Id",
                keyValue: 1,
                column: "EstadoId",
                value: 25);

            migrationBuilder.UpdateData(
                table: "PontosTuristicos",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Descricao", "EstadoId", "Localizacao", "Nome" },
                values: new object[] { "Museu que preserva a história e cultura indígena da região.", 25, "Rua Coroados, 521", "Museu Histórico e Pedagógico Índia Vanuíre" });

            migrationBuilder.UpdateData(
                table: "PontosTuristicos",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Descricao", "EstadoId", "Localizacao", "Nome" },
                values: new object[] { "Igreja matriz da cidade, com arquitetura imponente e belos vitrais.", 25, "Praça da Bandeira, s/n", "Catedral de Santo Antônio" });

            migrationBuilder.InsertData(
                table: "PontosTuristicos",
                columns: new[] { "Id", "Cidade", "DataInclusao", "Descricao", "EstadoId", "Localizacao", "Nome" },
                values: new object[,]
                {
                    { 4, "Tupã", "2025-02-01", "Parque aquático com piscinas, toboáguas e áreas de lazer.", 25, "Rodovia SP 294, km 206", "Parque Aquático Thermas dos Laranjais" },
                    { 5, "Tupã", "2025-02-01", "Lagoa cercada por natureza, ideal para passeios e piqueniques.", 25, "Rua dos Ipês, s/n", "Lagoa do Sinhozinho" },
                    { 6, "Tupã", "2025-02-01", "Principal praça da cidade, com coreto e área de convivência.", 25, "Centro", "Praça da Bandeira" },
                    { 7, "Tupã", "2025-02-01", "Antiga estação ferroviária, hoje um espaço cultural e histórico.", 25, "Rua da Estação, s/n", "Estação Ferroviária de Tupã" },
                    { 8, "Tupã", "2025-02-01", "Área de preservação ambiental com trilhas e fauna local.", 25, "Av. dos Imigrantes, 500", "Parque Ecológico Municipal" },
                    { 9, "Tupã", "2025-02-01", "Casa de espetáculos com programação cultural variada.", 25, "Rua dos Artistas, 123", "Teatro Municipal de Tupã" },
                    { 10, "Tupã", "2025-02-01", "Feira tradicional com produtos locais e gastronomia típica.", 25, "Av. Tupinambás, s/n", "Feira Livre de Tupã" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Estados",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Estados",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Estados",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "Estados",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "Estados",
                keyColumn: "Id",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "Estados",
                keyColumn: "Id",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "Estados",
                keyColumn: "Id",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "Estados",
                keyColumn: "Id",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "Estados",
                keyColumn: "Id",
                keyValue: 19);

            migrationBuilder.DeleteData(
                table: "Estados",
                keyColumn: "Id",
                keyValue: 20);

            migrationBuilder.DeleteData(
                table: "Estados",
                keyColumn: "Id",
                keyValue: 21);

            migrationBuilder.DeleteData(
                table: "Estados",
                keyColumn: "Id",
                keyValue: 22);

            migrationBuilder.DeleteData(
                table: "Estados",
                keyColumn: "Id",
                keyValue: 23);

            migrationBuilder.DeleteData(
                table: "Estados",
                keyColumn: "Id",
                keyValue: 24);

            migrationBuilder.DeleteData(
                table: "Estados",
                keyColumn: "Id",
                keyValue: 26);

            migrationBuilder.DeleteData(
                table: "Estados",
                keyColumn: "Id",
                keyValue: 27);

            migrationBuilder.DeleteData(
                table: "PontosTuristicos",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "PontosTuristicos",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "PontosTuristicos",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "PontosTuristicos",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "PontosTuristicos",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "PontosTuristicos",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "PontosTuristicos",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Estados",
                keyColumn: "Id",
                keyValue: 25);

            migrationBuilder.UpdateData(
                table: "Estados",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Nome", "Sigla" },
                values: new object[] { "São Paulo", "SP" });

            migrationBuilder.UpdateData(
                table: "Estados",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Nome", "Sigla" },
                values: new object[] { "Acre", "AC" });

            migrationBuilder.UpdateData(
                table: "Estados",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Nome", "Sigla" },
                values: new object[] { "Alagoas", "AL" });

            migrationBuilder.UpdateData(
                table: "Estados",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "Nome", "Sigla" },
                values: new object[] { "Amapá", "AP" });

            migrationBuilder.UpdateData(
                table: "Estados",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "Nome", "Sigla" },
                values: new object[] { "Amazonas", "AM" });

            migrationBuilder.UpdateData(
                table: "Estados",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "Nome", "Sigla" },
                values: new object[] { "Bahia", "BA" });

            migrationBuilder.UpdateData(
                table: "Estados",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "Nome", "Sigla" },
                values: new object[] { "Ceará", "CE" });

            migrationBuilder.UpdateData(
                table: "Estados",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "Nome", "Sigla" },
                values: new object[] { "Distrito Federal", "DF" });

            migrationBuilder.UpdateData(
                table: "Estados",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "Nome", "Sigla" },
                values: new object[] { "Espírito Santo", "ES" });

            migrationBuilder.UpdateData(
                table: "Estados",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "Nome", "Sigla" },
                values: new object[] { "Goiás", "GO" });

            migrationBuilder.UpdateData(
                table: "PontosTuristicos",
                keyColumn: "Id",
                keyValue: 1,
                column: "EstadoId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "PontosTuristicos",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Descricao", "EstadoId", "Localizacao", "Nome" },
                values: new object[] { "Museu que conta a história da cidade e região.", 1, "Rua dos Museus, 123", "Museu Histórico de Tupã" });

            migrationBuilder.UpdateData(
                table: "PontosTuristicos",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Descricao", "EstadoId", "Localizacao", "Nome" },
                values: new object[] { "Lago com pedalinhos e área para piquenique.", 1, "Av. dos Lagos, 456", "Lago Artificial" });
        }
    }
}
