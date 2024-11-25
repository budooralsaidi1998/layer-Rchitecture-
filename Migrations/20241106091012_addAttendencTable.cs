using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OutsysCompany.Migrations
{
    /// <inheritdoc />
    public partial class addAttendencTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Atteces",
                columns: table => new
                {
                    EmpleeID = table.Column<int>(type: "int", nullable: false),
                    year = table.Column<int>(type: "int", nullable: false),
                    month = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    AbsentDays = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Atteces", x => new { x.EmpleeID, x.month, x.year });
                    table.ForeignKey(
                        name: "FK_Atteces_Employees_EmpleeID",
                        column: x => x.EmpleeID,
                        principalTable: "Employees",
                        principalColumn: "Ssn",
                        onDelete: ReferentialAction.Cascade);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Atteces");
        }
    }
}
