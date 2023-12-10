using Archivum.Interfaces;
using Archivum.Logic;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Archivum.ViewModels
{
    public class BaseViewModel : INotifyPropertyChanged, IViewModel
    {
        public int ID { get; set; }
        public byte[] cover { get; set; } = new byte[0];
        internal string name;
        public string Name
        {
            get => name;
            set
            {
                if (name != value)
                {
                    name = value;
                    OnPropertyChanged(nameof(Name));
                }
            }
        }

        public ImageSource Cover
        {
            get
            {
                if (cover.Length == 0)
                {
                    return ImageSource.FromFile("picture1.svg");
                }

                MemoryStream ms = new MemoryStream(cover);

                return ImageSource.FromStream(() => ms);
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public BaseViewModel() { }

        public BaseViewModel(int iD, byte[] cover, string name)
        {
            ID = iD;
            this.cover = cover;
            Name = name;
        }

        public BaseViewModel(IModel material)
        {
            ID = material.ID;
            this.cover = material.Cover;
            Name = material.Name;
        }

        public void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public bool SetProperty<T>(ref T storage, T value, [CallerMemberName] string propertyName = null)
        {
            if (Object.Equals(storage, value))
                return false;

            storage = value;
            OnPropertyChanged(propertyName);
            return true;
        }

        public async void TakePhoto()
        {
            Stream stream = await new PhotoPickerService().GetImageStreamAsync();
            if (stream != null)
            {
                MemoryStream memory = new MemoryStream();
                await stream.CopyToAsync(memory);
                cover = memory.ToArray();
            }
        }
    }
}
