using Archivum.Interfaces;
using Archivum.Logic;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Archivum.ViewModels.Text
{
    internal class TextStatistickViewModel : BaseStatistickViewModel, ITextStatistickViewModel
    {
        readonly ITextStatictickService textStatictickService;

        public int AllCount { get; set; }
        public int AllPages { get; set; }


        public int BooksCount { get; set; }
        public int BooksPagesCount { get; set; }
        public int BooksMaxPagesAmount { get; set; }
        public int BooksMinPagesAmount { get; set; }


        public int MangaCount { get; set; }
        public int MangaPagesCount { get; set; }
        public int MangaMaxPagesAmount { get; set; }
        public int MangaMinPagesAmount { get; set; }


        public event PropertyChangedEventHandler PropertyChanged;

        public TextStatistickViewModel(ITextStatictickService textStatictickService)
        {
            this.textStatictickService = textStatictickService;
            GetItemsAsync();
        }

        public async void GetItemsAsync()
        {

            BooksCount = await textStatictickService.GetBookCountAsync();
            BooksPagesCount = await textStatictickService.GetBookPagesSum();
            BooksMaxPagesAmount = await textStatictickService.GetBookPagesMaxAmount();
            BooksMinPagesAmount = await textStatictickService.GetBookPagesMinAmount();

            MangaCount = await textStatictickService.GetMangaCountAsync();
            MangaPagesCount = await textStatictickService.GetMangaPagesSum();
            MangaMaxPagesAmount = await textStatictickService.GetMangaPagesMaxAmount();
            MangaMinPagesAmount = await textStatictickService.GetMangaPagesMinAmount();

            AllCount = BooksCount + MangaCount;
            AllPages = BooksPagesCount + MangaPagesCount;

            OnPropertyChanged(nameof(BooksCount));
            OnPropertyChanged(nameof(BooksPagesCount));
            OnPropertyChanged(nameof(BooksMaxPagesAmount));
            OnPropertyChanged(nameof(BooksMinPagesAmount));

            OnPropertyChanged(nameof(MangaCount));
            OnPropertyChanged(nameof(MangaPagesCount));
            OnPropertyChanged(nameof(MangaMaxPagesAmount));
            OnPropertyChanged(nameof(MangaMinPagesAmount));

            OnPropertyChanged(nameof(AllCount));
            OnPropertyChanged(nameof(AllPages));
        }
    }
}
