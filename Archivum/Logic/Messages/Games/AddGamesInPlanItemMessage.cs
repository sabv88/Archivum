using CommunityToolkit.Mvvm.Messaging.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Archivum.Logic.Messages.Games
{
    public class AddGamesInPlanItemMessage : ValueChangedMessage<IViewModel>
    {
        public AddGamesInPlanItemMessage(IViewModel value) : base(value)
        {

        }
    }
}

