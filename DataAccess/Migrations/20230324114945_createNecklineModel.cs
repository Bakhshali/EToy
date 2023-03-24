using Microsoft.EntityFrameworkCore.Migrations;

namespace DataAccess.Migrations
{
    public partial class createNecklineModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Clothes_Models_ModelId",
                table: "Clothes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Models",
                table: "Models");

            migrationBuilder.RenameTable(
                name: "Models",
                newName: "ModelOfClothes");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ModelOfClothes",
                table: "ModelOfClothes",
                column: "Id");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "0f8za25b-t9cb-469f-a165-708677289502",
                column: "ConcurrencyStamp",
                value: "3239efee-ea3b-4e76-88a6-2a027dcb03fc");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "0f8fad5b-d9cb-469f-a165-70867728950e",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "f91f8af9-19cc-442e-a4e7-a14d8e35a420", "AQAAAAEAACcQAAAAEOgJDrzPyCgK1JsqPFU3NUgdhbCQBkIs9tMq+zGYb+0vfuxuxr6FEWXpxAtllQoyKQ==", "0ec1f0bf-0a9b-4dd9-ad47-bddb49115dbf" });

            migrationBuilder.AddForeignKey(
                name: "FK_Clothes_ModelOfClothes_ModelId",
                table: "Clothes",
                column: "ModelId",
                principalTable: "ModelOfClothes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Clothes_ModelOfClothes_ModelId",
                table: "Clothes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ModelOfClothes",
                table: "ModelOfClothes");

            migrationBuilder.RenameTable(
                name: "ModelOfClothes",
                newName: "Models");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Models",
                table: "Models",
                column: "Id");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "0f8za25b-t9cb-469f-a165-708677289502",
                column: "ConcurrencyStamp",
                value: "a01f8af2-e22b-4a64-a408-66ff55cd1abe");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "0f8fad5b-d9cb-469f-a165-70867728950e",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "19eace90-0f2d-4707-b2f7-f5cd4ac6d300", "AQAAAAEAACcQAAAAEHEVjNrCLV86m0E7V5lzvzMzxVYW72mTq2jF5Wwg750fyzSyIp5RAkYiipoNrkzLNA==", "d11fd50f-cc6c-4197-a854-79edebafd2d6" });

            migrationBuilder.AddForeignKey(
                name: "FK_Clothes_Models_ModelId",
                table: "Clothes",
                column: "ModelId",
                principalTable: "Models",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
