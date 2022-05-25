using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace travelAgency.Migrations
{
    public partial class ChangeDataBase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Employee_AspNetUsers_UserId",
                table: "Employee");

            migrationBuilder.DropForeignKey(
                name: "FK_Reserves_AspNetUsers_UserId",
                table: "Reserves");

            migrationBuilder.DropForeignKey(
                name: "FK_Tours_Employee_EmployeeId",
                table: "Tours");

            migrationBuilder.DropIndex(
                name: "IX_Reserves_UserId",
                table: "Reserves");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Employee",
                table: "Employee");

            migrationBuilder.RenameTable(
                name: "Employee",
                newName: "Employees");

            migrationBuilder.RenameIndex(
                name: "IX_Employee_UserId",
                table: "Employees",
                newName: "IX_Employees_UserId");

            migrationBuilder.AddColumn<int>(
                name: "CommentId",
                table: "Tours",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ExcursionId",
                table: "Tours",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<bool>(
                name: "IsHotTour",
                table: "Tours",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "Rating",
                table: "Tours",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ReservesId",
                table: "Tours",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "PhotoPathId",
                table: "ShowPlaces",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<int>(
                name: "UserId",
                table: "Reserves",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UserReserveId",
                table: "Reserves",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "PhotoPathId",
                table: "Hotels",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ShowPlaceId",
                table: "Excursions",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "Comments",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "EmployeeId",
                table: "AspNetUsers",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ReservesId",
                table: "AspNetUsers",
                type: "int",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Employees",
                table: "Employees",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_Reserves_UserReserveId",
                table: "Reserves",
                column: "UserReserveId");

            migrationBuilder.AddForeignKey(
                name: "FK_Employees_AspNetUsers_UserId",
                table: "Employees",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Reserves_AspNetUsers_UserReserveId",
                table: "Reserves",
                column: "UserReserveId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Tours_Employees_EmployeeId",
                table: "Tours",
                column: "EmployeeId",
                principalTable: "Employees",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Employees_AspNetUsers_UserId",
                table: "Employees");

            migrationBuilder.DropForeignKey(
                name: "FK_Reserves_AspNetUsers_UserReserveId",
                table: "Reserves");

            migrationBuilder.DropForeignKey(
                name: "FK_Tours_Employees_EmployeeId",
                table: "Tours");

            migrationBuilder.DropIndex(
                name: "IX_Reserves_UserReserveId",
                table: "Reserves");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Employees",
                table: "Employees");

            migrationBuilder.DropColumn(
                name: "CommentId",
                table: "Tours");

            migrationBuilder.DropColumn(
                name: "ExcursionId",
                table: "Tours");

            migrationBuilder.DropColumn(
                name: "IsHotTour",
                table: "Tours");

            migrationBuilder.DropColumn(
                name: "Rating",
                table: "Tours");

            migrationBuilder.DropColumn(
                name: "ReservesId",
                table: "Tours");

            migrationBuilder.DropColumn(
                name: "PhotoPathId",
                table: "ShowPlaces");

            migrationBuilder.DropColumn(
                name: "UserReserveId",
                table: "Reserves");

            migrationBuilder.DropColumn(
                name: "PhotoPathId",
                table: "Hotels");

            migrationBuilder.DropColumn(
                name: "ShowPlaceId",
                table: "Excursions");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Comments");

            migrationBuilder.DropColumn(
                name: "EmployeeId",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "ReservesId",
                table: "AspNetUsers");

            migrationBuilder.RenameTable(
                name: "Employees",
                newName: "Employee");

            migrationBuilder.RenameIndex(
                name: "IX_Employees_UserId",
                table: "Employee",
                newName: "IX_Employee_UserId");

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "Reserves",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Employee",
                table: "Employee",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_Reserves_UserId",
                table: "Reserves",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Employee_AspNetUsers_UserId",
                table: "Employee",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Reserves_AspNetUsers_UserId",
                table: "Reserves",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Tours_Employee_EmployeeId",
                table: "Tours",
                column: "EmployeeId",
                principalTable: "Employee",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
