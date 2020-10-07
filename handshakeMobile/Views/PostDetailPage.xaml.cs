using System.ComponentModel;
using Xamarin.Forms;
using handshakeMobile.ViewModels;

namespace handshakeMobile.Views
{
  public partial class PostDetailPage : ContentPage
  {
    public PostDetailPage()
    {
      InitializeComponent();
      BindingContext = new PostDetailViewModel();
    }
  }
}