using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using handshakeMobile.Services;
using handshakeMobile.Views;

namespace handshakeMobile
{
  public partial class App : Application
  {
    public static bool IsUserLoggedIn { get; internal set; }
    public static Client Client { get; internal set; }

    public App()
    {
      InitializeComponent();

      DependencyService.Register<MockDataStore>();

      MainPage = new AppShell();
    }

    protected override void OnStart()
    {
    }

    protected override void OnSleep()
    {
    }

    protected override void OnResume()
    {
    }
  }
}
