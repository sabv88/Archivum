using Archivum.Logic;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Archivum.ViewModels
{
    internal class TextStatistickViewModel: INotifyPropertyChanged
    {
        readonly TextLibraryRepository database = new TextLibraryRepository();
        public int AllCount { get; set; }
        public int BooksCount { get; set; }
        public int MangaCount { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;

        public TextStatistickViewModel()
        {
            GetItemsAsync();
        }

        public async void GetItemsAsync()
        {
            BooksCount = await database.GetCount("Книга");
            MangaCount = await database.GetCount("Манга");
            AllCount = BooksCount + MangaCount;
            OnPropertyChanged("BooksCount");
            OnPropertyChanged("MangaCount");
            OnPropertyChanged("AllCount");

        }

        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        }
    }
}
