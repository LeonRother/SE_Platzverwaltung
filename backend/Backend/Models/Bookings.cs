using SQLite;

namespace Backend.Models
{
    [Table("Bookings")]
	public class Bookings
	{
		[PrimaryKey, AutoIncrement]
		public int Id { get; set; }

		public int DeskId { get; set; }

		public string Date { get; set; } // Format: YYYY-MM-DD

		public int UserId { get; set; }  // Platzhalter
	}
}
