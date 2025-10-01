﻿namespace Solution.DesktopApp;

public static class MauiProgram
{
    public static MauiApp CreateMauiApp()
    {
        var builder = MauiApp.CreateBuilder();
        builder.UseMauiApp<App>()
               .UseMauiCommunityToolkit(options =>
               {
                   options.SetShouldEnableSnackbarOnWindows(true);
               })
               .ConfigureSyncfusionCore()
               .ConfigureSyncfusionToolkit()
               .UseMauiCommunityToolkitMarkup()
               .UseFontConfiguration()
               .UseAppConfigurations()
               .UseAppSettingsMapping()
               .UseDIConfiguration()
               .UseMsSqlServer();

#if DEBUG
		builder.Logging.AddDebug();
#endif

        return builder.Build();
    }
}
