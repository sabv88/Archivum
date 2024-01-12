using Archivum.Interfaces;
using Archivum.Models.Text;
using Archivum.Models.Video;

namespace Archivum.Logic
{
    public class TextStatistickService: ITextStatictickService
    {
        readonly IRepository repository;

        public TextStatistickService(IRepository repository)
        {
            this.repository = repository;
        }

        #region book statictick

        public async Task<int> GetBookCountAsync()
        {
            string query = "select count(*) from [Book]";
            return await repository.ExecuteScalar<Book>(query);
        }

        public async Task<int> GetBookPagesSum()
        {
            string query = "SELECT Sum(PagesAmount) FROM [Book]";
            return await repository.ExecuteScalar<Book>(query);
        }

        public async Task<int> GetBookPagesMaxAmount()
        {
            string query = "SELECT Max(PagesAmount) FROM [Book]";
            return await repository.ExecuteScalar<Book>(query);
        }

        public async Task<int> GetBookPagesMinAmount()
        {
            string query = "SELECT Min(PagesAmount) FROM [Book]";
            return await repository.ExecuteScalar<Book>(query);
        }
        public async Task<int> GetBookСhaptersSum()
        {
            string query = "SELECT Sum(СhaptersAmount) FROM [Book]";
            return await repository.ExecuteScalar<Book>(query);
        }
        public async Task<int> GetBookChaptersMaxAmount()
        {
            string query = "SELECT Max(СhaptersAmount) FROM [Book]";
            return await repository.ExecuteScalar<Book>(query);
        }
        public async Task<int> GetBookChaptersMinAmount()
        {
            string query = "SELECT Min(СhaptersAmount) FROM [Book]";
            return await repository.ExecuteScalar<Book>(query);
        }
        public async Task<int> GetBookWatchedCount()
        {
            string query = $"SELECT Count(*) FROM [Book] where Status = 1";
            return await repository.ExecuteScalar<Book>(query);
        }
        public async Task<int> GetBookInProgressCount()
        {
            string query = $"SELECT Count(*) FROM [Book] where Status = 0";
            return await repository.ExecuteScalar<Book>(query);
        }
        public async Task<int> GetBookDroppedCount()
        {
            string query = $"SELECT Count(*) FROM [Book] where Status = 2";
            return await repository.ExecuteScalar<Book>(query);
        }
        public async Task<int> GetBookInPlanCount()
        {
            string query = $"SELECT Count(*) FROM [Book] where Status = 3";
            return await repository.ExecuteScalar<Book>(query);
        }
        #endregion

        #region manga statictick

        public async Task<int> GetMangaCountAsync()
        {
            string query = "select count(*) from [Manga]";
            return await repository.ExecuteScalar<Manga>(query);
        }

        public async Task<int> GetMangaСhaptersSum()
        {
            string query = "SELECT Sum(СhaptersAmount) FROM [Manga]";
            return await repository.ExecuteScalar<Manga>(query);
        }
        public async Task<int> GetMangaChaptersMaxAmount()
        {
            string query = "SELECT Max(СhaptersAmount) FROM [Manga]";
            return await repository.ExecuteScalar<Manga>(query);
        }
        public async Task<int> GetMangaChaptersMinAmount()
        {
            string query = "SELECT Min(СhaptersAmount) FROM [Manga]";
            return await repository.ExecuteScalar<Manga>(query);
        }
        public async Task<int> GetMangaWatchedCount()
        {
            string query = $"SELECT Count(*) FROM [Manga] where Status = 1";
            return await repository.ExecuteScalar<Manga>(query);
        }
        public async Task<int> GetMangaInProgressCount()
        {
            string query = $"SELECT Count(*) FROM [Manga] where Status = 0";
            return await repository.ExecuteScalar<Manga>(query);
        }
        public async Task<int> GetMangaDroppedCount()
        {
            string query = $"SELECT Count(*) FROM [Manga] where Status = 2";
            return await repository.ExecuteScalar<Manga>(query);
        }
        public async Task<int> GetMangaInPlanCount()
        {
            string query = $"SELECT Count(*) FROM [Manga] where Status = 3";
            return await repository.ExecuteScalar<Manga>(query);
        }
        #endregion

    }
}
