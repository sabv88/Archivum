﻿using CommunityToolkit.Mvvm.Messaging.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Archivum.Logic.Messages.Games
{
    public class AddGamesFinishedItemMessage : ValueChangedMessage<IViewModel>
    {
        public AddGamesFinishedItemMessage(IViewModel value) : base(value)
        {

        }
    }
}
