using handshakeMobile.Extensions;
using handshakeMobile.Services;
using System;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace handshakeMobile.ViewModels
{
  public class NewPostViewModel : BaseViewModel
  {
    #region Fields

    private Location propLocation;
    private string propMessage;
    private string propPlaceholder;
    private string propText;

    #endregion Fields

    #region Constructors

    public NewPostViewModel()
    {
      this.SaveCommand = new Command(this.OnSave, this.ValidateSave);
      this.CancelCommand = new Command(this.OnCancel);
      this.PropertyChanged +=
          (_, __) => this.SaveCommand.ChangeCanExecute();
    }

    #endregion Constructors

    #region Properties

    public Command CancelCommand { get; }

    public Location Location
    {
      get { return propLocation; }
      set { SetProperty(ref propLocation, value); }
    }

    public string Message
    {
      get { return propMessage; }
      set { SetProperty(ref propMessage, value); }
    }

    public string Placeholder
    {
      get { return this.propPlaceholder; }
      set { this.SetProperty(ref this.propPlaceholder, value); }
    }

    public Command SaveCommand { get; }

    public string Text
    {
      get { return this.propText; }
      set { this.SetProperty(ref this.propText, value); }
    }

    #endregion Properties

    #region Methods

    internal async void Initialize()
    {
      string placehoder = GetRandomPlaceholder();
      this.Placeholder = placehoder;

      var request = new GeolocationRequest(GeolocationAccuracy.Medium);
      this.Location = await Geolocation.GetLocationAsync(request);
    }

    private static string GetRandomPlaceholder()
    {
      var placehoders = new string[]
      {
        "I like unicorns",
        "Nahrwal swimming in the ocean",
        "First !!1!!!!",
        "We must construct additional pylons"
      };
      var rnd = new Random();
      var placehoder = placehoders[rnd.Next(0, placehoders.Length - 1)];
      return placehoder;
    }

    private async void OnCancel()
    {
      await Shell.Current.GoToAsync("..");
    }

    private async void OnSave()
    {
      this.IsBusy = true;
      this.Message = string.Empty;

      var location = this.Location;

      var data = new PostPostData()
      {
        Content = Text,
        Latitude = location.Latitude,
        Longitude = location.Longitude
      };

      try
      {
        await App.Client.PostAsync(data);

        await Shell.Current.GoToAsync("..");
      }
      catch (ApiException exception)
      {
        this.Message = exception.ToString();
      }
      finally
      {
        this.IsBusy = true;
      }
    }

    private bool ValidateSave()
    {
      return !string.IsNullOrWhiteSpace(this.Text)
          && this.Location != null;
    }

    #endregion Methods
  }
}