using Backend.Models;

namespace Backend.Services
{
	public class FloorService
	{
		private readonly DatabaseHandler _db;
		public FloorService(DatabaseHandler databaseHandler)
		{
			_db = databaseHandler;
		}

		public List<Floor> GetAllFloors()
		{
			return _db.Connection.Table<Floor>().ToList();
		}

		public List<Floor> GetFloors(int id)
		{
			return _db.Connection.Table<Floor>().Where(floor => floor.BuildingID == id).ToList();
		}
	}
}
