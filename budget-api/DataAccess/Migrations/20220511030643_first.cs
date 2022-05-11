using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccess.Migrations
{
	public partial class first : Migration
	{
		protected override void Up(MigrationBuilder migrationBuilder)
		{
			migrationBuilder.CreateTable(
				name: "Category",
				columns: table => new
				{
					Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
					Name = table.Column<string>(type: "nvarchar(450)", nullable: false)
				},
				constraints: table =>
				{
					table.PrimaryKey("PK_Category", x => x.Id);
				});

			migrationBuilder.CreateTable(
				name: "Payee",
				columns: table => new
				{
					Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
					Name = table.Column<string>(type: "nvarchar(450)", nullable: false)
				},
				constraints: table =>
				{
					table.PrimaryKey("PK_Payee", x => x.Id);
				});

			migrationBuilder.CreateTable(
				name: "User",
				columns: table => new
				{
					Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
					Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
					Created = table.Column<DateTime>(type: "datetime2", nullable: false)
				},
				constraints: table =>
				{
					table.PrimaryKey("PK_User", x => x.Id);
				});

			migrationBuilder.CreateTable(
				name: "Ledger",
				columns: table => new
				{
					Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
					Created = table.Column<DateTime>(type: "datetime2", nullable: false),
					LastUpdated = table.Column<DateTime>(type: "datetime2", nullable: false),
					UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
				},
				constraints: table =>
				{
					table.PrimaryKey("PK_Ledger", x => x.Id);
					table.ForeignKey(
						name: "FK_Ledger_User_UserId",
						column: x => x.UserId,
						principalTable: "User",
						principalColumn: "Id",
						onDelete: ReferentialAction.Cascade);
				});

			migrationBuilder.CreateTable(
				name: "LedgerEntry",
				columns: table => new
				{
					Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
					EntryDate = table.Column<DateTime>(type: "datetime2", nullable: false),
					Amount = table.Column<decimal>(type: "decimal(10,2)", precision: 10, scale: 2, nullable: false),
					IsIncome = table.Column<bool>(type: "bit", nullable: false),
					PayeeId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
					CategoryId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
					LedgerId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
				},
				constraints: table =>
				{
					table.PrimaryKey("PK_LedgerEntry", x => x.Id);
					table.ForeignKey(
						name: "FK_LedgerEntry_Category_CategoryId",
						column: x => x.CategoryId,
						principalTable: "Category",
						principalColumn: "Id",
						onDelete: ReferentialAction.Cascade);
					table.ForeignKey(
						name: "FK_LedgerEntry_Ledger_LedgerId",
						column: x => x.LedgerId,
						principalTable: "Ledger",
						principalColumn: "Id");
					table.ForeignKey(
						name: "FK_LedgerEntry_Payee_PayeeId",
						column: x => x.PayeeId,
						principalTable: "Payee",
						principalColumn: "Id",
						onDelete: ReferentialAction.Cascade);
				});

			migrationBuilder.CreateIndex(
				name: "IX_Category_Name",
				table: "Category",
				column: "Name",
				unique: true);

			migrationBuilder.CreateIndex(
				name: "IX_Ledger_UserId",
				table: "Ledger",
				column: "UserId");

			migrationBuilder.CreateIndex(
				name: "IX_LedgerEntry_CategoryId",
				table: "LedgerEntry",
				column: "CategoryId");

			migrationBuilder.CreateIndex(
				name: "IX_LedgerEntry_LedgerId",
				table: "LedgerEntry",
				column: "LedgerId");

			migrationBuilder.CreateIndex(
				name: "IX_LedgerEntry_PayeeId",
				table: "LedgerEntry",
				column: "PayeeId");

			migrationBuilder.CreateIndex(
				name: "IX_Payee_Name",
				table: "Payee",
				column: "Name",
				unique: true);

			migrationBuilder.CreateIndex(
				name: "IX_User_Name",
				table: "User",
				column: "Name",
				unique: true);
		}

		protected override void Down(MigrationBuilder migrationBuilder)
		{
			migrationBuilder.DropTable(
				name: "LedgerEntry");

			migrationBuilder.DropTable(
				name: "Category");

			migrationBuilder.DropTable(
				name: "Ledger");

			migrationBuilder.DropTable(
				name: "Payee");

			migrationBuilder.DropTable(
				name: "User");
		}
	}
}
