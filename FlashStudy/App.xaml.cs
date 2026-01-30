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

	protected override Window CreateWindow(IActivationState? activationState )
	{
		var window = new Window(new AppShell())
		{
			Width = 1000,
			Height = 700,
			MinimumHeight = 600,
			MinimumWidth = 800
		};

		return window;
	}

	protected override async void OnStart()
    {
        base.OnStart();
        await _db.InitAsync();
    }
}
