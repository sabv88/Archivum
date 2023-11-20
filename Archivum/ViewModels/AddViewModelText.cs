using Archivum.Logic;
using Archivum.Models;
using System.Windows.Input;

namespace Archivum.ViewModels
{
    public partial class AddViewModelText : TextLibraryViewModel
    {
        string type;
        string comment;
        int pagesAmount;

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
                _ = await repository.SaveItemAsync(new Manga(0, Name, cover, pagesAmount, comment), 0);
            }

            if (Type == "Книга")
            {
                _ = await repository.SaveItemAsync(new Book(0, Name, cover, pagesAmount, comment), 0);
            }

        });
    }
}
