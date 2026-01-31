using FlashStudy.Models;
using SQLite;

namespace FlashStudy.Data.Repositories;

public sealed class CardRepository
{
    private readonly SQLiteAsyncConnection _db;

    public CardRepository(AppDatabase database)
        => _db = database.Connection;

    public Task<List<Card>> GetByDeckIdAsync(int deckId)
        => _db.Table<Card>().Where(c => c.DeckId == deckId).OrderBy(c => c.Id).ToListAsync();

    public Task<int> CountByDeckIdAsync(int deckId)
        => _db.Table<Card>().Where(c => c.DeckId == deckId).CountAsync();

    public async Task<Card?> GetByIdAsync(int id)
    {
        var card = await _db.Table<Card>()
            .Where(c => c.Id == id)
            .FirstOrDefaultAsync()
            .ConfigureAwait(false);

        return card;
    }

    public async Task<int> CreateAsync(int deckId, string front, string back)
    {
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

    public Task UpdateAsync(Card card)
    {
        card.UpdatedAt = DateTime.UtcNow;
        return _db.UpdateAsync(card);
    }

    public Task DeleteAsync(Card card)
        => _db.DeleteAsync(card);

    public Task DeleteByIdAsync(int id)
        => _db.DeleteAsync<Card>(id);

    public Task<int> DeleteByDeckIdAsync(int deckId)
        => _db.ExecuteAsync("DELETE FROM Cards WHERE DeckId = ?", deckId);
}
