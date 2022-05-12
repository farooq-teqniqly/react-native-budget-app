// Copyright (c) Farooq Mahmud
namespace DataAccess.Configurations
{
	using DataAccess.Entities;
	using Microsoft.EntityFrameworkCore;
	using Microsoft.EntityFrameworkCore.Metadata.Builders;

	/// <summary>
	/// Entity Framework configuration for the Category entity.
	/// </summary>
	public class CategoryEntityTypeConfiguration : EntityTypeConfiguration<Category>
	{
		/// <inheritdoc />
		public override void FurtherConfiguration(EntityTypeBuilder<Category> builder)
		{
			builder.ToTable("Category");
			builder.Property(e => e.Name).IsRequired();
			builder.HasIndex(e => e.Name).IsUnique();
		}
	}
}
