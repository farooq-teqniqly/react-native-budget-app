// Copyright (c) Farooq Mahmud

namespace DataAccess.Configurations
{
	using DataAccess.Entities;
	using Microsoft.EntityFrameworkCore;
	using Microsoft.EntityFrameworkCore.Metadata.Builders;

	/// <summary>
	/// Entity Framework configuration for the Ledger entity.
	/// </summary>
	public class LedgerEntityTypeConfiguration : EntityTypeConfiguration<Ledger>
	{
		/// <inheritdoc />
		public override void FurtherConfiguration(EntityTypeBuilder<Ledger> builder)
		{
			builder.ToTable("Ledger");
			builder.Property(e => e.Created).IsRequired().ValueGeneratedOnAdd();
			builder.Property(e => e.LastUpdated).IsRequired().ValueGeneratedOnUpdate();

			builder
				.HasOne(ledger => ledger.User)
				.WithOne(user => user.Ledger)
				.HasForeignKey<User>(user => user.Id);

			builder
				.HasMany(ledger => ledger.LedgerEntries)
				.WithOne(entry => entry.Ledger)
				.HasForeignKey(entry => entry.Id);
		}
	}
}
