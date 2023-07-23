using Archivum.Logic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Archivum.ViewModels
{
    class SerialViewModel : VideoLibraryViewModel
    {
        public Serial serial = new VideoMaterial() as Serial;

        public int SeriesCount
        {
            get => serial.SeriesCount;
            set
            {
                if (serial.SeriesCount != value)
                {
                    serial.SeriesCount = value;
                    OnPropertyChanged();
                }
            }
        }
    }
}
 