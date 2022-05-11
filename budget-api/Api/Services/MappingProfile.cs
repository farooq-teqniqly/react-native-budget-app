// Copyright (c) Farooq Mahmud

namespace Api.Services
{
	using Api.Models;
	using AutoMapper;
	using DataAccess.Entities;

	/// <summary>
	/// The AutoMapper mapping profile.
	/// </summary>
	public class MappingProfile : Profile
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="MappingProfile"/> class.
		/// </summary>
		public MappingProfile()
		{
			this.CreateMap<CreateLedgerRequest, Ledger>();
			this.CreateMap<Ledger, CreateLedgerResponse>();
			this.CreateMap<Ledger, GetLedgerResponse>();
			this.CreateMap<Category[], GetCategoryResponse[]>();
			this.CreateMap<CreateCategoryRequest, Category>();
			this.CreateMap<Category, CreateCategoryResponse>();
		}
	}
}
