using handshakeMobile.Services;
using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using Xamarin.Forms;

namespace handshakeMobile.ViewModels
{
  [QueryProperty(nameof(Id), nameof(Id))]
  public class PostDetailViewModel : BaseViewModel
  {
    #region Fields

    private string propAuthorName;
    private string propContent;
    private string propId;
    private ObservableCollection<PostReplyGetData> propReplys;
    private Guid idGuid;

    #endregion Fields

    #region Constructors

    public PostDetailViewModel()
    {
      this.Replys = new ObservableCollection<PostReplyGetData>();
      this.RefreshCommand = new Command(this.RefreshCommandExecute);
    }

    private void RefreshCommandExecute(object obj)
    {
      this.LoadItemById(this.idGuid);
    }

    #endregion Constructors

    #region Properties

    public Command RefreshCommand
    {
      get;
    }

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
        this.LoadItemById(Guid.Parse(value));
      }
    }

    public ObservableCollection<PostReplyGetData> Replys
    {
      get { return this.propReplys; }
      set { this.SetProperty(ref this.propReplys, value); }
    }

    #endregion Properties

    #region Methods

    public async void LoadItemById(Guid itemId)
    {
      this.IsBusy = true;
      this.idGuid = itemId;

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
      catch (Exception)
      {
        Debug.WriteLine("Failed to Load Item");
      }
      finally
      {
        this.IsBusy = false;
      }
    }

    #endregion Methods
  }
}