using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HR.LeaveManagement.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class BaseDtoChanges3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "LeaveTypes",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2023, 12, 31, 16, 10, 51, 447, DateTimeKind.Local).AddTicks(9200), new DateTime(2023, 12, 31, 16, 10, 51, 447, DateTimeKind.Local).AddTicks(9250) });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "LeaveTypes",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2023, 12, 31, 15, 16, 55, 993, DateTimeKind.Local).AddTicks(7060), new DateTime(2023, 12, 31, 15, 16, 55, 993, DateTimeKind.Local).AddTicks(7110) });
        }
    }
}
