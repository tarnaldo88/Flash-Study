using FlashStudy.Views;

namespace FlashStudy;

public partial class AppShell : Shell
{
	public AppShell()
	{
		InitializeComponent();

		Routing.RegisterRoute(nameof(DeckDetailPage), typeof(DeckDetailPage));
        Routing.RegisterRoute(nameof(EditCardPage), typeof(EditCardPage));
        Routing.RegisterRoute(nameof(StudyPage), typeof(StudyPage));
	}
}
