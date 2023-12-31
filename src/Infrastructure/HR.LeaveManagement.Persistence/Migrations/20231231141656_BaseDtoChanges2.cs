using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HR.LeaveManagement.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class BaseDtoChanges2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "LeaveTypes",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2023, 12, 31, 15, 16, 55, 993, DateTimeKind.Local).AddTicks(7060), new DateTime(2023, 12, 31, 15, 16, 55, 993, DateTimeKind.Local).AddTicks(7110) });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "LeaveTypes",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2023, 12, 31, 15, 10, 1, 927, DateTimeKind.Local).AddTicks(4960), new DateTime(2023, 12, 31, 15, 10, 1, 927, DateTimeKind.Local).AddTicks(5010) });
        }
    }
}
