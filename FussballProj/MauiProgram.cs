using Microsoft.Extensions.Logging;
using CommunityToolkit.Maui;
using FussballProj.Lib;
using FussballProj.Pages;
using FussballProj.Core.ViewModels;

namespace FussballProj
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder.UseMauiApp<App>()
                .UseMauiCommunityToolkit()
                .ConfigureFonts(fonts =>
            {
                fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
            });

            builder.Services.AddSingleton<MainViewModel>();
            builder.Services.AddSingleton<MainPage>();    
            string path = FileSystem.Current.AppDataDirectory;
            string filename = "data.sqlite";
            string fullpath = System.IO.Path.Combine(path, filename);
            System.Diagnostics.Debug.WriteLine("path");
            System.Diagnostics.Debug.WriteLine(fullpath);
            builder.Services.AddSingleton<IRepository>(new Sqliterepository(fullpath));
            builder.Services.AddSingleton<ReportPage>();
#if DEBUG
            builder.Logging.AddDebug();

            
#endif
            return builder.Build();
        }
    }
}