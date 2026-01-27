using Microsoft.Extensions.DependencyInjection;

namespace FlashStudy;

public partial class App : Application
{
	private readonly FlashStudy.Data.AppDatabase _db;
	public App(FlashStudy.Data.AppDatabase db)
	{
		InitializeComponent();
		_db = db;
	}

	protected override Window CreateWindow(IActivationState? activationState)
	{
		return new Window(new AppShell());
	}

	protected override async void OnStart()
    {
        base.OnStart();
        await _db.InitAsync();
    }
}
