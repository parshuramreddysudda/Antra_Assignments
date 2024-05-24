using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ApplicationCore.Migrations
{
    /// <inheritdoc />
    public partial class UpdatedUsernames : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AppUserClaim",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2024, 5, 23, 19, 50, 35, 817, DateTimeKind.Utc).AddTicks(8210), new DateTime(2024, 5, 23, 19, 50, 35, 817, DateTimeKind.Utc).AddTicks(8210) });

            migrationBuilder.UpdateData(
                table: "AppUserClaim",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2024, 5, 23, 19, 50, 35, 817, DateTimeKind.Utc).AddTicks(8210), new DateTime(2024, 5, 23, 19, 50, 35, 817, DateTimeKind.Utc).AddTicks(8210) });

            migrationBuilder.UpdateData(
                table: "AppUserClaim",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2024, 5, 23, 19, 50, 35, 817, DateTimeKind.Utc).AddTicks(8210), new DateTime(2024, 5, 23, 19, 50, 35, 817, DateTimeKind.Utc).AddTicks(8210) });

            migrationBuilder.UpdateData(
                table: "AppUserClaim",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2024, 5, 23, 19, 50, 35, 817, DateTimeKind.Utc).AddTicks(8220), new DateTime(2024, 5, 23, 19, 50, 35, 817, DateTimeKind.Utc).AddTicks(8220) });

            migrationBuilder.UpdateData(
                table: "AppUserClaim",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2024, 5, 23, 19, 50, 35, 817, DateTimeKind.Utc).AddTicks(8220), new DateTime(2024, 5, 23, 19, 50, 35, 817, DateTimeKind.Utc).AddTicks(8220) });

            migrationBuilder.UpdateData(
                table: "AppUserClaim",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2024, 5, 23, 19, 50, 35, 817, DateTimeKind.Utc).AddTicks(8220), new DateTime(2024, 5, 23, 19, 50, 35, 817, DateTimeKind.Utc).AddTicks(8220) });

            migrationBuilder.UpdateData(
                table: "AppUserClaim",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2024, 5, 23, 19, 50, 35, 817, DateTimeKind.Utc).AddTicks(8220), new DateTime(2024, 5, 23, 19, 50, 35, 817, DateTimeKind.Utc).AddTicks(8220) });

            migrationBuilder.UpdateData(
                table: "AppUserClaim",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2024, 5, 23, 19, 50, 35, 817, DateTimeKind.Utc).AddTicks(8220), new DateTime(2024, 5, 23, 19, 50, 35, 817, DateTimeKind.Utc).AddTicks(8220) });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ConcurrencyStamp", "DateCreated", "Email", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "SecurityStamp", "UserName" },
                values: new object[] { "b88559af-9702-426e-81b2-3c4978fd4ba2", new DateTime(2024, 5, 23, 19, 50, 35, 817, DateTimeKind.Utc).AddTicks(8360), "admin@admin.com", "ADMIN@ADMIN.COM", "ADMIN@ADMIN.COM", "AQAAAAIAAYagAAAAEKbg8crFzAk1vP809RkoNzk2R0sDSOdeDDqgnuFYc8QsDtK1nIBAmsT89JundoOeNg==", "124524543645756ascaaf", "Admin" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AppUserClaim",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2024, 5, 23, 3, 22, 26, 999, DateTimeKind.Utc).AddTicks(2180), new DateTime(2024, 5, 23, 3, 22, 26, 999, DateTimeKind.Utc).AddTicks(2180) });

            migrationBuilder.UpdateData(
                table: "AppUserClaim",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2024, 5, 23, 3, 22, 26, 999, DateTimeKind.Utc).AddTicks(2180), new DateTime(2024, 5, 23, 3, 22, 26, 999, DateTimeKind.Utc).AddTicks(2180) });

            migrationBuilder.UpdateData(
                table: "AppUserClaim",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2024, 5, 23, 3, 22, 26, 999, DateTimeKind.Utc).AddTicks(2180), new DateTime(2024, 5, 23, 3, 22, 26, 999, DateTimeKind.Utc).AddTicks(2180) });

            migrationBuilder.UpdateData(
                table: "AppUserClaim",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2024, 5, 23, 3, 22, 26, 999, DateTimeKind.Utc).AddTicks(2180), new DateTime(2024, 5, 23, 3, 22, 26, 999, DateTimeKind.Utc).AddTicks(2180) });

            migrationBuilder.UpdateData(
                table: "AppUserClaim",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2024, 5, 23, 3, 22, 26, 999, DateTimeKind.Utc).AddTicks(2180), new DateTime(2024, 5, 23, 3, 22, 26, 999, DateTimeKind.Utc).AddTicks(2180) });

            migrationBuilder.UpdateData(
                table: "AppUserClaim",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2024, 5, 23, 3, 22, 26, 999, DateTimeKind.Utc).AddTicks(2180), new DateTime(2024, 5, 23, 3, 22, 26, 999, DateTimeKind.Utc).AddTicks(2180) });

            migrationBuilder.UpdateData(
                table: "AppUserClaim",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2024, 5, 23, 3, 22, 26, 999, DateTimeKind.Utc).AddTicks(2180), new DateTime(2024, 5, 23, 3, 22, 26, 999, DateTimeKind.Utc).AddTicks(2180) });

            migrationBuilder.UpdateData(
                table: "AppUserClaim",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2024, 5, 23, 3, 22, 26, 999, DateTimeKind.Utc).AddTicks(2190), new DateTime(2024, 5, 23, 3, 22, 26, 999, DateTimeKind.Utc).AddTicks(2190) });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ConcurrencyStamp", "DateCreated", "Email", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "SecurityStamp", "UserName" },
                values: new object[] { "356a5dc3-28e0-4325-896d-212fcf4d4bd5", new DateTime(2024, 5, 23, 3, 22, 26, 999, DateTimeKind.Utc).AddTicks(2340), null, null, null, "AQAAAAIAAYagAAAAEOhzYtGqyV3TTmLl379MHU8rEl/FmH+dnxPDHkE0LzWNmcD5WFp5RAJQ3UTCdCCMNA==", null, "admin@admin.com" });
        }
    }
}
