// Copyright (c) Farooq Mahmud

namespace DataAccess.Configurations
{
	using Microsoft.EntityFrameworkCore;
	using Microsoft.EntityFrameworkCore.Metadata.Builders;

	/// <summary>
	/// Base class offering common Entity Framework configuration for entities.
	/// </summary>
	/// <typeparam name="TEntity">The type of entity being configured.</typeparam>
	public abstract class EntityTypeConfiguration<TEntity> : IEntityTypeConfiguration<TEntity>
		where TEntity : class, IEntity
	{
		/// <inheritdoc />
		public void Configure(EntityTypeBuilder<TEntity> builder)
		{
			builder.HasKey(e => e.Id);
			builder.Property(e => e.Id).ValueGeneratedOnAdd();
			this.FurtherConfiguration(builder);
		}

		/// <summary>
		/// Allows subclasses to configure an entity.
		/// </summary>
		/// <param name="builder">The builder used for configuration.</param>
		public abstract void FurtherConfiguration(EntityTypeBuilder<TEntity> builder);
	}
}