namespace Archivum.Interfaces
{
    internal interface IGamesStatictickService
    {
        public Task<int> GetGamesCountAsync();
    }
}