using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace E_Apoteka.Data.Migrations
{
    public partial class SecondMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Category_Product_MedicineId",
                table: "Category");

            migrationBuilder.DropForeignKey(
                name: "FK_Prescription_Product_MedicineId",
                table: "Prescription");

            migrationBuilder.DropForeignKey(
                name: "FK_Product_Order_OrderId",
                table: "Product");

            migrationBuilder.DropIndex(
                name: "IX_Product_OrderId",
                table: "Product");

            migrationBuilder.DropIndex(
                name: "IX_Prescription_MedicineId",
                table: "Prescription");

            migrationBuilder.DropIndex(
                name: "IX_Category_MedicineId",
                table: "Category");

            migrationBuilder.DropColumn(
                name: "Cart",
                table: "User");

            migrationBuilder.DropColumn(
                name: "OrderId",
                table: "Product");

            migrationBuilder.DropColumn(
                name: "MedicineId",
                table: "Prescription");

            migrationBuilder.DropColumn(
                name: "DeliveryDate",
                table: "Order");

            migrationBuilder.DropColumn(
                name: "MedicineId",
                table: "Category");

            migrationBuilder.RenameColumn(
                name: "Amount",
                table: "Order",
                newName: "PaymentType");

            migrationBuilder.RenameColumn(
                name: "rating",
                table: "Comment",
                newName: "Rating");

            migrationBuilder.AddColumn<int>(
                name: "Quantity",
                table: "ProductCart",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Amount",
                table: "Prescription",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "ExpirationDate",
                table: "Prescription",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "InsuranceNumber",
                table: "Prescription",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "IssueDate",
                table: "Prescription",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AlterColumn<int>(
                name: "OrderStatus",
                table: "Order",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<double>(
                name: "TotalPrice",
                table: "Order",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "TotalPrice",
                table: "Cart",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.CreateIndex(
                name: "IX_ProductOrder_OrderId",
                table: "ProductOrder",
                column: "OrderId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductOrder_ProductId",
                table: "ProductOrder",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductCart_CartId",
                table: "ProductCart",
                column: "CartId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductCart_ProductId",
                table: "ProductCart",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_Prescription_StaffId",
                table: "Prescription",
                column: "StaffId");

            migrationBuilder.CreateIndex(
                name: "IX_Prescription_UserId",
                table: "Prescription",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Order_CustomerId",
                table: "Order",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_MedicinePrescription_MedicineId",
                table: "MedicinePrescription",
                column: "MedicineId");

            migrationBuilder.CreateIndex(
                name: "IX_MedicinePrescription_PrescriptionId",
                table: "MedicinePrescription",
                column: "PrescriptionId");

            migrationBuilder.CreateIndex(
                name: "IX_MedicineCategory_CategoryId",
                table: "MedicineCategory",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_MedicineCategory_MedicineId",
                table: "MedicineCategory",
                column: "MedicineId");

            migrationBuilder.CreateIndex(
                name: "IX_Comment_ProductId",
                table: "Comment",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_Comment_UserId",
                table: "Comment",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Cart_UserId",
                table: "Cart",
                column: "UserId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Cart_User_UserId",
                table: "Cart",
                column: "UserId",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Comment_Product_ProductId",
                table: "Comment",
                column: "ProductId",
                principalTable: "Product",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Comment_User_UserId",
                table: "Comment",
                column: "UserId",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_MedicineCategory_Category_CategoryId",
                table: "MedicineCategory",
                column: "CategoryId",
                principalTable: "Category",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_MedicineCategory_Product_MedicineId",
                table: "MedicineCategory",
                column: "MedicineId",
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
                name: "FK_MedicinePrescription_Product_MedicineId",
                table: "MedicinePrescription",
                column: "MedicineId",
                principalTable: "Product",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Order_User_CustomerId",
                table: "Order",
                column: "CustomerId",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Prescription_Staff_StaffId",
                table: "Prescription",
                column: "StaffId",
                principalTable: "Staff",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Prescription_User_UserId",
                table: "Prescription",
                column: "UserId",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ProductCart_Cart_CartId",
                table: "ProductCart",
                column: "CartId",
                principalTable: "Cart",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ProductCart_Product_ProductId",
                table: "ProductCart",
                column: "ProductId",
                principalTable: "Product",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ProductOrder_Order_OrderId",
                table: "ProductOrder",
                column: "OrderId",
                principalTable: "Order",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ProductOrder_Product_ProductId",
                table: "ProductOrder",
                column: "ProductId",
                principalTable: "Product",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cart_User_UserId",
                table: "Cart");

            migrationBuilder.DropForeignKey(
                name: "FK_Comment_Product_ProductId",
                table: "Comment");

            migrationBuilder.DropForeignKey(
                name: "FK_Comment_User_UserId",
                table: "Comment");

            migrationBuilder.DropForeignKey(
                name: "FK_MedicineCategory_Category_CategoryId",
                table: "MedicineCategory");

            migrationBuilder.DropForeignKey(
                name: "FK_MedicineCategory_Product_MedicineId",
                table: "MedicineCategory");

            migrationBuilder.DropForeignKey(
                name: "FK_MedicinePrescription_Prescription_PrescriptionId",
                table: "MedicinePrescription");

            migrationBuilder.DropForeignKey(
                name: "FK_MedicinePrescription_Product_MedicineId",
                table: "MedicinePrescription");

            migrationBuilder.DropForeignKey(
                name: "FK_Order_User_CustomerId",
                table: "Order");

            migrationBuilder.DropForeignKey(
                name: "FK_Prescription_Staff_StaffId",
                table: "Prescription");

            migrationBuilder.DropForeignKey(
                name: "FK_Prescription_User_UserId",
                table: "Prescription");

            migrationBuilder.DropForeignKey(
                name: "FK_ProductCart_Cart_CartId",
                table: "ProductCart");

            migrationBuilder.DropForeignKey(
                name: "FK_ProductCart_Product_ProductId",
                table: "ProductCart");

            migrationBuilder.DropForeignKey(
                name: "FK_ProductOrder_Order_OrderId",
                table: "ProductOrder");

            migrationBuilder.DropForeignKey(
                name: "FK_ProductOrder_Product_ProductId",
                table: "ProductOrder");

            migrationBuilder.DropIndex(
                name: "IX_ProductOrder_OrderId",
                table: "ProductOrder");

            migrationBuilder.DropIndex(
                name: "IX_ProductOrder_ProductId",
                table: "ProductOrder");

            migrationBuilder.DropIndex(
                name: "IX_ProductCart_CartId",
                table: "ProductCart");

            migrationBuilder.DropIndex(
                name: "IX_ProductCart_ProductId",
                table: "ProductCart");

            migrationBuilder.DropIndex(
                name: "IX_Prescription_StaffId",
                table: "Prescription");

            migrationBuilder.DropIndex(
                name: "IX_Prescription_UserId",
                table: "Prescription");

            migrationBuilder.DropIndex(
                name: "IX_Order_CustomerId",
                table: "Order");

            migrationBuilder.DropIndex(
                name: "IX_MedicinePrescription_MedicineId",
                table: "MedicinePrescription");

            migrationBuilder.DropIndex(
                name: "IX_MedicinePrescription_PrescriptionId",
                table: "MedicinePrescription");

            migrationBuilder.DropIndex(
                name: "IX_MedicineCategory_CategoryId",
                table: "MedicineCategory");

            migrationBuilder.DropIndex(
                name: "IX_MedicineCategory_MedicineId",
                table: "MedicineCategory");

            migrationBuilder.DropIndex(
                name: "IX_Comment_ProductId",
                table: "Comment");

            migrationBuilder.DropIndex(
                name: "IX_Comment_UserId",
                table: "Comment");

            migrationBuilder.DropIndex(
                name: "IX_Cart_UserId",
                table: "Cart");

            migrationBuilder.DropColumn(
                name: "Quantity",
                table: "ProductCart");

            migrationBuilder.DropColumn(
                name: "Amount",
                table: "Prescription");

            migrationBuilder.DropColumn(
                name: "ExpirationDate",
                table: "Prescription");

            migrationBuilder.DropColumn(
                name: "InsuranceNumber",
                table: "Prescription");

            migrationBuilder.DropColumn(
                name: "IssueDate",
                table: "Prescription");

            migrationBuilder.DropColumn(
                name: "TotalPrice",
                table: "Order");

            migrationBuilder.DropColumn(
                name: "TotalPrice",
                table: "Cart");

            migrationBuilder.RenameColumn(
                name: "PaymentType",
                table: "Order",
                newName: "Amount");

            migrationBuilder.RenameColumn(
                name: "Rating",
                table: "Comment",
                newName: "rating");

            migrationBuilder.AddColumn<int>(
                name: "Cart",
                table: "User",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "OrderId",
                table: "Product",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "MedicineId",
                table: "Prescription",
                type: "int",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "OrderStatus",
                table: "Order",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<DateTime>(
                name: "DeliveryDate",
                table: "Order",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "MedicineId",
                table: "Category",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Product_OrderId",
                table: "Product",
                column: "OrderId");

            migrationBuilder.CreateIndex(
                name: "IX_Prescription_MedicineId",
                table: "Prescription",
                column: "MedicineId");

            migrationBuilder.CreateIndex(
                name: "IX_Category_MedicineId",
                table: "Category",
                column: "MedicineId");

            migrationBuilder.AddForeignKey(
                name: "FK_Category_Product_MedicineId",
                table: "Category",
                column: "MedicineId",
                principalTable: "Product",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Prescription_Product_MedicineId",
                table: "Prescription",
                column: "MedicineId",
                principalTable: "Product",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Product_Order_OrderId",
                table: "Product",
                column: "OrderId",
                principalTable: "Order",
                principalColumn: "Id");
        }
    }
}
