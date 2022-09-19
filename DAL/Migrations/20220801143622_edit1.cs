using Microsoft.EntityFrameworkCore.Migrations;

namespace DAL.Migrations
{
    public partial class edit1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_orderIds",
                table: "orderIds");

            migrationBuilder.DropIndex(
                name: "IX_orderIds_productId",
                table: "orderIds");

            migrationBuilder.DropColumn(
                name: "id",
                table: "orderIds");

            migrationBuilder.AddColumn<int>(
                name: "productId",
                table: "Orders",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_orderIds",
                table: "orderIds",
                column: "productId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_orderIds",
                table: "orderIds");

            migrationBuilder.DropColumn(
                name: "productId",
                table: "Orders");

            migrationBuilder.AddColumn<int>(
                name: "id",
                table: "orderIds",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_orderIds",
                table: "orderIds",
                column: "id");

            migrationBuilder.CreateIndex(
                name: "IX_orderIds_productId",
                table: "orderIds",
                column: "productId",
                unique: true);
        }
    }
}
