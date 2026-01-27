using FlashStudy.ViewModels;

namespace FlashStudy.Views;

public partial class StudyPage : ContentPage
{
    private readonly StudyViewModel _vm;

    public StudyPage(StudyViewModel vm)
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
