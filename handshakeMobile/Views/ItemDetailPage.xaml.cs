using System.ComponentModel;
using Xamarin.Forms;
using handshakeMobile.ViewModels;

namespace handshakeMobile.Views
{
  public partial class ItemDetailPage : ContentPage
  {
    public ItemDetailPage()
    {
      InitializeComponent();
      BindingContext = new ItemDetailViewModel();
    }
  }
}