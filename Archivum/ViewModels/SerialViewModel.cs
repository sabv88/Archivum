﻿using Archivum.Logic;
using Archivum.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Xml.Linq;

namespace Archivum.ViewModels
{
   public class SerialViewModel : VideoLibraryViewModel
    {
        string comment;
        int seriesCount;
        int seriesLength;

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

        public int SeriesCount
        {
            get => seriesCount;
            set
            {
                if (seriesCount != value)
                {
                    seriesCount = value;
                    OnPropertyChanged(nameof(SeriesCount));
                }
            }
        }
        public int SeriesLength
        {
            get => seriesLength;
            set
            {
                if (seriesLength != value)
                {
                    seriesLength = value;
                    OnPropertyChanged(nameof(SeriesLength));

                }
            }
        }

        public new ICommand SaveItem => new Command(async () =>
        {
            Repository repository = new Repository();
            _ = repository.SaveItemAsync(new Serial(), ID);
            MessagingCenter.Send<VideoLibraryViewModel>(this, "Change video element");
        });

        public SerialViewModel(int ID, string Name, byte[] cover, IRepository repository, string Comment, int SeriesCount, int SeriesLength) : base(ID, Name, cover, repository)
        {
            this.Comment = Comment;
            this.SeriesCount = SeriesCount;
            this.SeriesLength = SeriesLength;
        }
        public SerialViewModel(IRepository repository):base(repository) { this.repository = repository; }


        public override void RefreshProperties()
        {
            OnPropertyChanged("Name");
            OnPropertyChanged("Comment");
            OnPropertyChanged("Type");
            OnPropertyChanged("Cover");
            OnPropertyChanged("SeriesLength");
            OnPropertyChanged("SeriesCount");

        }
    }
}
 