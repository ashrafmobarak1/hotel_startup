using Microsoft.EntityFrameworkCore.Migrations;

namespace hotel_startup.Migrations
{
    public partial class cityidForegen : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Bookings_cityId",
                table: "Bookings",
                column: "cityId");

            migrationBuilder.AddForeignKey(
                name: "FK_Bookings_City_cityId",
                table: "Bookings",
                column: "cityId",
                principalTable: "City",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Bookings_City_cityId",
                table: "Bookings");

            migrationBuilder.DropIndex(
                name: "IX_Bookings_cityId",
                table: "Bookings");
        }
    }
}
