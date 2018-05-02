using System;
using MvvmCross.Plugins.Sqlite;
using SQLite;

namespace BCAT_Tracker.Core.Models
{
    public class DataService : IDataService
    {
        private readonly SQLiteConnection _connection;

        public DataService(IMvxSqliteConnectionFactory factory)
        {
            _connection = factory.GetConnection("bcattracker.db3");
            _connection.CreateTable<Logins>();
        }

        public Logins Load()
        {
            return _connection.Table<Logins>().FirstOrDefault();
        }

        public void Save(Logins item)
        {
            _connection.Insert(item);
        }
    }
}