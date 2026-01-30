using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using FlashStudy.Data.Repositories;
using FlashStudy.Models;

namespace FlashStudy.ViewModels;

[QueryProperty(nameof(DeckId), "deckId")]
[QueryProperty(nameof(CardId), "cardId")]
public partial class EditCardViewModel : ObservableObject
{
    private readonly CardRepository _cards;
    private readonly DeckRepository _decks;

    [ObservableProperty]
    public partial int DeckId { get; set; }

    [ObservableProperty]
    public partial int CardId { get; set; }

    [ObservableProperty]
    public partial string Front { get; set; } = "";

    [ObservableProperty]
    public partial string Back { get; set; } = "";

    [ObservableProperty]
    public partial string DeckName { get; set; } = "";

    public EditCardViewModel(CardRepository cards, DeckRepository decks)
    {
        _cards = cards;
        _decks = decks;
    }

    [RelayCommand]
    public async Task LoadAsync()
    {
        if (CardId > 0)
        {
            var card = await _cards.GetByIdAsync(CardId);
            if (card is null) return;

            Front = card.Front;
            Back = card.Back;
            DeckId = card.DeckId;
        }
        else
        {
            Front = "";
            Back = "";
        }

        if (DeckId > 0)
        {
            var deck = await _decks.GetByIdAsync(DeckId);
            DeckName = deck?.Name ?? "";
        }
        else
        {
            DeckName = "";
        }
    }

    [RelayCommand]
    public async Task SaveAsync()
    {
        var f = (Front ?? "").Trim();
        var b = (Back ?? "").Trim();

        if (string.IsNullOrWhiteSpace(f) || string.IsNullOrWhiteSpace(b))
        {
            await Shell.Current.DisplayAlertAsync("Missing fields", "Front and Back are required.", "OK");
            return;
        }

        if (CardId <= 0)
        {
            await _cards.CreateAsync(DeckId, f, b);
        }
        else
        {
            var existing = await _cards.GetByIdAsync(CardId);
            if (existing is null) return;

            existing.Front = f;
            existing.Back = b;
            await _cards.UpdateAsync(existing);
        }

        await Shell.Current.GoToAsync("..");
    }
}
