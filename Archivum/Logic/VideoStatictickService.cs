using Archivum.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Archivum.Logic
{
   public class VideoStatictickService
    {
        readonly IRepository repository;


        public VideoStatictickService(IRepository repository)
        {
            this.repository = repository;
        }

        #region anime statictick
        public async Task<int> GetAnimeCountAsync()
        {
            string query = "select count(*) from Anime";
            return await repository.ExecuteScalar<Anime>(query);;
        }

        public async Task<int> GetAnimeSeriesCount()
        {
            string query = "SELECT Sum(SeriesCount) FROM [Anime]";
            return await repository.ExecuteScalar<Anime>(query);
        }

        public async Task<int> GetAnimeSeriesLengthSum()
        {
            string query = "SELECT Sum(Serieslength) FROM [Anime]";
            return await repository.ExecuteScalar<Anime>(query);
        }

        public async Task<int> GetAnimeMaxSeriesCount()
        {
            string query = "SELECT Max(SeriesCount) FROM [Anime]";
            return await repository.ExecuteScalar<Anime>(query);
        }

        public async Task<int> GetAnimeMinSeriesCount()
        {
            string query = "SELECT Min(SeriesCount) FROM [Anime]";
            return await repository.ExecuteScalar<Anime>(query);
        }

        public async Task<int> GetAnimeMaxSeriesLength()
        {
            string query = "SELECT Max(SeriesLength) FROM [Anime]";
            return await repository.ExecuteScalar<Anime>(query);
        }

        public async Task<int> GetAnimeMinSeriesLength()
        {
            string query = "SELECT Min(SeriesLength) FROM [Anime]";
            return await repository.ExecuteScalar<Anime>(query);
        }

        public async Task<int> GetAnimeWaifuCount()
        {
            string query = $"SELECT Count(*) FROM [Anime] where Waifu<>'' ";
            return await repository.ExecuteScalar<Anime>(query);
        }

        #endregion

        #region film statictick

        public async Task<int> GetFilmCountAsync()
        {
            string query = "select count(*) from [Film]";
            return await repository.ExecuteScalar<Anime>(query); ;
        }

        public async Task<int> GetFilmLengthSum()
        {
            string query = "SELECT Sum(Filmlength) FROM [Film]";
            return await repository.ExecuteScalar<Anime>(query);
        }

        public async Task<int> GetFilmMaxLength()
        {
            string query = "SELECT Max(Filmlength) FROM [Film]";
            return await repository.ExecuteScalar<Anime>(query);
        }

        public async Task<int> GetFilmMinSeriesCount()
        {
            string query = "SELECT Min(Filmlength) FROM [Film]";
            return await repository.ExecuteScalar<Anime>(query);
        }

        #endregion

        #region series statictick

        public async Task<int> GetSeriesCountAsync()
        {
            string query = "select count(*) from Series";
            return await repository.ExecuteScalar<Anime>(query); ;
        }

        public async Task<int> GetSeriesSeriesCount()
        {
            string query = "SELECT Sum(SeriesCount) FROM [Series]";
            return await repository.ExecuteScalar<Anime>(query);
        }

        public async Task<int> GetSeriesSeriesLengthSum()
        {
            string query = "SELECT Sum(Serieslength) FROM [Series]";
            return await repository.ExecuteScalar<Anime>(query);
        }

        public async Task<int> GetSeriesMaxSeriesCount()
        {
            string query = "SELECT Max(SeriesCount) FROM [Series]";
            return await repository.ExecuteScalar<Anime>(query);
        }

        public async Task<int> GetSeriesMinSeriesCount()
        {
            string query = "SELECT Min(SeriesCount) FROM [Series]";
            return await repository.ExecuteScalar<Anime>(query);
        }

        public async Task<int> GetSeriesMaxSeriesLength()
        {
            string query = "SELECT Max(SeriesLength) FROM [Series]";
            return await repository.ExecuteScalar<Anime>(query);
        }

        public async Task<int> GetSeriesMinSeriesLength()
        {
            string query = "SELECT Min(SeriesLength) FROM [Series]";
            return await repository.ExecuteScalar<Anime>(query);
        }
        #endregion
    }
}
