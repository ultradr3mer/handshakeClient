﻿using handshakeMobile.Composite;
using handshakeMobile.Services;
using System;
using System.Collections.ObjectModel;
using Xamarin.Forms;

namespace handshakeMobile.ViewModels
{
  [QueryProperty(nameof(Id), nameof(Id))]
  public class PostDetailViewModel : BaseViewModel
  {
    #region Fields

    private Guid idGuid;
    private string propAuthorName;
    private string propContent;
    private string propId;
    private bool propIsPosting;
    private string propMessage;
    private string propNewReplyText;
    private ObservableCollection<PostReplyGetData> propReplys;

    #endregion Fields

    #region Constructors

    public PostDetailViewModel()
    {
      this.Replys = new ObservableCollection<PostReplyGetData>();
      this.RefreshCommand = new Command(this.RefreshCommandExecute);
      this.PostReplyCommand = new Command(this.PostReplyCommandExecute, this.PostReplyCommandCanExecute);
      this.PropertyChanged += this.PostDetailViewModelPropertyChanged;
    }

    #endregion Constructors

    #region Properties

    public string AuthorName
    {
      get { return this.propAuthorName; }
      set { this.SetProperty(ref this.propAuthorName, value); }
    }

    public string Content
    {
      get { return this.propContent; }
      set { this.SetProperty(ref this.propContent, value); }
    }

    public string Id
    {
      get
      {
        return this.propId;
      }
      set
      {
        this.propId = value;
        this.idGuid = Guid.Parse(value);
      }
    }

    public bool IsPostingRepy
    {
      get { return this.propIsPosting; }
      set { this.SetProperty(ref this.propIsPosting, value); }
    }

    public string Message
    {
      get { return this.propMessage; }
      set { this.SetProperty(ref this.propMessage, value); }
    }

    public string NewReplyText
    {
      get { return this.propNewReplyText; }
      set { this.SetProperty(ref this.propNewReplyText, value); }
    }

    public Command PostReplyCommand
    {
      get;
    }

    public Command RefreshCommand
    {
      get;
    }

    public ObservableCollection<PostReplyGetData> Replys
    {
      get { return this.propReplys; }
      set { this.SetProperty(ref this.propReplys, value); }
    }

    #endregion Properties

    #region Methods

    public void OnAppearing()
    {
      IsBusy = true;
    }

    public async void LoadItemById(Guid itemId)
    {
      this.IsBusy = true;

      try
      {
        PostDetailGetData post = await App.Client.PostGetAsync(itemId);

        this.Content = post.Content;
        this.AuthorName = post.AuthorName;
        this.Replys.Clear();
        ObservableCollection<PostReplyGetData> replys = new ObservableCollection<PostReplyGetData>(post.Replys);
        foreach (PostReplyGetData reply in replys)
        {
          this.Replys.Add(reply);
        }
      }
      catch (ApiException exception)
      {
        this.Message = exception.ToString();
      }
      finally
      {
        this.IsBusy = false;
      }
    }

    private void PostDetailViewModelPropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
    {
      if (e.PropertyName == nameof(this.NewReplyText) || e.PropertyName == nameof(this.IsPostingRepy))
      {
        this.PostReplyCommand.ChangeCanExecute();
      }
    }

    private async void PostReplyCommandExecute()
    {
      if (this.IsPostingRepy)
      {
        return;
      }

      this.IsPostingRepy = true;

      try
      {
        ReplyPostData post = new ReplyPostData()
        {
          Content = this.NewReplyText,
          Post = this.idGuid
        };
        ReplyEntity repy = await App.Client.ReplyAsync(post);

        this.Replys.Clear();
        this.NewReplyText = string.Empty;
      }
      catch (ApiException exception)
      {
        this.Message = exception.ToString();
      }
      finally
      {
        this.IsPostingRepy = false;
      }

      this.LoadItemById(this.idGuid);
    }

    private bool PostReplyCommandCanExecute()
    {
      return !string.IsNullOrEmpty(this.NewReplyText) && !this.IsPostingRepy;
    }

    private void RefreshCommandExecute()
    {
      this.LoadItemById(this.idGuid);
    }

    #endregion Methods
  }
}