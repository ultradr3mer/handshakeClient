using handshakeMobile.Services;
using handshakeMobile.Views;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace handshakeMobile.ViewModels
{
  public class LoginViewModel : BaseViewModel
  {
    public const string UsernameKey = "username";
    public const string PasswordKey = "password";

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

    private string propMessage;
    public string Message
    {
      get { return propMessage; }
      set { SetProperty(ref propMessage, value); }
    }

    public Command LoginCommand { get; }

    public LoginViewModel()
    {
      var usernameTask = SecureStorage.GetAsync(LoginViewModel.UsernameKey); 
      var passwordTask = SecureStorage.GetAsync(LoginViewModel.PasswordKey);

      this.Username = usernameTask.Result;
      this.Password = passwordTask.Result;

      LoginCommand = new Command(OnLoginClicked);
    }

    private async void OnLoginClicked(object obj)
    {
      var client = new Client(new CustomHttpClient(this.Username, this.Password));

      try
      {
        var test = await client.GetcloseusersAsync(0, 0);
        Message = string.Empty;

        await SecureStorage.SetAsync(LoginViewModel.UsernameKey, this.Username);
        await SecureStorage.SetAsync(LoginViewModel.PasswordKey, this.Password);

        App.Client = client;

        await Shell.Current.GoToAsync($"//{nameof(AboutPage)}");
      }
      catch (ApiException exception)
      {
        await SecureStorage.SetAsync(LoginViewModel.UsernameKey, string.Empty);
        await SecureStorage.SetAsync(LoginViewModel.PasswordKey, string.Empty);

        Message = exception.ToString();
      }
    }

    private bool AreCredentialsCorrect()
    {
      return true;
    }
  }
}
