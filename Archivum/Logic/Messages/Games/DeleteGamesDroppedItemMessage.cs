
using CommunityToolkit.Mvvm.Messaging.Messages;

namespace Archivum.Logic.Messages.Games
{
    public class DeleteGamesDroppedItemMessage : ValueChangedMessage<IViewModel>
    {
        public DeleteGamesDroppedItemMessage(IViewModel value) : base(value)
        {
        }
    }
}
