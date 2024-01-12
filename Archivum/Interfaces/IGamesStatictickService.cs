namespace Archivum.Interfaces
{
    internal interface IGamesStatictickService
    {
        public Task<int> GetGamesCountAsync();
        Task<int> GetGamesWatchedCount();
        Task<int> GetGamesInProgressCount();
        Task<int> GetGamesDroppedCount();
        Task<int> GetGamesInPlanCount();
    }
}