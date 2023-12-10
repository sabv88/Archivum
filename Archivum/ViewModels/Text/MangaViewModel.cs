using Archivum.Interfaces;
using Archivum.Logic;
using Archivum.Models.Text;
using CommunityToolkit.Mvvm.Messaging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Archivum.ViewModels.Text
{

    internal class MangaViewModel : TextLibraryViewModel
    {
        string comment;
        int pagesAmount;

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

        public int PagesAmount
        {
            get => pagesAmount;
            set
            {
                if (pagesAmount != value)
                {
                    pagesAmount = value;
                    OnPropertyChanged(nameof(PagesAmount));
                }
            }
        }

        public new ICommand SaveItem => new Command(async () =>
        {
            _ = repository.SaveItemAsync(new Manga(ID, Name, cover, pagesAmount, comment), ID);
        });

       new public ICommand DeleteItem => new Command(
     execute: async () =>
         {
             _ = repository.DeleteItemAsync(new Manga(ID, Name, cover, pagesAmount, comment));
             WeakReferenceMessenger.Default.Send(new DeleteTextItemMessage(this)); 
             await Shell.Current.GoToAsync($"..");
         });

        public MangaViewModel(IRepository repository) : base(repository) { }
        public MangaViewModel(int ID, string Name, byte[] cover, IRepository repository, string Comment, int PagesAmount) : base(ID, Name, cover, repository)
        {
            this.Comment = Comment;
            this.PagesAmount = PagesAmount;
        }

        public MangaViewModel(Manga manga, IRepository repository) : base(repository)
        {
            this.ID = manga.ID;
            this.Name = manga.Name;
            this.cover = manga.Cover;
            this.PagesAmount = manga.PagesAmount;
            this.Comment = manga.Comment;
        }
    }
}
