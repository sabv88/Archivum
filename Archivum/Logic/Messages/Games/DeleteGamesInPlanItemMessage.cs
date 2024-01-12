using CommunityToolkit.Mvvm.Messaging.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Archivum.Logic.Messages.Games
{
    public class DeleteGamesInPlanItemMessage : ValueChangedMessage<IViewModel>
    {
        public DeleteGamesInPlanItemMessage(IViewModel value) : base(value)
        {
        }
    }
}
