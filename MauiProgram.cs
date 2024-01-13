using Microsoft.Extensions.DependencyInjection.Extensions;
using TodoSQLite.Data;
using TodoSQLite.Views;

namespace TodoSQLite;

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

		builder.Services.AddSingleton<LaboratoryListPage>();
		builder.Services.AddTransient<LaboratoryItemPage>();

		builder.Services.AddSingleton<LaborotoryDatabase>();

		return builder.Build();
	}
}
