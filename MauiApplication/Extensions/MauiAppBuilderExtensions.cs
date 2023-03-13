namespace MauiApplication.Extensions;

public static class MauiAppBuilderExtensions
{
    /// <summary>
    /// Configure Services inside App like Dependency Injection and more
    /// </summary>
    /// <param name="builder"></param>
    /// <param name="configureServicesCallBack"></param>
    /// <returns></returns>
    public static MauiAppBuilder ConfigureServices(this MauiAppBuilder builder,Action<MauiAppBuilder> configureServicesCallBack)
    {
        configureServicesCallBack(builder);

        return builder;
    }
}