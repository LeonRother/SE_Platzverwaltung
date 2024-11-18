using SQLite;

namespace Backend.Models
{
	[Table("Employees")]
	public class Employee
	{
		[PrimaryKey, AutoIncrement]
		[Column("ID")]
		public int Id { get; set; }

		[Column("Lastname")]
		public string Lastname { get; set; }

		[Column("Firstname")]
		public string Firstname { get; set; }

		[Column("E-Mail")]
		public string Email { get; set; }

		[Column("Password")]
		public string? Password { get; set; }

		[Column("Role")]
		public string Role { get; set; } // Enum is enforced with CHECK constraints

		[Column("OrganizationID")]
		public int OrganizationId { get; set; }
	}

	//public enum Role
	//{
	//	USER,
	//	LOCAL_ADMIN,
	//	GLOBAL_ADMIN
	//}
}
