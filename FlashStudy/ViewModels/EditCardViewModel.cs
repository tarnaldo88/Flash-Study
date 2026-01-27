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

    [ObservableProperty] private int deckId;
    [ObservableProperty] private int cardId;

    [ObservableProperty] private string front = "";
    [ObservableProperty] private string back = "";

    public EditCardViewModel(CardRepository cards)
        => _cards = cards;

    [RelayCommand]
    public async Task LoadAsync()
    {
        if (CardId <= 0)
        {
            Front = "";
            Back = "";
            return;
        }

        var card = await _cards.GetByIdAsync(CardId);
        if (card is null) return;

        Front = card.Front;
        Back = card.Back;
        DeckId = card.DeckId;
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
