using SQLite;

namespace Backend.Models
{
    [Table("Buildings")]
	public class Building
	{
        [PrimaryKey, AutoIncrement]
        [Column("ID")]
        public int ID { get; set; }

        [NotNull]
        [Column("Label")]
        public string? Label { get; set; }
    }
}
