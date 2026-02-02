using FlashStudy.Models;
using SQLite;

namespace FlashStudy.Data.Repositories;

public sealed class DeckRepository
{
    private readonly AppDatabase _database;
    private readonly SQLiteAsyncConnection _db;   

    public DeckRepository(AppDatabase database)
    {
        _database = database;
        _db = database.Connection;
    }   
        

    public async Task<List<Deck>> GetAllAsync()
    {
        await _database.InitAsync();
        return await _db.Table<Deck>().OrderByDescending(d => d.UpdatedAt).ToListAsync();
    }

    public async Task<Deck?> GetByIdAsync(int id)
    {
        await _database.InitAsync();
        var deck =  await _db.Table<Deck>().Where(d => d.Id == id).FirstOrDefaultAsync();
        return deck;
    }
        

    public async Task<int> CreateAsync(string name)
    {
        await _database.InitAsync();
        var deck = new Deck
        {
            Name = name.Trim(),
            CreatedAt = DateTime.UtcNow,
            UpdatedAt = DateTime.UtcNow
        };

        await _db.InsertAsync(deck);
        return deck.Id;
    }

    public async Task UpdateAsync(Deck deck)
    {
        await _database.InitAsync();
        deck.UpdatedAt = DateTime.UtcNow;
        await _db.UpdateAsync(deck);
    }

    public async Task DeleteAsync(Deck deck)
    {
        await _database.InitAsync();
        await _db.DeleteAsync(deck);
    }        

    public async Task DeleteByIdAsync(int id)
    {
        await _database.InitAsync();
        await _db.DeleteAsync<Deck>(id);
    }
}
