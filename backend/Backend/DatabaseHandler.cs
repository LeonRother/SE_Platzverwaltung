using SQLite;

namespace Backend
{
	public class DatabaseHandler : IDisposable
	{
		public SQLiteConnection Connection { get; private set; }

        public DatabaseHandler()
        {
            Connection = new SQLiteConnection("database.db");
			Connection.Execute("PRAGMA foreign_keys = ON;");
		}

		public void Dispose()
		{
			Connection.Dispose();
		}
	}
}
