using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using FlashStudy.Data.Repositories;
using FlashStudy.Models;

namespace FlashStudy.ViewModels;

[QueryProperty(nameof(DeckId), "deckId")]
public partial class StudyViewModel : ObservableObject
{
    private readonly CardRepository _cards;
    private readonly DeckRepository _decks;

    private List<Card> _list = new();

    [ObservableProperty]
    public partial int DeckId { get; set; }

    [ObservableProperty]
    public partial int Index { get; set; }

    [ObservableProperty]
    public partial bool IsFlipped { get; set; }

    [ObservableProperty]
    public partial string DeckName { get; set; } = "";

    public string DisplayText
        => _list.Count == 0 ? "No cards in this deck." :
           IsFlipped ? _list[Index].Back : _list[Index].Front;

    public StudyViewModel(CardRepository cards, DeckRepository decks)
    {
        _cards = cards;
        _decks = decks;
    }

    [RelayCommand]
    public async Task LoadAsync()
    {
        var deck = await _decks.GetByIdAsync(DeckId);
        DeckName = deck?.Name ?? "";

        _list = await _cards.GetByDeckIdAsync(DeckId);
        Index = 0;
        IsFlipped = false;
        OnPropertyChanged(nameof(DisplayText));
    }

    [RelayCommand]
    public void Flip()
    {
        if (_list.Count == 0) return;
        IsFlipped = !IsFlipped;
        OnPropertyChanged(nameof(DisplayText));
    }

    [RelayCommand]
    public void Next()
    {
        if (_list.Count == 0) return;
        if (Index < _list.Count - 1) Index++;
        IsFlipped = false;
        OnPropertyChanged(nameof(DisplayText));
    }

    [RelayCommand]
    public void Prev()
    {
        if (_list.Count == 0) return;
        if (Index > 0) Index--;
        IsFlipped = false;
        OnPropertyChanged(nameof(DisplayText));
    }
}
