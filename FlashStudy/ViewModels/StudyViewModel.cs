using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using FlashStudy.Data.Repositories;
using FlashStudy.Models;

namespace FlashStudy.ViewModels;

[QueryProperty(nameof(DeckId), "deckId")]
public partial class StudyViewModel : ObservableObject
{
    private readonly CardRepository _cards;

    private List<Card> _list = new();

    [ObservableProperty] private int deckId;
    [ObservableProperty] private int index;
    [ObservableProperty] private bool isFlipped;

    public string DisplayText
        => _list.Count == 0 ? "No cards in this deck." :
           IsFlipped ? _list[Index].Back : _list[Index].Front;

    public StudyViewModel(CardRepository cards)
        => _cards = cards;

    [RelayCommand]
    public async Task LoadAsync()
    {
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
