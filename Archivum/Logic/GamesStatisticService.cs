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
    }
}
