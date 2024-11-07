using MudBlazor;

namespace FscManager.WebApp;

public static class WebConfiguracao
{
    public static string HttpClientBackend { get; set; } = string.Empty;
    public static string BackendUrl { get; set; } = string.Empty;
    public static string HttpClientConector { get; set; } = string.Empty;
    public static string ApiConectorUrl { get; set; } = string.Empty;

    public static string HttpClienteBackendSignalr { get; set; } = string.Empty;
    public static string JwtToken { get; set; } = string.Empty;


    public static MudTheme Theme = new MudTheme()
    {
        PaletteLight = new PaletteLight()
        {
            Secondary = "#ff6600",
            Primary = "#f17ea1",
            Info = "#ffaa00",
            Success = "#ffaa00",
            Background = "#dee1e3",
            AppbarBackground = "#ff6600",
            DrawerBackground = "#dee1e3",

        },
        PaletteDark = new PaletteDark()
        {
            Secondary = "#ffaa00",
            Primary = "#ffaa00",
            Success = "#ffaa00",
            Info = "#ffaa00",

        },

    };


}