using Archivum.Logic;
using System.ComponentModel;
using System.Windows.Input;
using System.Runtime.CompilerServices;
using System;

namespace Archivum;

public class TextLibraryViewModel : IQueryAttributable, INotifyPropertyChanged
{
    readonly TextLibraryRepository database = new TextLibraryRepository();

    public event PropertyChangedEventHandler PropertyChanged;
    public TextMaterial textMaterial  = new TextMaterial();

    public ICommand SaveItem { get; private set; }
    public ICommand DeleteItem { get; private set; }
    public ICommand AddImage { get; private set; }
    public TextLibraryViewModel()
    {
        SaveItem = new Command(
        execute: () =>
        {
            _ = database.SaveItemAsync(textMaterial);
            MessagingCenter.Send<TextLibraryViewModel>(this, "Change text element");
        });
        DeleteItem = new Command(
       execute: async () =>
        {
            _ = database.DeleteItemAsync(textMaterial);
            MessagingCenter.Send<TextLibraryViewModel>(this, "Remove text element");
            await Shell.Current.GoToAsync($"..");
        });
        AddImage = new Command(
        execute: () =>
        {
            TakePhoto();
        });


    }

    public TextLibraryViewModel(TextMaterial tm)
    {
        textMaterial = tm;
        SaveItem = new Command(
        execute: () =>
        {
            _ = database.SaveItemAsync(textMaterial);
            MessagingCenter.Send<TextLibraryViewModel>(this, "Change text element");
        });
        DeleteItem = new Command(
       execute: async () =>
       {
           _ = database.DeleteItemAsync(textMaterial);
           //TextListElement textListElement = new TextListElement(textMaterial.ID, textMaterial.Name);
           MessagingCenter.Send<TextLibraryViewModel>(this, "Remove text element");
           await Shell.Current.GoToAsync($"..");
       });
        AddImage = new Command(
        execute: () =>
        {
            TakePhoto();
        });


    }
    public string Name
    {
        get => textMaterial.Name;
        set
        {
            if (textMaterial.Name != value)
            {
                textMaterial.Name = value;
                OnPropertyChanged();
            }
        }
    }

    public string Type
    {
        get => textMaterial.Type;
        set
        {
            if (textMaterial.Type != value)
            {
                textMaterial.Type = value;
                OnPropertyChanged();
            }
        }
    }

    public string Comment
    {
        get => textMaterial.Comment;
        set
        {
            if (textMaterial.Comment != value)
            {
                textMaterial.Comment = value;
                OnPropertyChanged();
            }
        }
    }

    public ImageSource Cover
    {
        get
        {
            if (textMaterial.Cover.Length == 0)
            {
                return ImageSource.FromFile("dotnet_bot.svg");
            }

            MemoryStream ms = new MemoryStream(textMaterial.Cover);
            return ImageSource.FromStream(() => ms);
        }
    }


    public async void ApplyQueryAttributes(IDictionary<string, object> query)
    {
        if (query["textMaterial"] != null)
        {
            textMaterial = query["textMaterial"] as TextMaterial;
            RefreshProperties();
        }
    }

    protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
    {
        PropertyChangedEventHandler handler = PropertyChanged;
        if (handler != null)
            handler(this, new PropertyChangedEventArgs(propertyName));
    }

    public async void TakePhoto()
    {
        Stream stream = await new PhotoPickerService().GetImageStreamAsync();
        if (stream != null)
        {
            MemoryStream memory = new MemoryStream();
            await stream.CopyToAsync(memory);
            textMaterial.Cover = memory.ToArray();
            RefreshProperties();
        }
    }


    public void RefreshProperties()
    {
        OnPropertyChanged("Name");
        OnPropertyChanged("Comment");
        OnPropertyChanged("Type");
        OnPropertyChanged("Cover");
    }
}

