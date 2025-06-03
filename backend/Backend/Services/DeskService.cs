using Backend.Models;

namespace Backend.Services
{
	public class DeskService
	{
		private readonly DatabaseHandler _db;
		public DeskService(DatabaseHandler databaseHandler)
		{
			_db = databaseHandler;
		}
		public List<Desk> GetAllDesks()
		{
			return _db.Connection.Table<Desk>().ToList();
		}
		public List<Desk> GetDesks(int floorId)
		{
			return _db.Connection.Table<Desk>().Where(desk => desk.FloorID == floorId).ToList();
		}
	}
}