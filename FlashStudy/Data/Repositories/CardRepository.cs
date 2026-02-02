using FlashStudy.Models;
using SQLite;

namespace FlashStudy.Data.Repositories;

public sealed class CardRepository
{
    private readonly AppDatabase _database;
    private readonly SQLiteAsyncConnection _db;

    public CardRepository(AppDatabase database)
    {
        _database = database;
        _db = database.Connection;
    }

    public async Task<List<Card>> GetByDeckIdAsync(int deckId)
    {
        await _database.InitAsync();
        return await _db.Table<Card>().Where(c => c.DeckId == deckId).OrderBy(c => c.Id).ToListAsync();
    }

    public async Task<int> CountByDeckIdAsync(int deckId)
    {
        await _database.InitAsync();
        return await _db.Table<Card>().Where(c => c.DeckId == deckId).CountAsync();
    }

    public async Task<Card?> GetByIdAsync(int id)
    {
        await _database.InitAsync();
        var card = await _db.Table<Card>()
            .Where(c => c.Id == id)
            .FirstOrDefaultAsync()
            .ConfigureAwait(false);

        return card;
    }

    public async Task<int> CreateAsync(int deckId, string front, string back)
    {
        await _database.InitAsync();
        var card = new Card
        {
            DeckId = deckId,
            Front = front.Trim(),
            Back = back.Trim(),
            CreatedAt = DateTime.UtcNow,
            UpdatedAt = DateTime.UtcNow
        };

        await _db.InsertAsync(card);
        return card.Id;
    }

    public async Task UpdateAsync(Card card)
    {
        await _database.InitAsync();
        card.UpdatedAt = DateTime.UtcNow;
        await _db.UpdateAsync(card);
    }

    public async Task DeleteAsync(Card card)
    {
        await _database.InitAsync();
        await _db.DeleteAsync(card);
    }

    public async Task DeleteByIdAsync(int id)
    {
        await _database.InitAsync();
        await _db.DeleteAsync<Card>(id);
    }

    public async Task<int> DeleteByDeckIdAsync(int deckId)
    {
        await _database.InitAsync();
        return await _db.ExecuteAsync("DELETE FROM Cards WHERE DeckId = ?", deckId);
    }
}
