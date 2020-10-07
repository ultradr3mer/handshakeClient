﻿using handshakeMobile.Services;
using handshakeMobile.Views;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace handshakeMobile.ViewModels
{
  public class LoginViewModel : BaseViewModel
  {
    #region Fields

    public const string PasswordKey = "password";
    public const string UsernameKey = "username";
    private string propMessage;
    private string propPassword;
    private string propUsername;
    private bool firstOpened = true;

    #endregion Fields

    #region Constructors

    public LoginViewModel()
    {
      this.LoginCommand = new Command(this.LoginCommandExecute);
      this.SignupCommand = new Command(this.SignupCommandExecute);
    }

    #endregion Constructors

    #region Properties

    public Command LoginCommand { get; }

    public string Message
    {
      get { return this.propMessage; }
      set { this.SetProperty(ref this.propMessage, value); }
    }

    public string Password
    {
      get { return this.propPassword; }
      set { this.SetProperty(ref this.propPassword, value); }
    }

    public Command SignupCommand { get; }

    public string Username
    {
      get { return this.propUsername; }
      set { this.SetProperty(ref this.propUsername, value); }
    }

    #endregion Properties

    #region Methods

    internal void Initialize()
    {
      System.Threading.Tasks.Task<string> usernameTask = SecureStorage.GetAsync(LoginViewModel.UsernameKey);
      System.Threading.Tasks.Task<string> passwordTask = SecureStorage.GetAsync(LoginViewModel.PasswordKey);

      this.Username = usernameTask.Result;
      this.Password = passwordTask.Result;

      if(firstOpened)
      {
        this.LoginCommandExecute();
        this.firstOpened = false;
      }
    }

    private async void LoginCommandExecute()
    {
      this.IsBusy = true;
      this.Message = string.Empty;

      Client client = new Client(new CustomHttpClient(this.Username, this.Password));

      try
      {
        var test = await client.UserGetAsync();
        this.Message = $"Signed in as {test.Nickname}.";

        await SecureStorage.SetAsync(LoginViewModel.UsernameKey, this.Username);
        await SecureStorage.SetAsync(LoginViewModel.PasswordKey, this.Password);

        App.Client = client;

        await Shell.Current.GoToAsync($"//{nameof(PostsPage)}");
      }
      catch (ApiException exception)
      {
        await SecureStorage.SetAsync(LoginViewModel.UsernameKey, string.Empty);
        await SecureStorage.SetAsync(LoginViewModel.PasswordKey, string.Empty);

        this.Message = exception.ToString();
      }
      finally
      {
        this.IsBusy = false;
      }
    }

    private async void SignupCommandExecute(object obj)
    {
      await Shell.Current.GoToAsync(nameof(SignupPage));
    }

    #endregion Methods
  }
}