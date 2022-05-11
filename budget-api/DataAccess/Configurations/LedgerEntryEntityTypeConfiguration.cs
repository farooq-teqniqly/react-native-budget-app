// Copyright (c) Farooq Mahmud

namespace DataAccess.Configurations
{
	using System;
	using System.Collections.Generic;
	using System.Linq;
	using System.Text;
	using System.Threading.Tasks;
	using DataAccess.Entities;
	using Microsoft.EntityFrameworkCore;
	using Microsoft.EntityFrameworkCore.Metadata.Builders;

	/// <summary>
	/// Entity Framework configuration for the LedgerEntry entity.
	/// </summary>
	public class LedgerEntryEntityTypeConfiguration : EntityTypeConfiguration<LedgerEntry>
	{
		/// <inheritdoc />
		public override void FurtherConfiguration(EntityTypeBuilder<LedgerEntry> builder)
		{
			builder.ToTable("LedgerEntry");
			builder.Property(e => e.EntryDate).IsRequired();
			builder.Property(e => e.Amount).IsRequired().HasPrecision(10, 2);
			builder.Property(e => e.IsIncome).IsRequired();
		}
	}
}
