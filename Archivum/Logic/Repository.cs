﻿using Archivum.Interfaces;
using Archivum.Models;
using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Archivum.Logic
{
    public class Repository : IRepository
    {
        public SQLiteAsyncConnection Database { get; set; }

        public Repository()
        {

        }

        public async Task Init<T>() where T : new()
        {
            if (Database is null)
            {
                Database = new SQLiteAsyncConnection(Constants.DatabasePath, Constants.Flags);
            }

            _ = await Database.CreateTableAsync<T>().ConfigureAwait(false);
        }

        public async Task<List<T>> GetItemsAsync<T>() where T : new()
        {
            await Init<T>();
            return await Database.Table<T>().ToListAsync().ConfigureAwait(false);
        }

        public async Task<List<T>> ExecuteRequest<T>(string query) where T : new()
        {
            await Init<T>();
            return await Database.QueryAsync<T>(query).ConfigureAwait(false);
        }

        public async Task<List<T>> SelectModels<T>(string query) where T : IModel, new()
        {
            await Init<T>();
            return await Database.QueryAsync<T>(query);
        }


        public async Task<int> ExecuteScalar<T>(string query) where T : new()
        {
            await Init<T>();

            return await Database.ExecuteScalarAsync<int>(query).ConfigureAwait(false);
        }

        public async Task<int> DeleteItemAsync<T>(T item) where T : new()
        {
            await Init<T>();
            var a = await Database.DeleteAsync(item).ConfigureAwait(false);
            return a;
        }

        public async Task<int> SaveItemAsync<T>(T item, int Id) where T : new()
        {
            await Init<T>();
            if (Id != 0)
            {
                return await Database.UpdateAsync(item).ConfigureAwait(false);
            }
            else
            {
                return await Database.InsertAsync(item, typeof(T)).ConfigureAwait(false);
            }

        }

        public async Task<T> GetItemAsync<T>(int Id) where T : IModel, new()
        {
            await Init<T>();
            return await Database.Table<T>().Where(i => i.ID == Id).FirstOrDefaultAsync().ConfigureAwait(false);
        }

        public async Task<int> GetCount<T>() where T : new()
        {
            await Init<T>();
            return await Database.Table<T>().CountAsync().ConfigureAwait(false);
        }
    }
}
