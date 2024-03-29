﻿using Archivum.Interfaces;
using Archivum.Models.Video;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Archivum.Logic
{
    public class VideoStatictickService: IVideoStatictickService
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
            return await repository.ExecuteScalar<Anime>(query);
        }

        public async Task<int> GetAnimeSeriesCount()
        {
            string query = "SELECT Sum(SeriesCount) FROM [Anime]";
            return await repository.ExecuteScalar<Anime>(query);
        }

        public async Task<int> GetAnimeSeriesLengthSum()
        {
            string query = "SELECT Sum(Serieslength * SeriesCount) FROM [Anime]";
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
        public async Task<int> GetAnimeWatchedCount()
        {
            string query = $"SELECT Count(*) FROM [Anime] where Status = 1";
            return await repository.ExecuteScalar<Anime>(query);
        }
        public async Task<int> GetAnimeInProgressCount()
        {
            string query = $"SELECT Count(*) FROM [Anime] where Status = 0";
            return await repository.ExecuteScalar<Anime>(query);
        }
        public async Task<int> GetAnimeDroppedCount()
        {
            string query = $"SELECT Count(*) FROM [Anime] where Status = 2";
            return await repository.ExecuteScalar<Anime>(query);
        }
        public async Task<int> GetAnimeInPlanCount()
        {
            string query = $"SELECT Count(*) FROM [Anime] where Status = 3";
            return await repository.ExecuteScalar<Anime>(query);
        }
        #endregion

        #region film statictick

        public async Task<int> GetFilmCountAsync()
        {
            string query = "select count(*) from [Film]";
            return await repository.ExecuteScalar<Anime>(query);
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

        public async Task<int> GetFilmWatchedCount()
        {
            string query = $"SELECT Count(*) FROM [Film] where Status = 1";
            return await repository.ExecuteScalar<Film>(query);
        }
        public async Task<int> GetFilmInProgressCount()
        {
            string query = $"SELECT Count(*) FROM [Film] where Status = 0";
            return await repository.ExecuteScalar<Film>(query);
        }
        public async Task<int> GetFilmDroppedCount()
        {
            string query = $"SELECT Count(*) FROM [Film] where Status = 2";
            return await repository.ExecuteScalar<Film>(query);
        }
        public async Task<int> GetFilmInPlanCount()
        {
            string query = $"SELECT Count(*) FROM [Film] where Status = 3";
            return await repository.ExecuteScalar<Film>(query);
        }
        #endregion

        #region series statictick

        public async Task<int> GetSeriesCountAsync()
        {
            string query = "select count(*) from Serial";
            return await repository.ExecuteScalar<Serial>(query); ;
        }

        public async Task<int> GetSeriesSeriesCount()
        {
            string query = "SELECT Sum(SeriesCount) FROM [Serial]";
            return await repository.ExecuteScalar<Serial>(query);
        }

        public async Task<int> GetSeriesSeriesLengthSum()
        {
            string query = "SELECT Sum(Serieslength * SeriesCount) FROM [Serial]";
            return await repository.ExecuteScalar<Serial>(query);
        }

        public async Task<int> GetSeriesMaxSeriesCount()
        {
            string query = "SELECT Max(SeriesCount) FROM [Serial]";
            return await repository.ExecuteScalar<Serial>(query);
        }

        public async Task<int> GetSeriesMinSeriesCount()
        {
            string query = "SELECT Min(SeriesCount) FROM [Serial]";
            return await repository.ExecuteScalar<Serial>(query);
        }

        public async Task<int> GetSeriesMaxSeriesLength()
        {
            string query = "SELECT Max(SeriesLength) FROM [Serial]";
            return await repository.ExecuteScalar<Serial>(query);
        }

        public async Task<int> GetSeriesMinSeriesLength()
        {
            string query = "SELECT Min(SeriesLength) FROM [Serial]";
            return await repository.ExecuteScalar<Serial>(query);
        }
        public async Task<int> GetSeriesWatchedCount()
        {
            string query = $"SELECT Count(*) FROM [Serial] where Status = 1";
            return await repository.ExecuteScalar<Serial>(query);
        }
        public async Task<int> GetSeriesInProgressCount()
        {
            string query = $"SELECT Count(*) FROM [Serial] where Status = 0";
            return await repository.ExecuteScalar<Serial>(query);
        }
        public async Task<int> GetSeriesDroppedCount()
        {
            string query = $"SELECT Count(*) FROM [Serial] where Status = 2";
            return await repository.ExecuteScalar<Serial>(query);
        }
        public async Task<int> GetSeriesInPlanCount()
        {
            string query = $"SELECT Count(*) FROM [Serial] where Status = 3";
            return await repository.ExecuteScalar<Serial>(query);
        }
        #endregion
    }
}
