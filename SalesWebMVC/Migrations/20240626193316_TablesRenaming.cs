using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SalesWebMVC.Migrations
{
    /// <inheritdoc />
    public partial class TablesRenaming : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SalesRecord_Seller_SellerId",
                table: "SalesRecord");

            migrationBuilder.DropForeignKey(
                name: "FK_Seller_Department_DepartmentId",
                table: "Seller");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Seller",
                table: "Seller");

            migrationBuilder.DropPrimaryKey(
                name: "PK_SalesRecord",
                table: "SalesRecord");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Department",
                table: "Department");

            migrationBuilder.RenameTable(
                name: "Seller",
                newName: "tb_seller");

            migrationBuilder.RenameTable(
                name: "SalesRecord",
                newName: "tb_sales_record");

            migrationBuilder.RenameTable(
                name: "Department",
                newName: "tb_department");

            migrationBuilder.RenameIndex(
                name: "IX_Seller_DepartmentId",
                table: "tb_seller",
                newName: "IX_tb_seller_DepartmentId");

            migrationBuilder.RenameIndex(
                name: "IX_SalesRecord_SellerId",
                table: "tb_sales_record",
                newName: "IX_tb_sales_record_SellerId");

            migrationBuilder.AlterColumn<byte>(
                name: "Status",
                table: "tb_sales_record",
                type: "tinyint",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddPrimaryKey(
                name: "PK_tb_seller",
                table: "tb_seller",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_tb_sales_record",
                table: "tb_sales_record",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_tb_department",
                table: "tb_department",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_tb_sales_record_tb_seller_SellerId",
                table: "tb_sales_record",
                column: "SellerId",
                principalTable: "tb_seller",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_tb_seller_tb_department_DepartmentId",
                table: "tb_seller",
                column: "DepartmentId",
                principalTable: "tb_department",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_tb_sales_record_tb_seller_SellerId",
                table: "tb_sales_record");

            migrationBuilder.DropForeignKey(
                name: "FK_tb_seller_tb_department_DepartmentId",
                table: "tb_seller");

            migrationBuilder.DropPrimaryKey(
                name: "PK_tb_seller",
                table: "tb_seller");

            migrationBuilder.DropPrimaryKey(
                name: "PK_tb_sales_record",
                table: "tb_sales_record");

            migrationBuilder.DropPrimaryKey(
                name: "PK_tb_department",
                table: "tb_department");

            migrationBuilder.RenameTable(
                name: "tb_seller",
                newName: "Seller");

            migrationBuilder.RenameTable(
                name: "tb_sales_record",
                newName: "SalesRecord");

            migrationBuilder.RenameTable(
                name: "tb_department",
                newName: "Department");

            migrationBuilder.RenameIndex(
                name: "IX_tb_seller_DepartmentId",
                table: "Seller",
                newName: "IX_Seller_DepartmentId");

            migrationBuilder.RenameIndex(
                name: "IX_tb_sales_record_SellerId",
                table: "SalesRecord",
                newName: "IX_SalesRecord_SellerId");

            migrationBuilder.AlterColumn<int>(
                name: "Status",
                table: "SalesRecord",
                type: "int",
                nullable: false,
                oldClrType: typeof(byte),
                oldType: "tinyint");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Seller",
                table: "Seller",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_SalesRecord",
                table: "SalesRecord",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Department",
                table: "Department",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_SalesRecord_Seller_SellerId",
                table: "SalesRecord",
                column: "SellerId",
                principalTable: "Seller",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Seller_Department_DepartmentId",
                table: "Seller",
                column: "DepartmentId",
                principalTable: "Department",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
