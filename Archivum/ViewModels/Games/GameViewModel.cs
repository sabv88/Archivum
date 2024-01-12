using Archivum.Interfaces;
using Archivum.Logic;
using Archivum.Logic.Messages.Games;
using Archivum.Models;
using CommunityToolkit.Mvvm.Messaging;
using System.Windows.Input;

namespace Archivum.ViewModels.Games
{
    internal class GameViewModel : BaseViewModel, IViewModel
    {
        internal IRepository repository;

        public ICommand SaveItem => new Command<object>(
               execute: (obj) =>
               {
                   repository.SaveItemAsync(new GamesMaterial(ID, name, cover, status, estimation), ID);                 
               });

        public ICommand DeleteItem => new Command(
            execute: async () =>
            {
                _ = repository.DeleteItemAsync(new GamesMaterial(ID, name, cover, status, estimation));
                switch (status)
                {
                    case 0:
                        {
                            WeakReferenceMessenger.Default.Send(new DeleteGamesItemInProgressMessage(this));
                            break;
                        }
                    case 1:
                        {
                            WeakReferenceMessenger.Default.Send(new DeleteGamesFinishedItemMessage(this));
                            break;
                        }
                    case 2:
                        {
                            WeakReferenceMessenger.Default.Send(new DeleteGamesDroppedItemMessage(this));
                            break;
                        }
                    case 3:
                        {
                            WeakReferenceMessenger.Default.Send(new DeleteGamesInPlanItemMessage(this));
                            break;
                        }
                }
                await Shell.Current.GoToAsync($"..");
            });

        public ICommand AddImage => new Command(
            execute: () =>
            {
                TakePhoto();
            });

        public GameViewModel(IRepository repository)
        {
            this.repository = repository;
        }

        public GameViewModel(IModel vd, IRepository repository)
        {
            this.repository = repository;
            ID = vd.ID;
            Name = vd.Name;
            cover = vd.Cover;
            status = vd.Status;
            estimation = vd.Estimation;
        }

        public GameViewModel(int ID, string Name, byte[] cover, int status, int estimation, IRepository repository)
        {
            this.repository = repository;
            this.ID = ID;
            this.Name = Name;
            this.cover = cover;
            this.status = status;
            this.estimation = estimation;
        }
    }
}
