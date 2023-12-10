using CommunityToolkit.Mvvm.Messaging.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Archivum.Logic
{
    public class AddTextItemMessage : ValueChangedMessage<IViewModel>
    {
        public AddTextItemMessage(IViewModel value) : base(value)
        {

        }
    }
}
