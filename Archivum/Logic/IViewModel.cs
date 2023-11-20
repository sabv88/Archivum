using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Archivum.Logic
{
    public interface IViewModel
    {
        int ID { get; }
        string Name { get; }
        byte[] cover { get; }
        public ICommand SaveItem => new Command<object>(
                execute: (object obj) =>
                {
                  
                });
        public ICommand DeleteItem => new Command(
            execute: async () =>
            {
               
            });
        public ICommand AddImage => new Command(
            execute: () =>
            {
              
            });

      public void RefreshProperties();
    }
}
