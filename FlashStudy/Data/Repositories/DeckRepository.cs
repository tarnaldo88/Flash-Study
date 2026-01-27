using FlashStudy.Models;
using SQLite;

namespace FlashStudy.Data.Repositories;

public sealed class DeckRepository
{
    private readonly SQLiteAsyncConnection _db;

    public DeckRepository(AppDatabase database)
        => _db = database.Connection;

    public Task<List<Deck>> GetAllAsync()
        => _db.Table<Deck>().OrderByDescending(d => d.UpdatedAt).ToListAsync();

    public async Task<Deck?> GetByIdAsync(int id)
    {
        var deck =  await _db.Table<Deck>().Where(d => d.Id == id).FirstOrDefaultAsync();
        return deck;
    }
        

    public async Task<int> CreateAsync(string name)
    {
        var deck = new Deck
        {
            Name = name.Trim(),
            CreatedAt = DateTime.UtcNow,
            UpdatedAt = DateTime.UtcNow
        };

        await _db.InsertAsync(deck);
        return deck.Id;
    }

    public Task UpdateAsync(Deck deck)
    {
        deck.UpdatedAt = DateTime.UtcNow;
        return _db.UpdateAsync(deck);
    }

    public Task DeleteAsync(Deck deck)
        => _db.DeleteAsync(deck);

    public Task DeleteByIdAsync(int id)
        => _db.DeleteAsync<Deck>(id);
}