using Xamarin.Forms;

using handshakeMobile.ViewModels;

namespace handshakeMobile.Views
{
  public partial class PostsPage : ContentPage
  {
    PostsViewModel _viewModel;

    public PostsPage()
    {
      InitializeComponent();

      BindingContext = _viewModel = new PostsViewModel();
    }

    protected override void OnAppearing()
    {
      base.OnAppearing();
      _viewModel.OnAppearing();
    }
  }
}