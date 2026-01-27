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

    [ObservableProperty]
    public partial int DeckId { get; set; }

    [ObservableProperty]
    public partial Deck? Deck { get; set; }

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

        Cards.Clear();
        var list = await _cards.GetByDeckIdAsync(DeckId);
        foreach (var c in list) Cards.Add(c);
    }

    [RelayCommand]
    public Task AddCardAsync()
        => Shell.Current.GoToAsync($"{nameof(EditCardPage)}?deckId={DeckId}");

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
}
