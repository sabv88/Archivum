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

        Task<int> GetMangaCountAsync();
        Task<int> GetMangaPagesSum();
        Task<int> GetMangaPagesMaxAmount();
        Task<int> GetMangaPagesMinAmount();
    }
}
