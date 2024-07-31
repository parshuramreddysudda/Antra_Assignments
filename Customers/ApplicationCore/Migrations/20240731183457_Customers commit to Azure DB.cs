using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ApplicationCore.Migrations
{
    /// <inheritdoc />
    public partial class CustomerscommittoAzureDB : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AppUserClaim",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2024, 7, 31, 18, 34, 57, 220, DateTimeKind.Utc).AddTicks(8130), new DateTime(2024, 7, 31, 18, 34, 57, 220, DateTimeKind.Utc).AddTicks(8130) });

            migrationBuilder.UpdateData(
                table: "AppUserClaim",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2024, 7, 31, 18, 34, 57, 220, DateTimeKind.Utc).AddTicks(8130), new DateTime(2024, 7, 31, 18, 34, 57, 220, DateTimeKind.Utc).AddTicks(8130) });

            migrationBuilder.UpdateData(
                table: "AppUserClaim",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2024, 7, 31, 18, 34, 57, 220, DateTimeKind.Utc).AddTicks(8130), new DateTime(2024, 7, 31, 18, 34, 57, 220, DateTimeKind.Utc).AddTicks(8130) });

            migrationBuilder.UpdateData(
                table: "AppUserClaim",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2024, 7, 31, 18, 34, 57, 220, DateTimeKind.Utc).AddTicks(8130), new DateTime(2024, 7, 31, 18, 34, 57, 220, DateTimeKind.Utc).AddTicks(8130) });

            migrationBuilder.UpdateData(
                table: "AppUserClaim",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2024, 7, 31, 18, 34, 57, 220, DateTimeKind.Utc).AddTicks(8130), new DateTime(2024, 7, 31, 18, 34, 57, 220, DateTimeKind.Utc).AddTicks(8130) });

            migrationBuilder.UpdateData(
                table: "AppUserClaim",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2024, 7, 31, 18, 34, 57, 220, DateTimeKind.Utc).AddTicks(8140), new DateTime(2024, 7, 31, 18, 34, 57, 220, DateTimeKind.Utc).AddTicks(8140) });

            migrationBuilder.UpdateData(
                table: "AppUserClaim",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2024, 7, 31, 18, 34, 57, 220, DateTimeKind.Utc).AddTicks(8140), new DateTime(2024, 7, 31, 18, 34, 57, 220, DateTimeKind.Utc).AddTicks(8140) });

            migrationBuilder.UpdateData(
                table: "AppUserClaim",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2024, 7, 31, 18, 34, 57, 220, DateTimeKind.Utc).AddTicks(8140), new DateTime(2024, 7, 31, 18, 34, 57, 220, DateTimeKind.Utc).AddTicks(8140) });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ConcurrencyStamp", "DateCreated", "PasswordHash", "UserId" },
                values: new object[] { "0fe7af3a-0850-4439-af65-cd75d33843cf", new DateTime(2024, 7, 31, 18, 34, 57, 220, DateTimeKind.Utc).AddTicks(8330), "AQAAAAIAAYagAAAAEKLd9nnf8Gw1YNT/o0AGFsA6ORJPkpk5dcrtWt9pKeJih6jeA41StISsiBq8D556GA==", "6788bdcb-87b5-4a04-917f-7e75fe70a61b" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
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
                columns: new[] { "ConcurrencyStamp", "DateCreated", "PasswordHash", "UserId" },
                values: new object[] { "756789fd-2371-4e9d-9956-2d39cfd180fe", new DateTime(2024, 5, 23, 23, 49, 42, 186, DateTimeKind.Utc).AddTicks(9210), "AQAAAAIAAYagAAAAEFVlp1I6f3m8U7mBpgBWVZ+oWRjsBAbNPBsHIlyq2z5JGzLjuIEiiHBxk+joYtfxMw==", "0b11ede9-4119-4987-bccd-aa22625e386e" });
        }
    }
}
