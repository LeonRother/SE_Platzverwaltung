using SQLite;

namespace Backend.Models
{
	[Table("Floors")]
	public class Floor
	{
        [PrimaryKey, AutoIncrement]
		[Column("ID")]
        public int ID { get; set; }

        [NotNull]
        [Column("Label")]
        public string? Label { get; set; }

        // Foreign key
        [NotNull]
        [Column("BuildingID")]
        public int BuildingID { get; set; }
    }
}
