using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HR.LeaveManagement.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class ChangedLeavetype : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "LeaveTypes",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2023, 12, 28, 15, 23, 15, 47, DateTimeKind.Local).AddTicks(5090), new DateTime(2023, 12, 28, 15, 23, 15, 47, DateTimeKind.Local).AddTicks(5130) });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "LeaveTypes",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2023, 12, 26, 23, 24, 31, 689, DateTimeKind.Local).AddTicks(8180), new DateTime(2023, 12, 26, 23, 24, 31, 689, DateTimeKind.Local).AddTicks(8240) });
        }
    }
}
