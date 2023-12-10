using CommunityToolkit.Mvvm.Messaging.Messages;

namespace Archivum.Logic
{
    public class DeleteGamesItemMessage : ValueChangedMessage<IViewModel>
    {
        public DeleteGamesItemMessage(IViewModel value) : base(value)
        {
        }
    }
}
