using Archivum.Interfaces;
using Archivum.Models;

namespace Archivum.Logic
{
    internal class GamesStatisticService : IGamesStatictickService
    {
        readonly IRepository repository;

        public GamesStatisticService(IRepository repository)
        {
            this.repository = repository;
        }

        public async Task<int> GetGamesCountAsync()
        {
            string query = "select count(*) from [GamesMaterial]";
            return await repository.ExecuteScalar<GamesMaterial>(query);
        }

        public async Task<int> GetGamesWatchedCount()
        {
            string query = $"SELECT Count(*) FROM [GamesMaterial] where Status = 1";
            return await repository.ExecuteScalar<GamesMaterial>(query);
        }
        public async Task<int> GetGamesInProgressCount()
        {
            string query = $"SELECT Count(*) FROM [GamesMaterial] where Status = 0";
            return await repository.ExecuteScalar<GamesMaterial>(query);
        }
        public async Task<int> GetGamesDroppedCount()
        {
            string query = $"SELECT Count(*) FROM [GamesMaterial] where Status = 2";
            return await repository.ExecuteScalar<GamesMaterial>(query);
        }
        public async Task<int> GetGamesInPlanCount()
        {
            string query = $"SELECT Count(*) FROM [GamesMaterial] where Status = 3";
            return await repository.ExecuteScalar<GamesMaterial>(query);
        }

    }
}
