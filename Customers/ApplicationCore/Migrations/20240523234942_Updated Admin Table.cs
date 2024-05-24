using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ApplicationCore.Migrations
{
    /// <inheritdoc />
    public partial class UpdatedAdminTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CustomerId",
                table: "AspNetUsers",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Gender",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Phone",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "ProfilePic",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "AppUserClaim",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2024, 5, 23, 23, 49, 42, 186, DateTimeKind.Utc).AddTicks(9060), new DateTime(2024, 5, 23, 23, 49, 42, 186, DateTimeKind.Utc).AddTicks(9070) });

            migrationBuilder.UpdateData(
                table: "AppUserClaim",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2024, 5, 23, 23, 49, 42, 186, DateTimeKind.Utc).AddTicks(9070), new DateTime(2024, 5, 23, 23, 49, 42, 186, DateTimeKind.Utc).AddTicks(9070) });

            migrationBuilder.UpdateData(
                table: "AppUserClaim",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2024, 5, 23, 23, 49, 42, 186, DateTimeKind.Utc).AddTicks(9070), new DateTime(2024, 5, 23, 23, 49, 42, 186, DateTimeKind.Utc).AddTicks(9070) });

            migrationBuilder.UpdateData(
                table: "AppUserClaim",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2024, 5, 23, 23, 49, 42, 186, DateTimeKind.Utc).AddTicks(9070), new DateTime(2024, 5, 23, 23, 49, 42, 186, DateTimeKind.Utc).AddTicks(9070) });

            migrationBuilder.UpdateData(
                table: "AppUserClaim",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2024, 5, 23, 23, 49, 42, 186, DateTimeKind.Utc).AddTicks(9070), new DateTime(2024, 5, 23, 23, 49, 42, 186, DateTimeKind.Utc).AddTicks(9070) });

            migrationBuilder.UpdateData(
                table: "AppUserClaim",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2024, 5, 23, 23, 49, 42, 186, DateTimeKind.Utc).AddTicks(9070), new DateTime(2024, 5, 23, 23, 49, 42, 186, DateTimeKind.Utc).AddTicks(9070) });

            migrationBuilder.UpdateData(
                table: "AppUserClaim",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2024, 5, 23, 23, 49, 42, 186, DateTimeKind.Utc).AddTicks(9070), new DateTime(2024, 5, 23, 23, 49, 42, 186, DateTimeKind.Utc).AddTicks(9070) });

            migrationBuilder.UpdateData(
                table: "AppUserClaim",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2024, 5, 23, 23, 49, 42, 186, DateTimeKind.Utc).AddTicks(9070), new DateTime(2024, 5, 23, 23, 49, 42, 186, DateTimeKind.Utc).AddTicks(9070) });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ConcurrencyStamp", "CustomerId", "DateCreated", "Gender", "PasswordHash", "Phone", "ProfilePic", "UserId" },
                values: new object[] { "756789fd-2371-4e9d-9956-2d39cfd180fe", 0, new DateTime(2024, 5, 23, 23, 49, 42, 186, DateTimeKind.Utc).AddTicks(9210), "", "AQAAAAIAAYagAAAAEFVlp1I6f3m8U7mBpgBWVZ+oWRjsBAbNPBsHIlyq2z5JGzLjuIEiiHBxk+joYtfxMw==", "", "", "0b11ede9-4119-4987-bccd-aa22625e386e" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CustomerId",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "Gender",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "Phone",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "ProfilePic",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "AspNetUsers");

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
                columns: new[] { "ConcurrencyStamp", "DateCreated", "PasswordHash" },
                values: new object[] { "b88559af-9702-426e-81b2-3c4978fd4ba2", new DateTime(2024, 5, 23, 19, 50, 35, 817, DateTimeKind.Utc).AddTicks(8360), "AQAAAAIAAYagAAAAEKbg8crFzAk1vP809RkoNzk2R0sDSOdeDDqgnuFYc8QsDtK1nIBAmsT89JundoOeNg==" });
        }
    }
}
