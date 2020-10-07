using handshakeMobile.Services;
using handshakeMobile.Views;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace handshakeMobile.ViewModels
{
  public class PostsViewModel : BaseViewModel
  {
    #region Fields

    private string propMessage;
    private PostGetData propSelectedPost;

    #endregion Fields

    #region Constructors

    public PostsViewModel()
    {
      Title = "Browse";
      Posts = new ObservableCollection<PostGetData>();
      LoadItemsCommand = new Command(async () => await ExecuteLoadItemsCommand());

      ItemTapped = new Command<PostGetData>(OnPostSelected);

      AddItemCommand = new Command(OnAddItem);
    }

    #endregion Constructors

    #region Properties

    public Command AddItemCommand { get; }
    public Command<PostGetData> ItemTapped { get; }
    public Command LoadItemsCommand { get; }

    public string Message
    {
      get { return propMessage; }
      set { SetProperty(ref propMessage, value); }
    }

    public ObservableCollection<PostGetData> Posts { get; }

    public PostGetData SelectedPost
    {
      get => propSelectedPost;
      set
      {
        SetProperty(ref propSelectedPost, value);
        OnPostSelected(value);
      }
    }

    #endregion Properties

    #region Methods

    public void OnAppearing()
    {
      IsBusy = true;
      SelectedPost = null;
    }

    private async Task ExecuteLoadItemsCommand()
    {
      IsBusy = true;

      try
      {
        Posts.Clear();
        var request = new GeolocationRequest(GeolocationAccuracy.Medium);
        var location = await Geolocation.GetLocationAsync(request);
        var items = await App.Client.PostGetclosepostsAsync(location.Latitude, location.Longitude);
        foreach (var item in items)
        {
          Posts.Add(item);
        }
      }
      catch (ApiException exception)
      {
        this.Message = exception.ToString();
      }
      finally
      {
        IsBusy = false;
      }
    }

    private async void OnAddItem(object obj)
    {
      await Shell.Current.GoToAsync(nameof(NewPostPage));
    }

    private async void OnPostSelected(PostGetData item)
    {
      if (item == null)
        return;

      await Shell.Current.GoToAsync($"{nameof(PostDetailPage)}?{nameof(PostDetailViewModel.Id)}={item.Id}");
    }

    #endregion Methods
  }
}