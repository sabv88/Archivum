using Archivum.Interfaces;
using Archivum.Logic;
using Archivum.Logic.Messages.Games;
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
                var a = new GamesMaterial(0, Name, cover, status, estimation);
                _ = await repository.SaveItemAsync(a, 0);
                switch (status)
                {
                    case 0:
                        {
                            WeakReferenceMessenger.Default.Send(new AddGamesInProgressItemMessage(new GameViewModel(a, repository)));
                            break;
                        }
                    case 1:
                        {
                            WeakReferenceMessenger.Default.Send(new AddGamesFinishedItemMessage(new GameViewModel(a, repository)));
                            break;
                        }
                    case 2:
                        {
                            WeakReferenceMessenger.Default.Send(new AddGamesDroppedItemMessage(new GameViewModel(a, repository)));
                            break;
                        }
                    case 3:
                        {
                            WeakReferenceMessenger.Default.Send(new AddGamesInPlanItemMessage(new GameViewModel(a, repository)));
                            break;
                        }
                }
            }

        });
    }
}
