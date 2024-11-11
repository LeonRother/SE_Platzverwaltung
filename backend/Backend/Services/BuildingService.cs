using Backend.Models;

namespace Backend.Services
{
	public class BuildingService
	{
		private readonly DatabaseHandler _db;
        public BuildingService(DatabaseHandler databaseHandler)
        {
            _db = databaseHandler;
        }

        public List<Building> GetAllBuildings()
        {
            return _db.Connection.Table<Building>().ToList();
        }
    }
}
