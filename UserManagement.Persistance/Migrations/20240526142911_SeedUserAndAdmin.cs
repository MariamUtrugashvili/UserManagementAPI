using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace UserManagement.Persistance.Migrations
{
    /// <inheritdoc />
    public partial class SeedUserAndAdmin : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "RoleName" },
                values: new object[,]
                {
                    { new Guid("1a9ea18e-c88e-490b-b95e-6b499338f91d"), "Admin" },
                    { new Guid("91f900f6-c656-4793-b13b-bf627c6665f5"), "User" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Email", "Password", "Status", "UserName" },
                values: new object[,]
                {
                    { new Guid("97de980e-01cb-47b7-8609-a0aecd995c1f"), "Admin@gmail.com", "$2a$11$0WxXp0R2wS/.Y1m1MEFlpO32Yfm5aHV0Ni7pFN0NK1INSvC0usPkK", 0, "Admin" },
                    { new Guid("cf20903c-06ca-4bf1-9ed6-a254a65baaa2"), "User@gmail.com", "$2a$11$5kp.Uhs1BH.WFNRLibuwQOfWHdWu/nSkquqag4EpMQkG/ZOjeWKa.", 0, "User" }
                });

            migrationBuilder.InsertData(
                table: "UserRoles",
                columns: new[] { "Id", "RoleId", "UserId" },
                values: new object[,]
                {
                    { 1, new Guid("91f900f6-c656-4793-b13b-bf627c6665f5"), new Guid("cf20903c-06ca-4bf1-9ed6-a254a65baaa2") },
                    { 2, new Guid("1a9ea18e-c88e-490b-b95e-6b499338f91d"), new Guid("97de980e-01cb-47b7-8609-a0aecd995c1f") }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "UserRoles",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "UserRoles",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("1a9ea18e-c88e-490b-b95e-6b499338f91d"));

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("91f900f6-c656-4793-b13b-bf627c6665f5"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("97de980e-01cb-47b7-8609-a0aecd995c1f"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("cf20903c-06ca-4bf1-9ed6-a254a65baaa2"));
        }
    }
}
