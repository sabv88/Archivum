using Archivum.Logic;
using Archivum.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Xml.Linq;

namespace Archivum.ViewModels
{
    public class FilmViewModel : VideoLibraryViewModel
    {        
        int filmlength;
        string comment;

        public string Comment
        {
            get => comment;
            set
            {
                if (comment != value)
                {
                    comment = value;
                    OnPropertyChanged(nameof(Comment));
                }
            }
        }
        public int Filmlength
        {
            get => filmlength;
            set
            {
                if (filmlength != value)
                {
                    filmlength = value;
                    OnPropertyChanged(nameof(Filmlength));
                }
            }
        }

        public new ICommand SaveItem => new Command(async () =>
        {
            Repository repository = new Repository();
            _ = repository.SaveItemAsync(new Film(ID, Name, comment, cover, Filmlength), ID);
            MessagingCenter.Send<VideoLibraryViewModel>(this, "Change video element");
        });

        public FilmViewModel(IRepository repository) : base(repository) { }
        public FilmViewModel(int ID, string Name, byte[] cover, IRepository repository, int filmlength, string comment) : base(ID, Name, cover, repository)
        {
            Filmlength = filmlength;
            Comment = comment;
           
        }

        public override void RefreshProperties()
        {
            OnPropertyChanged("Name");
            OnPropertyChanged("Comment");
            OnPropertyChanged("Type");
            OnPropertyChanged("Cover");
            OnPropertyChanged("Filmlength");
        }

    }
}
