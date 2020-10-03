using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Threading.Tasks;

using Xamarin.Forms;

using handshakeMobile.Models;
using handshakeMobile.Views;
using handshakeMobile.Services;

namespace handshakeMobile.ViewModels
{
  public class PostsViewModel : BaseViewModel
  {
    private Post propSelectedPost;

    public ObservableCollection<Post> Posts { get; }
    public Command LoadItemsCommand { get; }
    public Command AddItemCommand { get; }
    public Command<Post> ItemTapped { get; }

    public PostsViewModel()
    {
      Title = "Browse";
      Posts = new ObservableCollection<Post>();
      LoadItemsCommand = new Command(async () => await ExecuteLoadItemsCommand());

      ItemTapped = new Command<Post>(OnPostSelected);

      AddItemCommand = new Command(OnAddItem);
    }

    async Task ExecuteLoadItemsCommand()
    {
      IsBusy = true;

      try
      {
        Posts.Clear();
        var items = await App.Client.GetclosepostsAsync(0,0);
        foreach (var item in items)
        {
          Posts.Add(item);
        }
      }
      catch (Exception ex)
      {
        Debug.WriteLine(ex);
      }
      finally
      {
        IsBusy = false;
      }
    }

    public void OnAppearing()
    {
      IsBusy = true;
      SelectedPost = null;
    }

    public Post SelectedPost
    {
      get => propSelectedPost;
      set
      {
        SetProperty(ref propSelectedPost, value);
        OnPostSelected(value);
      }
    }

    private async void OnAddItem(object obj)
    {
      await Shell.Current.GoToAsync(nameof(NewItemPage));
    }

    async void OnPostSelected(Post item)
    {
      if (item == null)
        return;

      // This will push the ItemDetailPage onto the navigation stack
      await Shell.Current.GoToAsync($"{nameof(ItemDetailPage)}?{nameof(ItemDetailViewModel.ItemId)}={item.Id}");
    }
  }
}