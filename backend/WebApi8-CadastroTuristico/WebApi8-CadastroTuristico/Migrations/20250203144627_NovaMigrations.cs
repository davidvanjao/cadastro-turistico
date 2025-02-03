using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace WebApi8_CadastroTuristico.Migrations
{
    /// <inheritdoc />
    public partial class NovaMigrations : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Sigla",
                table: "Estados",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(1)");

            migrationBuilder.InsertData(
                table: "Estados",
                columns: new[] { "Id", "Nome", "Sigla" },
                values: new object[,]
                {
                    { 1, "São Paulo", "SP" },
                    { 2, "Acre", "AC" },
                    { 3, "Alagoas", "AL" },
                    { 4, "Amapá", "AP" },
                    { 5, "Amazonas", "AM" },
                    { 6, "Bahia", "BA" },
                    { 7, "Ceará", "CE" },
                    { 8, "Distrito Federal", "DF" },
                    { 9, "Espírito Santo", "ES" },
                    { 10, "Goiás", "GO" }
                });

            migrationBuilder.InsertData(
                table: "PontosTuristicos",
                columns: new[] { "Id", "Cidade", "DataInclusao", "Descricao", "EstadoId", "Localizacao", "Nome" },
                values: new object[,]
                {
                    { 1, "Tupã", "2025-02-01", "Um parque urbano com áreas verdes e quadras esportivas.", 1, "Av. Dom Pedro I, 1000", "Parque do Povo" },
                    { 2, "Tupã", "2025-02-01", "Museu que conta a história da cidade e região.", 1, "Rua dos Museus, 123", "Museu Histórico de Tupã" },
                    { 3, "Tupã", "2025-02-01", "Lago com pedalinhos e área para piquenique.", 1, "Av. dos Lagos, 456", "Lago Artificial" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Estados",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Estados",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Estados",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Estados",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Estados",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Estados",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Estados",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Estados",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Estados",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "PontosTuristicos",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "PontosTuristicos",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "PontosTuristicos",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Estados",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.AlterColumn<string>(
                name: "Sigla",
                table: "Estados",
                type: "nvarchar(1)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");
        }
    }
}
