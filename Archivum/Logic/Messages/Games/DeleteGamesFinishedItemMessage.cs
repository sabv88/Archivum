using CommunityToolkit.Mvvm.Messaging.Messages;

namespace Archivum.Logic
{
    public class DeleteGamesFinishedItemMessage : ValueChangedMessage<IViewModel>
    {
        public DeleteGamesFinishedItemMessage(IViewModel value) : base(value)
        {
        }
    }
}
