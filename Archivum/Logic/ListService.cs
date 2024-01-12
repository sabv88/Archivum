using Archivum.Interfaces;
using System.Collections.ObjectModel;

namespace Archivum.Logic
{
    internal class ListService : IlistService
    {
        readonly IRepository repository;

        public ListService(IRepository repository)
        {
            this.repository = repository;
        }

        public async Task<ObservableCollection<IViewModel>> GetNextItemsAsync<T, V>(string filter, int status, int start) where T : IModel, new() where V : class, IViewModel
        {
            ObservableCollection<IViewModel> Collection = new();
            string query = "SELECT * FROM [" + filter + "] where Status = "+ status + " ORDER BY Name LIMIT " + start + ", " + 10;
            var list = await repository.SelectModels<T>(query);
            MainThread.BeginInvokeOnMainThread(() =>
            {
                foreach (var item in list)
                {

                    var material = (IViewModel)Activator.CreateInstance(typeof(V), item, repository);
                    Collection.Add(material);
                }
            });

            return Collection;
        }
    }
}
