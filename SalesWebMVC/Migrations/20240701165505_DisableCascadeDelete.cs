using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SalesWebMVC.Migrations
{
    /// <inheritdoc />
    public partial class DisableCascadeDelete : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_tb_sales_record_tb_seller_SellerId",
                table: "tb_sales_record");

            migrationBuilder.DropForeignKey(
                name: "FK_tb_seller_tb_department_DepartmentId",
                table: "tb_seller");

            migrationBuilder.AddForeignKey(
                name: "FK_tb_sales_record_tb_seller_SellerId",
                table: "tb_sales_record",
                column: "SellerId",
                principalTable: "tb_seller",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_tb_seller_tb_department_DepartmentId",
                table: "tb_seller",
                column: "DepartmentId",
                principalTable: "tb_department",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
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
    }
}
