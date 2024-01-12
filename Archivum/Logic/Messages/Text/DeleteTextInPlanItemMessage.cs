using CommunityToolkit.Mvvm.Messaging.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Archivum.Logic.Messages.Text
{
    public class DeleteTextInPlanItemMessage : ValueChangedMessage<IViewModel>
    {
        public DeleteTextInPlanItemMessage(IViewModel value) : base(value)
        {
        }
    }
}