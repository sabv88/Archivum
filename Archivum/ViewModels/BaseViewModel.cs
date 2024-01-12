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
        internal int status;
        internal int estimation;

        public int Status
        {
            get => status;
            set
            {
                if (status != value)
                {
                    status = value;
                    OnPropertyChanged(nameof(Status));
                }
            }
        }

        public int Estimation 
        {
            get => estimation;
            set
            {
                if (estimation != value)
                {
                    estimation = value;
                    OnPropertyChanged(nameof(Estimation));
                }
            }
        }

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

        public byte[] Cover
        {
            get => cover;
            set
            {
                if (cover != value)
                {
                    cover = value;
                    OnPropertyChanged(nameof(Cover));
                }
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public BaseViewModel() { }

        public BaseViewModel(int iD, byte[] cover, string name, int status, int estimation)
        {
            ID = iD;
            this.cover = cover;
            Name = name;
            Status = status;
            Estimation = estimation;
        }

        public BaseViewModel(IModel material)
        {
            ID = material.ID;
            this.cover = material.Cover;
            Name = material.Name;
            Status = material.Status;
            Estimation = material.Estimation;
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
                OnPropertyChanged(nameof(Cover));
            }
        }
    }
}
