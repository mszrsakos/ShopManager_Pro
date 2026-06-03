using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopManagerPro.Models
{
    public class GenericRepository<T> : IGenericRepository<T> where T : new()
    {
        private readonly string _databasePath;
        public GenericRepository(string databasePath)
        {
            _databasePath = databasePath;
        }

        public void delete(T item)
        {
            using (SQLite.SQLiteConnection connection = new SQLite.SQLiteConnection(_databasePath))
            {
                connection.CreateTable<T>();
                connection.Delete(item);
            }
        }

        public List<T> GetAll()
        {
            using (SQLite.SQLiteConnection connection = new SQLite.SQLiteConnection(_databasePath))
            {
                connection.CreateTable<T>();
                return connection.Table<T>().ToList();
            }
        }

        public void insert(T item)
        {
            using (SQLite.SQLiteConnection connection = new SQLite.SQLiteConnection(_databasePath))
            {
                connection.CreateTable<T>();
                connection.Insert(item);
            }
        }

        public void update(T item)
        {
            using (SQLite.SQLiteConnection connection = new SQLite.SQLiteConnection(_databasePath))
            {
                connection.CreateTable<T>();
                connection.Update(item);
            }
        }
    }
}
