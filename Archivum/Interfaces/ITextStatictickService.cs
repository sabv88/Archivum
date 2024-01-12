using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Archivum.Interfaces
{
    public interface ITextStatictickService
    {
        Task<int> GetBookCountAsync();
        Task<int> GetBookPagesSum();
        Task<int> GetBookPagesMaxAmount();
        Task<int> GetBookPagesMinAmount();
        Task<int> GetBookСhaptersSum();
        Task<int> GetBookChaptersMaxAmount();
        Task<int> GetBookChaptersMinAmount();
        Task<int> GetBookWatchedCount();
        Task<int> GetBookInProgressCount();
        Task<int> GetBookDroppedCount();
        Task<int> GetBookInPlanCount();

        Task<int> GetMangaCountAsync();
        Task<int> GetMangaСhaptersSum();
        Task<int> GetMangaChaptersMinAmount();
        Task<int> GetMangaChaptersMaxAmount(); 
        Task<int> GetMangaWatchedCount();
        Task<int> GetMangaInProgressCount();
        Task<int> GetMangaDroppedCount();
        Task<int> GetMangaInPlanCount();

    }
}
