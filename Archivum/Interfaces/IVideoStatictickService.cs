using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Archivum.Interfaces
{
    public interface IVideoStatictickService
    {
        Task<int> GetAnimeCountAsync();
        Task<int> GetAnimeSeriesCount();
        Task<int> GetAnimeSeriesLengthSum();
        Task<int> GetAnimeMaxSeriesCount();
        Task<int> GetAnimeMinSeriesCount();
        Task<int> GetAnimeMaxSeriesLength();
        Task<int> GetAnimeMinSeriesLength();
        Task<int> GetAnimeWaifuCount();
        Task<int> GetAnimeWatchedCount();
        Task<int> GetAnimeInProgressCount();
        Task<int> GetAnimeDroppedCount();
        Task<int> GetAnimeInPlanCount();

        Task<int> GetFilmCountAsync();
        Task<int> GetFilmLengthSum();
        Task<int> GetFilmMaxLength();
        Task<int> GetFilmMinSeriesCount();
        Task<int> GetFilmWatchedCount();
        Task<int> GetFilmInProgressCount();
        Task<int> GetFilmDroppedCount();
        Task<int> GetFilmInPlanCount();


        Task<int> GetSeriesCountAsync();
        Task<int> GetSeriesSeriesCount();
        Task<int> GetSeriesSeriesLengthSum();
        Task<int> GetSeriesMaxSeriesCount();
        Task<int> GetSeriesMinSeriesCount();
        Task<int> GetSeriesMaxSeriesLength();
        Task<int> GetSeriesMinSeriesLength();
        Task<int> GetSeriesWatchedCount();
        Task<int> GetSeriesInProgressCount();
        Task<int> GetSeriesDroppedCount();
        Task<int> GetSeriesInPlanCount();

    }
}
