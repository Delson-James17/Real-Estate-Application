using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Real_Estate.Migrations
{
    public partial class seed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "51d0771e-de96-4882-a01e-8f0b9949e90c", "0515e450-c176-455c-8106-d94a1cc2d6a4", "Owner", "OWNER" },
                    { "5c965850-234a-4d90-9c24-024ebfac6f20", "edb95f70-4b92-448e-9570-5a438d18b78d", "Client", "CLIENT" },
                    { "fb63abec-98f5-448e-8f56-302fafd16df4", "1e5342dd-33bb-4fd3-a7d4-94290ce2236d", "Admin", "ADMIN" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "Address", "Age", "ConcurrencyStamp", "DOB", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "Name", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UrlImages", "UserName", "Zoomlink" },
                values: new object[] { "f0fbf9f0-eb17-4c87-9c76-9de5451f74ae", 0, "Laguna", 23, "e4956eda-ae3a-40ee-82f5-f4ccc60874e8", new DateTime(2023, 4, 12, 9, 33, 2, 733, DateTimeKind.Local).AddTicks(2898), "admin@gmail.com", false, false, null, "Admin", "ADMIN@GMAIL.COM", "ADMIN@GMAIL.COM", "AQAAAAEAACcQAAAAECJz7MiFDpbXZATIVP9YW5zdSs/jU27XIkKLPnyWkdOdDhpKyGkFDYkrS8KsCYLp7A==", null, false, "3d28a24c-848b-4bbf-ab48-36bbb5080d4e", false, "https://www.clipartmax.com/png/middle/319-3191274_male-avatar-admin-profile.png", "admin@gmail.com", null });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "fb63abec-98f5-448e-8f56-302fafd16df4", "f0fbf9f0-eb17-4c87-9c76-9de5451f74ae" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "51d0771e-de96-4882-a01e-8f0b9949e90c");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "5c965850-234a-4d90-9c24-024ebfac6f20");

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "fb63abec-98f5-448e-8f56-302fafd16df4", "f0fbf9f0-eb17-4c87-9c76-9de5451f74ae" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "fb63abec-98f5-448e-8f56-302fafd16df4");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "f0fbf9f0-eb17-4c87-9c76-9de5451f74ae");
        }
    }
}
