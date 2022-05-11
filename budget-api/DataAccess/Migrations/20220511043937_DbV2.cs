// Copyright (c) Farooq Mahmud

#nullable disable

namespace DataAccess.Migrations
{
	using Microsoft.EntityFrameworkCore.Migrations;

	/// <summary>
	/// Database migration version 2.
	/// </summary>
	public partial class DbV2 : Migration
	{
		/// <inheritdoc/>
		protected override void Up(MigrationBuilder migrationBuilder)
		{
			migrationBuilder.AddColumn<string>(
				name: "Name",
				table: "Ledger",
				type: "nvarchar(450)",
				nullable: false,
				defaultValue: string.Empty);

			migrationBuilder.CreateIndex(
				name: "IX_Ledger_Name",
				table: "Ledger",
				column: "Name",
				unique: true);
		}

		/// <inheritdoc/>
		protected override void Down(MigrationBuilder migrationBuilder)
		{
			migrationBuilder.DropIndex(
				name: "IX_Ledger_Name",
				table: "Ledger");

			migrationBuilder.DropColumn(
				name: "Name",
				table: "Ledger");
		}
	}
}
