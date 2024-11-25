using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OutsysCompany.Migrations
{
    /// <inheritdoc />
    public partial class nullableMgrSSN : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Atteces_Employees_EmpleeID",
                table: "Atteces");

            migrationBuilder.DropForeignKey(
                name: "FK_Departments_Employees_MgrSsn",
                table: "Departments");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Atteces",
                table: "Atteces");

            migrationBuilder.RenameTable(
                name: "Atteces",
                newName: "Attedences");

            migrationBuilder.AlterColumn<int>(
                name: "MgrSsn",
                table: "Departments",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Attedences",
                table: "Attedences",
                columns: new[] { "EmpleeID", "month", "year" });

            migrationBuilder.AddForeignKey(
                name: "FK_Attedences_Employees_EmpleeID",
                table: "Attedences",
                column: "EmpleeID",
                principalTable: "Employees",
                principalColumn: "Ssn",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Departments_Employees_MgrSsn",
                table: "Departments",
                column: "MgrSsn",
                principalTable: "Employees",
                principalColumn: "Ssn");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Attedences_Employees_EmpleeID",
                table: "Attedences");

            migrationBuilder.DropForeignKey(
                name: "FK_Departments_Employees_MgrSsn",
                table: "Departments");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Attedences",
                table: "Attedences");

            migrationBuilder.RenameTable(
                name: "Attedences",
                newName: "Atteces");

            migrationBuilder.AlterColumn<int>(
                name: "MgrSsn",
                table: "Departments",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Atteces",
                table: "Atteces",
                columns: new[] { "EmpleeID", "month", "year" });

            migrationBuilder.AddForeignKey(
                name: "FK_Atteces_Employees_EmpleeID",
                table: "Atteces",
                column: "EmpleeID",
                principalTable: "Employees",
                principalColumn: "Ssn",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Departments_Employees_MgrSsn",
                table: "Departments",
                column: "MgrSsn",
                principalTable: "Employees",
                principalColumn: "Ssn",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
