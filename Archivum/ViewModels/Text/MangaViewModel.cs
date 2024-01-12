using Archivum.Interfaces;
using Archivum.Models.Text;
using System.Windows.Input;

namespace Archivum.ViewModels.Text
{

    internal class MangaViewModel : TextLibraryViewModel
    {
        string comment;
        int pagesAmount;
        string chaptersAmount;

        public string СhaptersAmount
        {
            get => chaptersAmount;
            set
            {
                if (chaptersAmount != value)
                {
                    chaptersAmount = value;
                    OnPropertyChanged(nameof(СhaptersAmount));
                }
            }
        }

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


        public new ICommand SaveItem => new Command(async () =>
        {
            _ = repository.SaveItemAsync(new Manga(ID, Name, cover, status, estimation, comment,  chaptersAmount), ID);
        });

       new public ICommand DeleteItem => new Command(
     execute: async () =>
         {
             _ = repository.DeleteItemAsync(new Manga(ID, Name, cover, status, estimation, comment, chaptersAmount));
             SendMessageDelete(status, this);
             await Shell.Current.GoToAsync($"..");
         });

        public MangaViewModel(IRepository repository) : base(repository) { }
        public MangaViewModel(int ID, string Name, byte[] cover, int status, int estimation, IRepository repository, string Comment) : base(ID, Name, cover, status, estimation, repository)
        {
            this.Comment = Comment;
        }

        public MangaViewModel(Manga manga, IRepository repository) : base(repository)
        {
            this.ID = manga.ID;
            this.Name = manga.Name;
            this.cover = manga.Cover;
            this.status = manga.Status;
            this.estimation = manga.Estimation;
            this.chaptersAmount = manga.СhaptersAmount;
            this.Comment = manga.Comment;
        }
    }
}
