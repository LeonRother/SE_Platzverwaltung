using Backend.Models;

namespace Backend.Services
{
	public class BookingService
	{
		private readonly DatabaseHandler _db;
		public BookingService(DatabaseHandler db)
		{
			_db = db;
		}

		public void CreateBooking(Bookings booking)
		{
			_db.Connection.Insert(booking);
		}

	}

}
