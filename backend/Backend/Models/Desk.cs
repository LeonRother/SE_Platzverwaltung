using SQLite;

namespace Backend.Models
{
	[Table("Desks")]
	public class Desk
	{
		public int ID { get; set; }
		public string Label { get; set; }
		public int FloorID { get; set; }
	}
}
