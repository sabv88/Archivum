using Archivum.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Archivum.Logic
{
    internal class TextStatistickService
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
            return await repository.ExecuteScalar<Anime>(query);
        }

        public async Task<int> GetBookPagesMinAmount()
        {
            string query = "SELECT Min(PagesAmount) FROM [Book]";
            return await repository.ExecuteScalar<Anime>(query);
        }
        #endregion

        #region manga statictick

        public async Task<int> GetMangaCountAsync()
        {
            string query = "select count(*) from [Manga]";
            return await repository.ExecuteScalar<Book>(query);
        }

        public async Task<int> GetMangaPagesSum()
        {
            string query = "SELECT Sum(PagesAmount) FROM [Manga]";
            return await repository.ExecuteScalar<Book>(query);
        }

        public async Task<int> GetMangaPagesMaxAmount()
        {
            string query = "SELECT Max(PagesAmount) FROM [Manga]";
            return await repository.ExecuteScalar<Anime>(query);
        }

        public async Task<int> GetMangaPagesMinAmount()
        {
            string query = "SELECT Min(PagesAmount) FROM [Manga]";
            return await repository.ExecuteScalar<Anime>(query);
        }

        #endregion

    }
}
