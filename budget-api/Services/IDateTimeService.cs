// Copyright (c) Farooq Mahmud

namespace Services
{
	/// <summary>
	/// An interface for services providing a DateTime.
	/// </summary>
	public interface IDateTimeService
	{
		/// <summary>
		/// Gets the current date and time.
		/// </summary>
		public DateTime DateTime { get; }
	}
}
