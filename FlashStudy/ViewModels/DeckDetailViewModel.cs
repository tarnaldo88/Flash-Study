using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using FlashStudy.Data.Repositories;
using FlashStudy.Models;
using FlashStudy.Views;
using System.Collections.ObjectModel;

namespace FlashStudy.ViewModels;

[QueryProperty(nameof(DeckId), "deckId")]
public partial class DeckDetailViewModel : ObservableObject
{
    private readonly DeckRepository _decks;
    private readonly CardRepository _cards;
    private List<Card> _allCards = new();

    [ObservableProperty]
    public partial int DeckCount { get; set; } = default;

    [ObservableProperty]
    public partial int DeckId { get; set; }

    [ObservableProperty]
    public partial Deck? Deck { get; set; }

    [ObservableProperty]
    public partial string SearchText { get; set; } = "";

    public ObservableCollection<Card> Cards { get; } = new();

    public DeckDetailViewModel(DeckRepository decks, CardRepository cards)
    {
        _decks = decks;
        _cards = cards;
    }

    partial void OnDeckIdChanged(int value)
    {
        // intentionally empty; call LoadAsync on appearing
    }

    [RelayCommand]
    public async Task LoadAsync()
    {
        Deck = await _decks.GetByIdAsync(DeckId);

        _allCards = await _cards.GetByDeckIdAsync(DeckId);
        DeckCount = _allCards.Count;
        ApplyFilter();
    }

    [RelayCommand]
    public Task AddCardAsync()
    {
        DeckCount++;
        return Shell.Current.GoToAsync($"{nameof(EditCardPage)}?deckId={DeckId}");
    }        

    [RelayCommand]
    public Task EditCardAsync(Card? card)
        => card is null
            ? Task.CompletedTask
            : Shell.Current.GoToAsync($"{nameof(EditCardPage)}?deckId={DeckId}&cardId={card.Id}");

    [RelayCommand]
    public Task StudyAsync()
        => Shell.Current.GoToAsync($"{nameof(StudyPage)}?deckId={DeckId}");

    [RelayCommand]
    public async Task DeleteCardAsync(Card? card)
    {
        if (card is null) return;

        var ok = await Shell.Current.DisplayAlertAsync("Delete card?", "Delete this card?", "Delete", "Cancel");
        if (!ok) return;

        DeckCount--;
        await _cards.DeleteAsync(card);
        await LoadAsync();
    }

    [RelayCommand]
    public async Task DeleteDeckAsync(Deck? deck)
    {
        if(deck is null) return;

        var ok = await Shell.Current.DisplayAlertAsync(
            "Delete deck?",
            $"Delete `{deck.Name}` and all its cards?",
            "Delete",
            "Cancel"
        );

        if (!ok) return;

        // 1) delete cards
        await _cards.DeleteByDeckIdAsync(deck.Id);

        // 2) delete deck
        await _decks.DeleteAsync(deck);

        await LoadAsync();
    }

    partial void OnSearchTextChanged(string value)
    {
        ApplyFilter();
    }

    private void ApplyFilter()
    {
        Cards.Clear();

        var query = SearchText?.Trim();
        IEnumerable<Card> filtered = _allCards;

        if (!string.IsNullOrWhiteSpace(query))
        {
            filtered = _allCards.Where(card =>
                (!string.IsNullOrWhiteSpace(card.Front) && card.Front.Contains(query, StringComparison.OrdinalIgnoreCase)) ||
                (!string.IsNullOrWhiteSpace(card.Back) && card.Back.Contains(query, StringComparison.OrdinalIgnoreCase)));
        }

        foreach (var card in filtered)
        {
            Cards.Add(card);
        }
    }
}
