using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MotasWebRazor.Migrations
{ 
    public partial class AddMotasDBToDB : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {   // Script que vai criar a tabela na base de dados.
            migrationBuilder.CreateTable(
                name: "Mota",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Categoria = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Valor = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Cor = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Cilindrada = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Ano = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Mota", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Mota");
        }
    }
}
