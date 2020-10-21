using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Miguel_P1_AP2.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Articulos",
                columns: table => new
                {
                    ArticuloId = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    DepartamentoId = table.Column<int>(nullable: false),
                    Referencia = table.Column<string>(nullable: false),
                    Descripcion = table.Column<string>(nullable: false),
                    Precio = table.Column<decimal>(nullable: false),
                    Existencia = table.Column<int>(nullable: false),
                    Departamento = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Articulos", x => x.ArticuloId);
                });

            migrationBuilder.CreateTable(
                name: "Departamentos",
                columns: table => new
                {
                    DepartamentoId = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Descripcion = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Departamentos", x => x.DepartamentoId);
                });

            migrationBuilder.CreateTable(
                name: "Pedidos",
                columns: table => new
                {
                    PedidoId = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Fecha = table.Column<DateTime>(nullable: false),
                    ArticuloId = table.Column<int>(nullable: false),
                    Precio = table.Column<decimal>(nullable: false),
                    Cantidad = table.Column<int>(nullable: false),
                    Total = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pedidos", x => x.PedidoId);
                });

            migrationBuilder.InsertData(
                table: "Articulos",
                columns: new[] { "ArticuloId", "Departamento", "DepartamentoId", "Descripcion", "Existencia", "Precio", "Referencia" },
                values: new object[] { 1, "Tecnologia", 1, "Iphone 2g", 2, 4000m, "Tecn" });

            migrationBuilder.InsertData(
                table: "Articulos",
                columns: new[] { "ArticuloId", "Departamento", "DepartamentoId", "Descripcion", "Existencia", "Precio", "Referencia" },
                values: new object[] { 2, "Tecnologia", 1, "Iphone 3g", 3, 5000m, "Tecn" });

            migrationBuilder.InsertData(
                table: "Articulos",
                columns: new[] { "ArticuloId", "Departamento", "DepartamentoId", "Descripcion", "Existencia", "Precio", "Referencia" },
                values: new object[] { 3, "Ferreteria", 2, "Tornillo Grande", 100, 15m, "Tool" });

            migrationBuilder.InsertData(
                table: "Departamentos",
                columns: new[] { "DepartamentoId", "Descripcion" },
                values: new object[] { 1, "Tecnologia" });

            migrationBuilder.InsertData(
                table: "Departamentos",
                columns: new[] { "DepartamentoId", "Descripcion" },
                values: new object[] { 2, "Ferreteria" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Articulos");

            migrationBuilder.DropTable(
                name: "Departamentos");

            migrationBuilder.DropTable(
                name: "Pedidos");
        }
    }
}
