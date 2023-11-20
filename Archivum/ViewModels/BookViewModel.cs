﻿using Archivum.Logic;
using Archivum.Models;
using System.Windows.Input;

namespace Archivum.ViewModels
{
    internal class BookViewModel : TextLibraryViewModel
    {
        string comment;
        int pagesAmount;

        public string Comment
        {
            get => comment;
            set
            {
                if (comment != value)
                {
                    comment = value;
                    OnPropertyChanged(nameof(Comment));
                }
            }
        }

        public int PagesAmount
        {
            get => pagesAmount;
            set
            {
                if (pagesAmount != value)
                {
                    pagesAmount = value;
                    OnPropertyChanged(nameof(PagesAmount));
                }
            }
        }

        public new ICommand SaveItem => new Command(async () =>
        {
            _ = repository.SaveItemAsync(new Book(ID, Name, cover, pagesAmount, comment), ID);
            MessagingCenter.Send<TextLibraryViewModel>(this, "Change video element");
            RefreshProperties();
        });

        public BookViewModel(IRepository repository) : base(repository) { }
        public BookViewModel(int ID, string Name, byte[] cover, IRepository repository, string Comment, int PagesAmount) : base(ID, Name, cover, repository)
        {
            this.Comment = Comment;
            this.PagesAmount = PagesAmount;
        }

        public override void RefreshProperties()
        {
            OnPropertyChanged("Name");
            OnPropertyChanged("Comment");
            OnPropertyChanged("Cover");
            OnPropertyChanged("Comment");
            OnPropertyChanged("PagesAmount");

        }
    }
}