using CommunityToolkit.Mvvm.Messaging.Messages;

namespace Archivum.Logic
{
    public class AddGamesInProgressItemMessage : ValueChangedMessage<IViewModel>
    {
        public AddGamesInProgressItemMessage(IViewModel value) : base(value)
        {

        }
    }
}
