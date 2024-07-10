using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HeadHunterClone.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class Init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationbuilder)
        {
                            migrationbuilder.CreateTable(
                            name: "Vacancies",
                            columns: table => new
                            {
                                Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                                UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                                NormalizedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                                Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                                NormalizedEmail = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                                EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                                PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                                SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                                ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                                PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                                PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                                TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                                LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                                LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                                AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                            },
                            constraints: table =>
                {
                    table.PrimaryKey("pk_vacancies", x => x.Id);
                });

            migrationbuilder.InsertData(
                table: "vacancies",
                columns: new[] { "id", "description", "experiencelevel", "requirements", "salarycurrency", "salaryfrom", "salaryto", "skills", "title", "workterms" },
                values: new object[] { 1, "this is description 1", 2, " require 1,  require 2, require 3", "usd", 1000, 3000, "skill 1", "title 1", " term 1, term 2" });
        }

        /// <InheritDoc />
        protected override void Down(MigrationBuilder migrationbuilder)
        {
            migrationbuilder.DropTable(
                name: "vacancies");
        }
    }
}
