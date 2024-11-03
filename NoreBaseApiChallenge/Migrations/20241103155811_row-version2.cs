using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NoreBaseApiChallenge.Migrations
{
    public partial class rowversion2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "RowVersion",
                table: "Likes",
                type: "TEXT",
                rowVersion: true,
                nullable: false,
                defaultValue: "DATETIME('now')",
                oldClrType: typeof(byte[]),
                oldType: "BLOB",
                oldRowVersion: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<byte[]>(
                name: "RowVersion",
                table: "Likes",
                type: "BLOB",
                rowVersion: true,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldRowVersion: true,
                oldDefaultValue: "DATETIME('now')");
        }
    }
}
