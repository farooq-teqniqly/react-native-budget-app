// Copyright (c) Farooq Mahmud

namespace DataAccess.GraphQL.Schemas
{
	using System;
	using DataAccess.GraphQL.Queries;
	using global::GraphQL.Types;
	using Microsoft.Extensions.DependencyInjection;

	public class RootSchema : Schema
	{
		public RootSchema(IServiceProvider serviceProvider)
			: base(serviceProvider)
		{
			this.Query = serviceProvider.GetRequiredService<RootQuery>();
		}
	}
}
