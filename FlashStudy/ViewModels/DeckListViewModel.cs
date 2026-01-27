using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using FlashStudy.Data.Repositories;
using FlashStudy.Models;
using FlashStudy.Views;
using System.Collections.ObjectModel;

namespace FlashStudy.ViewModels;

public partial class DeckListViewModel : ObservableObject
{
    private readonly DeckRepository _decks;

    public ObservableCollection<Deck> Items { get; } = new();

    [ObservableProperty] private string newDeckName = "";

    public DeckListViewModel(DeckRepository decks)
        => _decks = decks;

    [RelayCommand]
    public async Task LoadAsync()
    {
        Items.Clear();
        var all = await _decks.GetAllAsync();
        foreach (var d in all) Items.Add(d);
    }

    [RelayCommand]
    public async Task AddDeckAsync()
    {
        var name = (NewDeckName ?? "").Trim();
        if (string.IsNullOrWhiteSpace(name))
            return;

        await _decks.CreateAsync(name);
        NewDeckName = "";
        await LoadAsync();
    }

    [RelayCommand]
    public async Task OpenDeckAsync(Deck? deck)
    {
        if (deck is null) return;

        await Shell.Current.GoToAsync($"{nameof(DeckDetailPage)}?deckId={deck.Id}");
    }

    [RelayCommand]
    public async Task DeleteDeckAsync(Deck? deck)
    {
        if (deck is null) return;

        var ok = await Shell.Current.DisplayAlertAsync("Delete deck?", $"Delete '{deck.Name}'?", "Delete", "Cancel");
        if (!ok) return;

        await _decks.DeleteAsync(deck);
        await LoadAsync();
    }
}