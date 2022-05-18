// Copyright (c) Farooq Mahmud

#nullable disable

namespace DataAccess.Migrations
{
	using Microsoft.EntityFrameworkCore.Migrations;

	/// <summary>
	/// Database migration V2.
	/// </summary>
	public partial class DbV2 : Migration
	{
		/// <inheritdoc/>
		protected override void Up(MigrationBuilder migrationBuilder)
		{
			migrationBuilder.AddColumn<string>(
				name: "Description",
				table: "LedgerEntry",
				type: "nvarchar(max)",
				nullable: false);
		}

		/// <inheritdoc/>
		protected override void Down(MigrationBuilder migrationBuilder)
		{
			migrationBuilder.DropColumn(
				name: "Description",
				table: "LedgerEntry");
		}
	}
}
