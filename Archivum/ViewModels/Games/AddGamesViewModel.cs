using Archivum.Interfaces;
using Archivum.Logic;
using Archivum.Models;
using CommunityToolkit.Mvvm.Messaging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Archivum.ViewModels.Games
{
    class AddGamesViewModel : GameViewModel
    {
        string type;

        public AddGamesViewModel(IRepository repository) : base(repository)
        {

        }

        public string Type
        {
            get => type;
            set
            {
                if (type != value)
                {
                    type = value;
                    OnPropertyChanged(nameof(Type));
                }
            }
        }
        public new ICommand SaveItem => new Command(async () =>
        {
            if (Type == null)
            {
                var a = new GamesMaterial(0, Name, cover);
                _ = await repository.SaveItemAsync(a, 0);
                WeakReferenceMessenger.Default.Send(new AddGamesItemMessage(new GameViewModel(a, repository)));
            }

        });
    }
}
