using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace E_Apoteka.Migrations
{
    public partial class NameChange20 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MedicineCategory_Category_CategoryId",
                table: "MedicineCategory");

            migrationBuilder.DropForeignKey(
                name: "FK_MedicineCategory_Product_ProductId",
                table: "MedicineCategory");

            migrationBuilder.DropForeignKey(
                name: "FK_MedicinePrescription_Prescription_PrescriptionId",
                table: "MedicinePrescription");

            migrationBuilder.DropForeignKey(
                name: "FK_MedicinePrescription_Product_ProdutctId",
                table: "MedicinePrescription");

            migrationBuilder.DropPrimaryKey(
                name: "PK_MedicinePrescription",
                table: "MedicinePrescription");

            migrationBuilder.DropPrimaryKey(
                name: "PK_MedicineCategory",
                table: "MedicineCategory");

            migrationBuilder.RenameTable(
                name: "MedicinePrescription",
                newName: "ProductPrescription");

            migrationBuilder.RenameTable(
                name: "MedicineCategory",
                newName: "ProductCategory");

            migrationBuilder.RenameColumn(
                name: "ProdutctId",
                table: "ProductPrescription",
                newName: "ProductId");

            migrationBuilder.RenameIndex(
                name: "IX_MedicinePrescription_ProdutctId",
                table: "ProductPrescription",
                newName: "IX_ProductPrescription_ProductId");

            migrationBuilder.RenameIndex(
                name: "IX_MedicinePrescription_PrescriptionId",
                table: "ProductPrescription",
                newName: "IX_ProductPrescription_PrescriptionId");

            migrationBuilder.RenameIndex(
                name: "IX_MedicineCategory_ProductId",
                table: "ProductCategory",
                newName: "IX_ProductCategory_ProductId");

            migrationBuilder.RenameIndex(
                name: "IX_MedicineCategory_CategoryId",
                table: "ProductCategory",
                newName: "IX_ProductCategory_CategoryId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ProductPrescription",
                table: "ProductPrescription",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ProductCategory",
                table: "ProductCategory",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ProductCategory_Category_CategoryId",
                table: "ProductCategory",
                column: "CategoryId",
                principalTable: "Category",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ProductCategory_Product_ProductId",
                table: "ProductCategory",
                column: "ProductId",
                principalTable: "Product",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ProductPrescription_Prescription_PrescriptionId",
                table: "ProductPrescription",
                column: "PrescriptionId",
                principalTable: "Prescription",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ProductPrescription_Product_ProductId",
                table: "ProductPrescription",
                column: "ProductId",
                principalTable: "Product",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProductCategory_Category_CategoryId",
                table: "ProductCategory");

            migrationBuilder.DropForeignKey(
                name: "FK_ProductCategory_Product_ProductId",
                table: "ProductCategory");

            migrationBuilder.DropForeignKey(
                name: "FK_ProductPrescription_Prescription_PrescriptionId",
                table: "ProductPrescription");

            migrationBuilder.DropForeignKey(
                name: "FK_ProductPrescription_Product_ProductId",
                table: "ProductPrescription");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ProductPrescription",
                table: "ProductPrescription");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ProductCategory",
                table: "ProductCategory");

            migrationBuilder.RenameTable(
                name: "ProductPrescription",
                newName: "MedicinePrescription");

            migrationBuilder.RenameTable(
                name: "ProductCategory",
                newName: "MedicineCategory");

            migrationBuilder.RenameColumn(
                name: "ProductId",
                table: "MedicinePrescription",
                newName: "ProdutctId");

            migrationBuilder.RenameIndex(
                name: "IX_ProductPrescription_ProductId",
                table: "MedicinePrescription",
                newName: "IX_MedicinePrescription_ProdutctId");

            migrationBuilder.RenameIndex(
                name: "IX_ProductPrescription_PrescriptionId",
                table: "MedicinePrescription",
                newName: "IX_MedicinePrescription_PrescriptionId");

            migrationBuilder.RenameIndex(
                name: "IX_ProductCategory_ProductId",
                table: "MedicineCategory",
                newName: "IX_MedicineCategory_ProductId");

            migrationBuilder.RenameIndex(
                name: "IX_ProductCategory_CategoryId",
                table: "MedicineCategory",
                newName: "IX_MedicineCategory_CategoryId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_MedicinePrescription",
                table: "MedicinePrescription",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_MedicineCategory",
                table: "MedicineCategory",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_MedicineCategory_Category_CategoryId",
                table: "MedicineCategory",
                column: "CategoryId",
                principalTable: "Category",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_MedicineCategory_Product_ProductId",
                table: "MedicineCategory",
                column: "ProductId",
                principalTable: "Product",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_MedicinePrescription_Prescription_PrescriptionId",
                table: "MedicinePrescription",
                column: "PrescriptionId",
                principalTable: "Prescription",
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
    }
}
