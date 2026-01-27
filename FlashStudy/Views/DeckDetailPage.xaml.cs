using FlashStudy.ViewModels;

namespace FlashStudy.Views;

public partial class DeckDetailPage : ContentPage
{
    private readonly DeckDetailViewModel _vm;

    public DeckDetailPage(DeckDetailViewModel vm)
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
