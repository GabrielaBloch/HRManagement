using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HRManagement.Identity.Migrations
{
    /// <inheritdoc />
    public partial class corectmistake : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "89ko9l03-j49c-9340-njd8940koq",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "afbdd9b1-4712-4b1d-9eb0-afecacde2863", "AQAAAAIAAYagAAAAEIUIdPrJckhRA0r3j45PRWDiEiVzQj8jIT0Hv+Oe3uBzyYfnyOnXI9Yv9ZMOLEpgaQ==", "fa4f006a-0c74-4de7-abe0-996501bfe317" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "90bh10o0-mco4-sh48-an48vprlod",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "9ce0ecd8-a02f-48a4-851f-5ba8ee677915", "AQAAAAIAAYagAAAAEIjggGQwDwDtf+0Oia0Ey3FkfkMzlw31veWqRuzXgiqjZRXGUQh2fWBNIvYpwi/KRw==", "c4599874-dc90-4f4d-8b25-0af6878cdb32" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "89ko9l03-j49c-9340-njd8940koq",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "54dd82bc-afae-4a04-9948-8015200c971a", "AQAAAAIAAYagAAAAEAoixawNEuELIoTEVEmFL6MI7ZYOiKfSwFHg1mdzOemlv3MVOY+4U9IOeR5zS2TgRQ==", "dcaca9e0-1524-4f20-bc56-cfc50e4e3a2c" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "90bh10o0-mco4-sh48-an48vprlod",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "9f84eddf-8037-43f2-a4db-e080792b8e27", "AQAAAAIAAYagAAAAEAEGBxj0ZpuOs4i/6ZgGX5NHgNcmqqIOmN514yqkES6vTBwZ1F8+7g+hDP8WU4Gy4g==", "af604ee5-dd12-4e46-b317-0b2ebc4bed44" });
        }
    }
}
