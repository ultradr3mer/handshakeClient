using handshakeMobile.ViewModels;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace handshakeMobile.Views
{
  [XamlCompilation(XamlCompilationOptions.Compile)]
  public partial class SignupPage : ContentPage
  {
    #region Constructors

    public SignupPage()
    {
      InitializeComponent();
      this.BindingContext = new SignupViewModel();
    }

    #endregion Constructors
  }
}