using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Shopping_List.Data;

namespace Shopping_List;

public static class MauiProgram
{
	public static MauiApp CreateMauiApp()
	{

        var builder = MauiApp.CreateBuilder();

        // Load the configuration from the appsettings.json file
        builder.Configuration.AddJsonFile("appsettings.json");

		// register the ShoppingContext service with the connection string from the configuration
		builder.Services.AddDbContext<ShoppingContext>(options =>
			options.UseSqlServer(builder.Configuration.GetConnectionString("ShoppingDatabase")));

     
		builder
			.UseMauiApp<App>()
			.ConfigureFonts(fonts =>
			{
				fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
			});

		builder.Services.AddMauiBlazorWebView();

#if DEBUG
		builder.Services.AddBlazorWebViewDeveloperTools();
		builder.Logging.AddDebug();
#endif

		builder.Services.AddSingleton<WeatherForecastService>();

		builder.Services.AddDbContext<ShoppingContext>(options =>
		{
			options.UseSqlServer("Server=WINDOWS-SERVER-SQL;Database=Shopping-List;User Id=Sa;Password=Spr!ng20@2;");
		});
	
		return builder.Build();
	}
}
