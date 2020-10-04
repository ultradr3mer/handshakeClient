﻿using System;
using System.Diagnostics;
using Xamarin.Forms;

namespace handshakeMobile.ViewModels
{
  [QueryProperty(nameof(ItemId), nameof(ItemId))]
  public class ItemDetailViewModel : BaseViewModel
  {
    private string itemId;
    private string text;
    private string description;
    public string Id { get; set; }

    public string Text
    {
      get => text;
      set => SetProperty(ref text, value);
    }

    public string Description
    {
      get => description;
      set => SetProperty(ref description, value);
    }

    public string ItemId
    {
      get
      {
        return itemId;
      }
      set
      {
        itemId = value;
        LoadItemId(value);
      }
    }

    public async void LoadItemId(string itemId)
    {
      try
      {
      }
      catch (Exception)
      {
        Debug.WriteLine("Failed to Load Item");
      }
    }
  }
}
