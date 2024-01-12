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
        int ID { get; set;}
        string Name { get; set;}
        byte[] cover { get; }
        int Status { get; set;}
        int Estimation { get; set;}

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
    }
}
