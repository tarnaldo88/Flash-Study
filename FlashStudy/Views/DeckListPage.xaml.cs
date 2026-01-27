using FlashStudy.ViewModels;

namespace FlashStudy.Views;

public partial class DeckListPage : ContentPage
{
    private readonly DeckListViewModel _vm;

    public DeckListPage(DeckListViewModel vm)
    {
        InitializeComponent();
        BindingContext = _vm = vm;
    }

    protected override async void OnAppearing()
    {
        base.OnAppearing();
        await _vm.LoadAsync();
    }
}