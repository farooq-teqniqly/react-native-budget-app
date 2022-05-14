// Copyright (c) Farooq Mahmud

namespace Services
{
	/// <summary>
	/// A service that provides the current date and time.
	/// </summary>
	public class DateTimeService : IDateTimeService
	{
		/// <inheritdoc />
		public DateTime DateTime => DateTime.UtcNow;
	}
}