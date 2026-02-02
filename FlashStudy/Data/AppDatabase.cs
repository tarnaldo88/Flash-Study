using SQLite;
using FlashStudy.Models;

namespace FlashStudy.Data
{
    public sealed class AppDatabase
    {
        private readonly SQLiteAsyncConnection _db;
        private Task? _initTask;
        private readonly object _initLock = new();

        public AppDatabase(string dbPath)
        {
            _db = new SQLiteAsyncConnection(dbPath);
        }

        public Task InitAsync()
        {
            lock (_initLock)
            {
                _initTask ??= InitInternalAsync();
            }

            return _initTask;
        }

        private async Task InitInternalAsync()
        {
            await _db.CreateTableAsync<Deck>();
            await _db.CreateTableAsync<Card>();
            await SeedData.EnsureSystemDesignDeckAsync(_db);
            await SeedData.EnsureSoftwareEngineerDeckAsync(_db);
            await SeedData.EnsureCSharpDeckAsync(_db);
            await SeedData.EnsureGoDeckAsync(_db);
        }

        public SQLiteAsyncConnection Connection => _db;
    }
}
