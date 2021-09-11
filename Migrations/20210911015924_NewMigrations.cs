using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace odata_poc.Migrations
{
    public partial class NewMigrations : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Accounts",
                columns: table => new
                {
                    AccountId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    LoanNumber = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Accounts", x => x.AccountId);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Properties",
                columns: table => new
                {
                    PropertyId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Street = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    City = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Zip = table.Column<int>(type: "int", nullable: false),
                    Price = table.Column<int>(type: "int", nullable: false),
                    LoanNumber = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Properties", x => x.PropertyId);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.InsertData(
                table: "Accounts",
                columns: new[] { "AccountId", "LoanNumber", "Name" },
                values: new object[,]
                {
                    { 7, 236467, "Bill Nye" },
                    { 1, 442346, "Phill Mcdonald" },
                    { 2, 675686, "Brian James" },
                    { 3, 345747, "Ryan Arol" },
                    { 4, 648799, "Jose East" },
                    { 5, 467475, "Drake West" },
                    { 6, 123497, "Ed Sharee" }
                });

            migrationBuilder.InsertData(
                table: "Properties",
                columns: new[] { "PropertyId", "City", "LoanNumber", "Price", "Street", "Zip" },
                values: new object[,]
                {
                    { 7, "Signal Hill", 123497, 3000000, "Orange Ave", 92010 },
                    { 1, "Long Beach", 467475, 390000, "Atlantic", 20192 },
                    { 2, "Aneheim", 648799, 1000000, "Lincohn Blvd", 90293 },
                    { 3, "Cerritos", 345747, 800281, "Knott Ave", 92912 },
                    { 4, "Bellflower", 675686, 690000, "Artesia Blvd", 91920 },
                    { 5, "Compton", 442346, 90000, "Greenleaf Blvd", 883023 },
                    { 6, "Paramount", 236467, 100201, "Somerset Blvd", 90280 }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Accounts");

            migrationBuilder.DropTable(
                name: "Properties");
        }
    }
}
