using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Archivum.Logic;

namespace Archivum.Interfaces
{
    public interface IListView
    {
        ObservableCollection<IViewModel> Collection { get; }
        IViewModel SelectedVM { get; }
    }
}
