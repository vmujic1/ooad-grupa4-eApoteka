using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace E_Apoteka.Migrations
{
    public partial class NameChange : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MedicineCategory_Product_MedicineId",
                table: "MedicineCategory");

            migrationBuilder.DropForeignKey(
                name: "FK_MedicinePrescription_Product_MedicineId",
                table: "MedicinePrescription");

            migrationBuilder.RenameColumn(
                name: "MedicineId",
                table: "MedicinePrescription",
                newName: "ProdutctId");

            migrationBuilder.RenameIndex(
                name: "IX_MedicinePrescription_MedicineId",
                table: "MedicinePrescription",
                newName: "IX_MedicinePrescription_ProdutctId");

            migrationBuilder.RenameColumn(
                name: "MedicineId",
                table: "MedicineCategory",
                newName: "ProductId");

            migrationBuilder.RenameIndex(
                name: "IX_MedicineCategory_MedicineId",
                table: "MedicineCategory",
                newName: "IX_MedicineCategory_ProductId");

            migrationBuilder.AddForeignKey(
                name: "FK_MedicineCategory_Product_ProductId",
                table: "MedicineCategory",
                column: "ProductId",
                principalTable: "Product",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_MedicinePrescription_Product_ProdutctId",
                table: "MedicinePrescription",
                column: "ProdutctId",
                principalTable: "Product",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MedicineCategory_Product_ProductId",
                table: "MedicineCategory");

            migrationBuilder.DropForeignKey(
                name: "FK_MedicinePrescription_Product_ProdutctId",
                table: "MedicinePrescription");

            migrationBuilder.RenameColumn(
                name: "ProdutctId",
                table: "MedicinePrescription",
                newName: "MedicineId");

            migrationBuilder.RenameIndex(
                name: "IX_MedicinePrescription_ProdutctId",
                table: "MedicinePrescription",
                newName: "IX_MedicinePrescription_MedicineId");

            migrationBuilder.RenameColumn(
                name: "ProductId",
                table: "MedicineCategory",
                newName: "MedicineId");

            migrationBuilder.RenameIndex(
                name: "IX_MedicineCategory_ProductId",
                table: "MedicineCategory",
                newName: "IX_MedicineCategory_MedicineId");

            migrationBuilder.AddForeignKey(
                name: "FK_MedicineCategory_Product_MedicineId",
                table: "MedicineCategory",
                column: "MedicineId",
                principalTable: "Product",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_MedicinePrescription_Product_MedicineId",
                table: "MedicinePrescription",
                column: "MedicineId",
                principalTable: "Product",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
