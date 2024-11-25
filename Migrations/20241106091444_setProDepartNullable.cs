using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OutsysCompany.Migrations
{
    /// <inheritdoc />
    public partial class setProDepartNullable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Projects_Departments_Dnum",
                table: "Projects");

            migrationBuilder.AlterColumn<int>(
                name: "Dnum",
                table: "Projects",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Projects_Departments_Dnum",
                table: "Projects",
                column: "Dnum",
                principalTable: "Departments",
                principalColumn: "Dnumber");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Projects_Departments_Dnum",
                table: "Projects");

            migrationBuilder.AlterColumn<int>(
                name: "Dnum",
                table: "Projects",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Projects_Departments_Dnum",
                table: "Projects",
                column: "Dnum",
                principalTable: "Departments",
                principalColumn: "Dnumber",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
