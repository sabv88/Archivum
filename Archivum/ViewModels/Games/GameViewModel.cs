using Archivum.Interfaces;
using Archivum.Logic;
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
                   repository.SaveItemAsync(new GamesMaterial(ID, name, cover), ID);
               });

        public ICommand DeleteItem => new Command(
            execute: async () =>
            {
                _ = repository.DeleteItemAsync(new GamesMaterial(ID, name, cover));
                WeakReferenceMessenger.Default.Send(new DeleteGamesItemMessage(this));
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
        }

        public GameViewModel(int ID, string Name, byte[] cover, IRepository repository)
        {
            this.repository = repository;
            this.ID = ID;
            this.Name = Name;
            this.cover = cover;
        }
    }
}
