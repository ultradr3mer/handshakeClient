using System;
using System.Collections.Generic;
using handshakeMobile.ViewModels;
using handshakeMobile.Views;
using Xamarin.Forms;

namespace handshakeMobile
{
  public partial class AppShell : Xamarin.Forms.Shell
  {
    public AppShell()
    {
      InitializeComponent();
      Routing.RegisterRoute(nameof(PostDetailPage), typeof(PostDetailPage));
      Routing.RegisterRoute(nameof(NewPostPage), typeof(NewPostPage));
      Routing.RegisterRoute(nameof(SignupPage), typeof(SignupPage));
    }

    private async void OnLogoutClicked(object sender, EventArgs e)
    {
      await Shell.Current.GoToAsync("//LoginPage");
    }
  }
}
