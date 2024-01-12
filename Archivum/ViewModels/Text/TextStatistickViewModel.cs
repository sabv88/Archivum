using Archivum.Interfaces;
using Archivum.Logic;
using Microcharts;
using SkiaSharp;
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
        public int AllChapters { get; private set; }
        public int AllPages { get; set; }


        public int BooksCount { get; set; }
        public int BooksPagesCount { get; set; }
        public int BooksMaxPagesAmount { get; set; }
        public int BooksMinPagesAmount { get; set; }
        public int BooksChaptersCount { get; set; }
        public int BooksMaxChaptersAmount { get; set; }
        public int BooksMinChaptersAmount { get; set; }
        public int BookWatchedCount { get; set; }
        public int BookInProgressCount { get; set; }
        public int BookDroppedCount { get; set; }
        public int BookInPlanCount { get; set; }


        public int MangaCount { get; set; }
        public int MangaChaptersCount { get; set; }
        public int MangaMaxChaptersAmount { get; set; }
        public int MangaMinChaptersAmount { get; set; }
        public int MangaWatchedCount { get; set; }
        public int MangaInProgressCount { get; set; }
        public int MangaDroppedCount { get; set; }
        public int MangaInPlanCount { get; set; }
        public LineChart BookStatusChart { get; set; }
        public LineChart MangaStatusChart { get; set; }

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
            BooksChaptersCount = await textStatictickService.GetBookСhaptersSum();
            BooksMaxChaptersAmount = await textStatictickService.GetBookChaptersMinAmount();
            BooksMinChaptersAmount = await textStatictickService.GetBookChaptersMaxAmount();
            BookWatchedCount = await textStatictickService.GetBookWatchedCount();
            BookInProgressCount = await textStatictickService.GetBookInProgressCount();
            BookDroppedCount = await textStatictickService.GetBookDroppedCount();
            BookInPlanCount = await textStatictickService.GetBookInPlanCount();

            MangaCount = await textStatictickService.GetMangaCountAsync();
            MangaChaptersCount = await textStatictickService.GetMangaСhaptersSum();
            MangaMaxChaptersAmount = await textStatictickService.GetMangaChaptersMinAmount();
            MangaMinChaptersAmount = await textStatictickService.GetMangaChaptersMaxAmount();
            MangaWatchedCount = await textStatictickService.GetMangaWatchedCount();
            MangaInProgressCount = await textStatictickService.GetMangaInProgressCount();
            MangaDroppedCount = await textStatictickService.GetMangaDroppedCount();
            MangaInPlanCount = await textStatictickService.GetMangaInPlanCount();

            AllCount = BooksCount + MangaCount;
            AllChapters = BooksChaptersCount + MangaChaptersCount;

            BookStatusChart = new LineChart()
            {
                BackgroundColor = SKColors.Black,

                Entries = new ChartEntry[]
             {

                    new ChartEntry(BookWatchedCount)
                    {
                         Label = "Прочитанно",
                         ValueLabel = BookWatchedCount.ToString(),
                         Color = SKColor.Parse("#7B68EE"),
                         ValueLabelColor = SKColors.White,
                         TextColor = SKColors.White
                    },
                     new ChartEntry(BookInProgressCount)
                    {
                         Label = "В процессе",
                         ValueLabel = BookInProgressCount.ToString(),
                         Color = SKColor.Parse("#00BFFF"),
                         ValueLabelColor = SKColors.White,
                         TextColor = SKColors.White
                    },
                      new ChartEntry(BookDroppedCount)
                    {
                         Label = "Брошено",
                         ValueLabel = BookDroppedCount.ToString(),
                         Color = SKColor.Parse("#191970"),
                         ValueLabelColor = SKColors.White,
                         TextColor = SKColors.White
                    },
                        new ChartEntry(BookInPlanCount)
                    {
                         Label = "В планах",
                         ValueLabel = BookInPlanCount.ToString(),
                         Color = SKColor.Parse("#1E90FF"),
                         ValueLabelColor = SKColors.White,
                         TextColor = SKColors.White
                    },
             }
            };

            MangaStatusChart = new LineChart()
            {
                BackgroundColor = SKColors.Black,

                Entries = new ChartEntry[]
             {

                    new ChartEntry(MangaWatchedCount)
                    {
                         Label = "Прочитанно",
                         ValueLabel = MangaWatchedCount.ToString(),
                         Color = SKColor.Parse("#FF6347"),
                         ValueLabelColor = SKColors.White,
                         TextColor = SKColors.White
                    },
                     new ChartEntry(MangaInProgressCount)
                    {
                         Label = "В процессе",
                         ValueLabel = MangaInProgressCount.ToString(),
                         Color = SKColor.Parse("#FFA07A"),
                         ValueLabelColor = SKColors.White,
                         TextColor = SKColors.White
                    },
                      new ChartEntry(MangaDroppedCount)
                    {
                         Label = "Брошено",
                         ValueLabel = MangaDroppedCount.ToString(),
                         Color = SKColor.Parse("#FF8C00"),
                         ValueLabelColor = SKColors.White,
                         TextColor = SKColors.White
                    },
                        new ChartEntry(MangaInPlanCount)
                    {
                         Label = "В планах",
                         ValueLabel = MangaInPlanCount.ToString(),
                         Color = SKColor.Parse("#CD5C5C"),
                         ValueLabelColor = SKColors.White,
                         TextColor = SKColors.White
                    },
             }
            };
            OnPropertyChanged(nameof(BooksCount));
            OnPropertyChanged(nameof(BooksPagesCount));
            OnPropertyChanged(nameof(BooksMaxPagesAmount));
            OnPropertyChanged(nameof(BooksMinPagesAmount));
            OnPropertyChanged(nameof(BooksChaptersCount));
            OnPropertyChanged(nameof(BooksMaxChaptersAmount));
            OnPropertyChanged(nameof(BooksMinChaptersAmount));
            OnPropertyChanged(nameof(BooksPagesCount));
            OnPropertyChanged(nameof(BooksMaxPagesAmount));
            OnPropertyChanged(nameof(BooksMinPagesAmount));
            OnPropertyChanged(nameof(BookStatusChart));

            OnPropertyChanged(nameof(MangaCount));
            OnPropertyChanged(nameof(MangaChaptersCount));
            OnPropertyChanged(nameof(MangaMaxChaptersAmount));
            OnPropertyChanged(nameof(MangaMinChaptersAmount));
            OnPropertyChanged(nameof(MangaStatusChart));

            OnPropertyChanged(nameof(AllCount));
            OnPropertyChanged(nameof(AllChapters));
        }
    }
}
