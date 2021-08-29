using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace odata_poc.Migrations
{
    public partial class InitialMigrations : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Systems",
                columns: table => new
                {
                    FnmaSystemId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    OwnerFirstName = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    OwnerLastName = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    DateCreated = table.Column<DateTimeOffset>(type: "datetime(6)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Systems", x => x.FnmaSystemId);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Interface",
                columns: table => new
                {
                    SystemInterfaceId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    InterfaceName = table.Column<string>(type: "varchar(145)", maxLength: 145, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    FnmaSystemId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Interface", x => x.SystemInterfaceId);
                    table.ForeignKey(
                        name: "FK_Interface_Systems_FnmaSystemId",
                        column: x => x.FnmaSystemId,
                        principalTable: "Systems",
                        principalColumn: "FnmaSystemId",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.InsertData(
                table: "Systems",
                columns: new[] { "FnmaSystemId", "DateCreated", "OwnerFirstName", "OwnerLastName" },
                values: new object[,]
                {
                    { 1, new DateTimeOffset(new DateTime(2021, 4, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, -7, 0, 0, 0)), "bill", "Mclearn" },
                    { 2, new DateTimeOffset(new DateTime(2020, 4, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, -7, 0, 0, 0)), "jill", "Smith" },
                    { 3, new DateTimeOffset(new DateTime(2001, 8, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, -7, 0, 0, 0)), "Jose", "Mcdonald" },
                    { 4, new DateTimeOffset(new DateTime(2016, 2, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, -8, 0, 0, 0)), "Tae", "Richards" },
                    { 5, new DateTimeOffset(new DateTime(2005, 8, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, -7, 0, 0, 0)), "Ryan", "Lia" }
                });

            migrationBuilder.InsertData(
                table: "Interface",
                columns: new[] { "SystemInterfaceId", "FnmaSystemId", "InterfaceName" },
                values: new object[,]
                {
                    { 1, 1, "Credit Checker" },
                    { 2, 2, "CFOC Center" },
                    { 3, 3, "Discolsure Processor" },
                    { 4, 4, "DUC Loan Processor" },
                    { 5, 5, "Aquisition Monitor" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Interface_FnmaSystemId",
                table: "Interface",
                column: "FnmaSystemId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Interface");

            migrationBuilder.DropTable(
                name: "Systems");
        }
    }
}
