using CommunityToolkit.Mvvm.Messaging.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Archivum.Logic.Messages.Video
{
    public class DeleteVideoDroppedItemMessage : ValueChangedMessage<IViewModel>
    {
        public DeleteVideoDroppedItemMessage(IViewModel value) : base(value)
        {
        }
    }
}
