using Microsoft.Extensions.Logging;
using FlashStudy.Data;
using FlashStudy.Data.Repositories;
using FlashStudy.ViewModels;
using FlashStudy.Views;

namespace FlashStudy;

public static class MauiProgram
{
	public static MauiApp CreateMauiApp()
	{
		var builder = MauiApp.CreateBuilder();
		builder
			.UseMauiApp<App>()
			.ConfigureFonts(fonts =>
			{
				fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
				fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
			});

#if DEBUG
		builder.Logging.AddDebug();
#endif
		// DB path
        var dbPath = Path.Combine(FileSystem.AppDataDirectory, "flashcards.db3");

        builder.Services.AddSingleton(new AppDatabase(dbPath));
        builder.Services.AddSingleton<DeckRepository>();
        builder.Services.AddSingleton<CardRepository>();

        builder.Services.AddTransient<DeckListViewModel>();
        builder.Services.AddTransient<DeckDetailViewModel>();
        builder.Services.AddTransient<EditCardViewModel>();
        builder.Services.AddTransient<StudyViewModel>();

        builder.Services.AddTransient<DeckListPage>();
        builder.Services.AddTransient<DeckDetailPage>();
        builder.Services.AddTransient<EditCardPage>();
        builder.Services.AddTransient<StudyPage>();

		return builder.Build();
	}
}
