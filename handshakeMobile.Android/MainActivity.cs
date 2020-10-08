using System;

using Android.App;
using Android.Content.PM;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using handshakeMobile.Views;
using handshakeMobile.ViewModels;

namespace handshakeMobile.Droid
{
  [Activity(Label = "handshakeMobile",
  Icon = "@mipmap/icon",
  Theme = "@style/MainTheme",
  MainLauncher = true,
  ConfigurationChanges = ConfigChanges.ScreenSize |
                          ConfigChanges.Orientation |
                          ConfigChanges.UiMode |
                          ConfigChanges.ScreenLayout |
                          ConfigChanges.SmallestScreenSize)]
  [IntentFilter(new[] { Android.Content.Intent.ActionView },
      Categories = new[] { Android.Content.Intent.CategoryDefault, Android.Content.Intent.CategoryBrowsable },
      DataHost = "handshake.azurewebsites.net",
      DataPathPrefixes = new[] { signupPrefix },
      DataScheme = "http")]
  public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
  {
    private const string signupPrefix = "/signup";

    protected override void OnCreate(Bundle savedInstanceState)
    {
      TabLayoutResource = Resource.Layout.Tabbar;
      ToolbarResource = Resource.Layout.Toolbar;

      base.OnCreate(savedInstanceState);

      Xamarin.Essentials.Platform.Init(this, savedInstanceState);
      global::Xamarin.Forms.Forms.Init(this, savedInstanceState);


      string initialNavigation = null;

      if (Intent.Data != null)
      {
        var path = Intent.Data.Path;

        if(path == signupPrefix)
        {
          var id = Intent.Data.GetQueryParameter("id");
          initialNavigation = $"//{nameof(LoginPage)}/{nameof(SignupPage)}?{nameof(SignupViewModel.Id)}={id}";
        }
      }

      LoadApplication(new App(initialNavigation));
    }
    public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
    {
      Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);

      base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
    }
  }
}