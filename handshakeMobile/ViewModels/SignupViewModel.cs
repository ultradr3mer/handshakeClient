using handshakeMobile.Services;
using handshakeMobile.Views;
using System;
using System.Net.Http;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace handshakeMobile.ViewModels
{
  internal class SignupViewModel : BaseViewModel
  {
    private string propMessage;
    private string propNickname;
    private string propPassword;
    private string propUsername;

    public SignupViewModel()
    {
      this.SignupCommand = new Command(SignupCommandExecute);
    }

    public string Message
    {
      get { return propMessage; }
      set { SetProperty(ref propMessage, value); }
    }

    public string Nickname
    {
      get { return propNickname; }
      set { SetProperty(ref propNickname, value); }
    }

    public string Password
    {
      get { return propPassword; }
      set { SetProperty(ref propPassword, value); }
    }

    public Command SignupCommand
    {
      get;
    }

    public string Username
    {
      get { return propUsername; }
      set { SetProperty(ref propUsername, value); }
    }

    private async void SignupCommandExecute(object obj)
    {
      this.IsBusy = true;
      this.Message = string.Empty;

      Client client = new Client(new HttpClient());

      try
      {
        var data = new UserPostData()
        {
          Username = this.Username,
          Nickname = this.Nickname,
          Password = this.Password
        };

        await client.UserPostAsync(data);

        await SecureStorage.SetAsync(LoginViewModel.UsernameKey, this.Username);
        await SecureStorage.SetAsync(LoginViewModel.PasswordKey, this.Password);

        App.Client = client;

        await Shell.Current.GoToAsync($"//{nameof(LoginPage)}");
      }
      catch (ApiException exception)
      {
        this.Message = exception.ToString();
      }
      finally
      {
        this.IsBusy = false;
      }
    }
  }
}