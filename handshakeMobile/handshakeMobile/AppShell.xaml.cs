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
      Routing.RegisterRoute(nameof(ItemDetailPage), typeof(ItemDetailPage));
      Routing.RegisterRoute(nameof(NewItemPage), typeof(NewItemPage));
    }

    private async void OnMenuItemClicked(object sender, EventArgs e)
    {
      await Shell.Current.GoToAsync("//LoginPage");
    }
  }
}
