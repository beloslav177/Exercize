using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Exercize.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Exercizes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Title = table.Column<string>(type: "text", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: false),
                    IsFinished = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Exercizes", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Exercizes",
                columns: new[] { "Id", "Description", "IsFinished", "Title" },
                values: new object[,]
                {
                    { 1, "Bitbucket pipeline should automatically create the MobilePulseClientSecrets AWS secret", false, "Bitbucket pipeline" },
                    { 2, "Dev", false, "PagerDuty" },
                    { 3, "Test", false, "PagerDuty pipeline" },
                    { 4, "Conmplete configuration for Services", false, "Configuration" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Exercizes");
        }
    }
}
