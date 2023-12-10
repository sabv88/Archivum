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
                var a = new Manga(0, name, cover, pagesAmount, comment);
                _ = await repository.SaveItemAsync(a, 0);
                WeakReferenceMessenger.Default.Send(new AddTextItemMessage(new MangaViewModel(a, repository)));
            }

            if (Type == "Книга")
            {
                var a = new Book(0, Name, cover, pagesAmount, comment);
                _ = await repository.SaveItemAsync(a, 0);
                WeakReferenceMessenger.Default.Send(new AddTextItemMessage(new BookViewModel(a, repository)));

            }

            if (Type == null)
            {
                var a = new TextMaterial(0, Name, cover);
                _ = await repository.SaveItemAsync(a, 0);
                WeakReferenceMessenger.Default.Send(new AddTextItemMessage(new TextLibraryViewModel(a, repository)));
            }

        });
    }
}
