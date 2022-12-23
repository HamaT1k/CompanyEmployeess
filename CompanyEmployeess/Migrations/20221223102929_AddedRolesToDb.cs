using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CompanyEmployeess.Migrations
{
    public partial class AddedRolesToDb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "068320bc-60d7-45b3-83ef-2dbc4adcae62", "6f3dd1fe-8d59-4723-ab0b-35c716fd9024", "Administrator", "ADMINISTRATOR" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "4c862cd1-6d8c-4408-9bce-192fb0682711", "f1c4944a-e367-4e93-9dcf-8c915a92a6b1", "Manager", "MANAGER" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "068320bc-60d7-45b3-83ef-2dbc4adcae62");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "4c862cd1-6d8c-4408-9bce-192fb0682711");
        }
    }
}
