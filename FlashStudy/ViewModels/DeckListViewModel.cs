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
    private readonly CardRepository _cards;

    public ObservableCollection<Deck> Items { get; } = new();

    [ObservableProperty]
    public partial int DeckCount { get; set; } = default;

    [ObservableProperty]
    public partial string NewDeckName { get; set; } = "";

    public DeckListViewModel(DeckRepository decks, CardRepository cards)
    {
        _decks = decks;
        _cards = cards;
    }

    [RelayCommand]
    public async Task LoadAsync()
    {
        try
        {
            Items.Clear();
            var all = await _decks.GetAllAsync();
            foreach (var d in all)
            {
                d.Count = await _cards.CountByDeckIdAsync(d.Id);
                Items.Add(d);
            }
        }
        catch (Exception ex)
        {
            await ShowErrorAsync("Load decks failed", ex);
        }
    }

    [RelayCommand]
    public async Task AddDeckAsync()
    {
        try
        {
            var name = (NewDeckName ?? "").Trim();
            if (string.IsNullOrWhiteSpace(name))
                return;

            await _decks.CreateAsync(name);
            NewDeckName = "";
            await LoadAsync();
        }
        catch (Exception ex)
        {
            await ShowErrorAsync("Add deck failed", ex);
        }
    }

    [RelayCommand]
    public async Task OpenDeckAsync(Deck? deck)
    {
        try
        {
            if (deck is null) return;

            await Shell.Current.GoToAsync($"{nameof(DeckDetailPage)}?deckId={deck.Id}");
        }
        catch (Exception ex)
        {
            await ShowErrorAsync("Open deck failed", ex);
        }
    }

    [RelayCommand]
    public async Task DeleteDeckAsync(Deck? deck)
    {
        try
        {
            if (deck is null) return;

            var ok = await Shell.Current.DisplayAlertAsync("Delete deck?", $"Delete '{deck.Name}'?", "Delete", "Cancel");
            if (!ok) return;

            await _decks.DeleteAsync(deck);
            await LoadAsync();
        }
        catch (Exception ex)
        {
            await ShowErrorAsync("Delete deck failed", ex);
        }
    }

    private static Task ShowErrorAsync(string title, Exception ex)
        => Shell.Current.DisplayAlertAsync(title, ex.Message, "OK");
}
