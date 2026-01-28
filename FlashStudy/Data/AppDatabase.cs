using SQLite;
using FlashStudy.Models;

namespace FlashStudy.Data
{
    public sealed class AppDatabase
    {
        private readonly SQLiteAsyncConnection _db;

        public AppDatabase(string dbPath)
        {
            _db = new SQLiteAsyncConnection(dbPath);
        }

        public async Task InitAsync()
        {
            await _db.CreateTableAsync<Deck>();
            await _db.CreateTableAsync<Card>();
            await SeedData.EnsureSystemDesignDeckAsync(_db);
            await SeedData.EnsureSoftwareEngineerDeckAsync(_db);
        }

        public SQLiteAsyncConnection Connection => _db;
    }
}
