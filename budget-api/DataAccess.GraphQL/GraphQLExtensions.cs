// Copyright (c) Farooq Mahmud

namespace DataAccess.GraphQL
{
	using System;
	using global::GraphQL;

	public static class GraphQLExtensions
	{
		public static TType EnsureGetArgument<TType>(this IResolveFieldContext context, string argumentName)
		{
			var result = context.GetArgument<TType>(argumentName);

			if (result == null)
			{
				throw new ArgumentException($"Argument '{argumentName}' cannot be null.");
			}

			return result;
		}
	}
}
