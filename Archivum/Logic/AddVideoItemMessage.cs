using CommunityToolkit.Mvvm.Messaging.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Archivum.Logic
{
    public class AddVideoItemMessage : ValueChangedMessage<IViewModel>
    {
        public AddVideoItemMessage(IViewModel value) : base(value)
        {

        }
    }
}
