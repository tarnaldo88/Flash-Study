using FlashStudy.ViewModels;

namespace FlashStudy.Views;

public partial class EditCardPage : ContentPage
{
    private readonly EditCardViewModel _vm;

    public EditCardPage(EditCardViewModel vm)
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
