using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using handshakeMobile.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace handshakeMobile.Views
{
  [XamlCompilation(XamlCompilationOptions.Compile)]
  public partial class LoginPage : ContentPage
  {
    public LoginPage()
    {
      InitializeComponent();
      this.BindingContext = new LoginViewModel();
    }

    private async void LoginClicked(object sender, EventArgs e)
    {
    }
  }
}