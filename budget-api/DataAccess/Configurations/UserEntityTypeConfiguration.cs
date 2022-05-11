// Copyright (c) Farooq Mahmud

namespace DataAccess.Configurations
{
	using DataAccess.Entities;
	using Microsoft.EntityFrameworkCore;
	using Microsoft.EntityFrameworkCore.Metadata.Builders;

	/// <summary>
	/// Entity Framework configuration for the User entity.
	/// </summary>
	public class UserEntityTypeConfiguration : EntityTypeConfiguration<User>
	{
		/// <inheritdoc />
		public override void FurtherConfiguration(EntityTypeBuilder<User> builder)
		{
			builder.ToTable("User");
			builder.Property(e => e.Created).IsRequired().ValueGeneratedOnAdd();
			builder.Property(e => e.Name).IsRequired();
			builder.HasIndex(e => e.Name).IsUnique();
		}
	}
}