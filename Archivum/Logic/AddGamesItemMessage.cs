using CommunityToolkit.Mvvm.Messaging.Messages;

namespace Archivum.Logic
{
    public class AddGamesItemMessage : ValueChangedMessage<IViewModel>
    {
        public AddGamesItemMessage(IViewModel value) : base(value)
        {

        }
    }
}
