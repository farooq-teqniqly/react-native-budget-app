// Copyright (c) Farooq Mahmud

namespace DataAccess.GraphQL.Schemas
{
	using System;
	using DataAccess.GraphQL.Mutations;
	using DataAccess.GraphQL.Queries;
	using global::GraphQL.Types;
	using Microsoft.Extensions.DependencyInjection;

	/// <summary>
	/// The GraphQL root schema.
	/// </summary>
	public class RootSchema : Schema
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="RootSchema"/> class.
		/// </summary>
		/// <param name="serviceProvider">The dependency injector.</param>
		public RootSchema(IServiceProvider serviceProvider)
			: base(serviceProvider)
		{
			this.Query = serviceProvider.GetRequiredService<RootQuery>();
			this.Mutation = serviceProvider.GetRequiredService<RootMutation>();
		}
	}
}
