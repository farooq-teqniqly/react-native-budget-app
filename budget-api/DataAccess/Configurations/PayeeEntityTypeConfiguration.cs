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
	/// Entity Framework configuration for the Payee entity.
	/// </summary>
	public class PayeeEntityTypeConfiguration : EntityTypeConfiguration<Payee>
	{
		/// <inheritdoc />
		public override void FurtherConfiguration(EntityTypeBuilder<Payee> builder)
		{
			builder.ToTable("Payee");
			builder.Property(e => e.Name).IsRequired();
			builder.HasIndex(e => e.Name).IsUnique();
		}
	}
}
