using Archivum.Interfaces;
using Archivum.Logic;
using Archivum.Models;
using Archivum.Models.Text;
using CommunityToolkit.Mvvm.Messaging;
using System.Windows.Input;

namespace Archivum.ViewModels.Text
{
    public partial class AddViewModelText : TextLibraryViewModel
    {
        string type;
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
        public AddViewModelText(IRepository repository) : base(repository)
        {

        }

        public string Type
        {
            get => type;
            set
            {
                if (type != value)
                {
                    type = value;
                    OnPropertyChanged(nameof(Type));
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

            if (Type == "Манга")
            {                
                var a = new Manga(0, name, cover, status, estimation, comment, chaptersAmount);
                _ = await repository.SaveItemAsync(a, 0);
                 SendMessageAdd(status, new MangaViewModel(a, repository));
            }

            if (Type == "Книга")
            {
                var a = new Book(0, Name, cover, status, estimation, pagesAmount, comment, chaptersAmount);
                _ = await repository.SaveItemAsync(a, 0);
                SendMessageAdd(status, new BookViewModel(a, repository));
            }

            if (Type == null)
            {
                var a = new TextMaterial(0, Name, cover, status, estimation);
                _ = await repository.SaveItemAsync(a, 0);
                SendMessageAdd(status, new TextLibraryViewModel(a, repository));
            }

        });
    }
}
