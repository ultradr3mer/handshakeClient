using handshakeMobile.Enums;
using handshakeMobile.Services;
using Unity;
using Xamarin.Forms;

namespace handshakeMobile
{
  public partial class App : Application
  {
    public static bool IsUserLoggedIn { get; internal set; }
    public static Client Client { get; internal set; }

    private static UnityContainer container = new UnityContainer();

    public App()
    {
      InitializeComponent();
      MainPage = new AppShell();
      container.RegisterSingleton<LocationCache>();
    }

    protected override void OnStart()
    {
      var locationCache = Resolve<LocationCache>();

      #pragma warning disable CS4014
      locationCache.GetCurrentLocation(TimePassed.JustNow);
      #pragma warning restore CS4014
    }

    protected override void OnSleep()
    {
    }

    protected override void OnResume()
    {
    }

    public static T Resolve<T>()
    {
      return container.Resolve<T>();
    }
  }
}
