using Archivum.Interfaces;
using Archivum.Logic;
using Archivum.Models;
using Archivum.ViewModels.Text;
using CommunityToolkit.Mvvm.Messaging;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Archivum.ViewModels
{
    public abstract class BaseListViewModel : INotifyPropertyChanged, IListView
    {

        public event PropertyChangedEventHandler PropertyChanged;   
        IViewModel selectedVM;
        internal int start = 0;
        internal string filter;
        public ObservableCollection<IViewModel> Collection { get; set; } = new();
        internal IlistService listService;
        internal IRepository repository;
        public ICommand TapItem { get; set; }

        public string Filter
        {
            get
            {
                return filter;
            }
            set
            {
                start = 0;
                filter = value;
                Collection.Clear();
                _ = GetNextItemsAsync();
            }

        }


        public IViewModel SelectedVM
        {
            get { return selectedVM; }
            set
            {
                if (selectedVM != value)
                {
                    IViewModel tempVM = value;
                    selectedVM = null;
                    SelectedVM = null;
                    OnPropertyChanged(nameof(SelectedVM));
                    TapItemAsync(tempVM);
                }
            }
        }

        protected BaseListViewModel(IRepository repository, IlistService listService)
        {
            this.listService = listService;
            this.repository = repository;
        }

        public abstract Task GetNextItemsAsync();

        public abstract Task TapItemAsync(IViewModel textMaterial);


        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
                handler(this, new PropertyChangedEventArgs(propertyName));
        }

    }
}
