﻿using handshakeMobile.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace handshakeMobile.Views
{
  [XamlCompilation(XamlCompilationOptions.Compile)]
  public partial class LoginPage : ContentPage
  {
    #region Constructors

    public LoginPage()
    {
      InitializeComponent();
      this.ViewModel = new LoginViewModel();
    }

    #endregion Constructors

    #region Properties

    public LoginViewModel ViewModel
    {
      get { return this.BindingContext as LoginViewModel; }
      set { this.BindingContext = value; }
    }

    #endregion Properties

    #region Methods

    protected override void OnAppearing()
    {
      base.OnAppearing();

      this.ViewModel.Initialize();
    }

    #endregion Methods
  }
}