using HackerNewsMAUISemple.Content;
using HackerNewsMAUISemple.Firebase;
using HackerNewsMAUISemple.Pages.Details;
using HackerNewsMAUISemple.Pages.Main;
using Microsoft.Extensions.Logging;

namespace HackerNewsMAUISemple
{
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

            builder.Services.AddSingleton<TopStories>();
            builder.Services.AddSingleton<NewStories>();
            builder.Services.AddSingleton<BestStories>();
            builder.Services.AddSingleton<AskStories>();
            builder.Services.AddSingleton<ShowStories>();
            builder.Services.AddSingleton<JobStories>();

            builder.Services.AddSingleton<IFirebaseManager, FirebaseManager>();
#if DEBUG
    		builder.Logging.AddDebug();
#endif

            return builder.Build();
        }
    }
}
