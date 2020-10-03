using handshakeMobile.Views;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace handshakeMobile.ViewModels
{
  public class LoginViewModel : BaseViewModel
  {
    private string propPassword;
    public string Password
    {
      get { return propPassword; }
      set { SetProperty(ref propPassword, value); }
    }

    private string propUsername;
    public string Username
    {
      get { return propUsername; }
      set { SetProperty(ref propUsername, value); }
    }

    public Command LoginCommand { get; }

    public LoginViewModel()
    {
      LoginCommand = new Command(OnLoginClicked);
    }

    private async void OnLoginClicked(object obj)
    {
      //// Prefixing with `//` switches to a different navigation stack instead of pushing to the active one
      //await Shell.Current.GoToAsync($"//{nameof(AboutPage)}");


      //var isValid = AreCredentialsCorrect();
      //if (isValid)
      //{
      //  App.IsUserLoggedIn = true;
      //  Shell.Current.Navigation.InsertPageBefore(new AppShell(), this);
      //  await Shell.Current.Navigation.PopAsync();
      //}
      //else
      //{
      //  messageLabel.Text = "Login failed";
      //  passwordEntry.Text = string.Empty;
      //}
    }

    private bool AreCredentialsCorrect()
    {
      return true;
    }
  }
}
