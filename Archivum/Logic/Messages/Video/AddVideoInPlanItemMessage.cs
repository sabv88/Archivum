using CommunityToolkit.Mvvm.Messaging.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Archivum.Logic.Messages.Video
{
    public class AddVideoInPlanItemMessage : ValueChangedMessage<IViewModel>
    {
        public AddVideoInPlanItemMessage(IViewModel value) : base(value)
        {

        }
    }
}