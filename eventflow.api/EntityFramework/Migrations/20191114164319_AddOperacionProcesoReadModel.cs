using Microsoft.EntityFrameworkCore.Migrations;

namespace eventflow.api.EntityFramework.Migrations
{
    public partial class AddOperacionProcesoReadModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Operacion",
                table: "Procesos",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Operacion",
                table: "Procesos");
        }
    }
}
