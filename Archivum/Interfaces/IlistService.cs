using Archivum.Logic;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Archivum.Interfaces
{
    public interface IlistService
    {
        Task<ObservableCollection<IViewModel>> GetNextItemsAsync<T, V>(string filter, int status, int start) where T : IModel, new() where V : class, IViewModel;
    }
}
