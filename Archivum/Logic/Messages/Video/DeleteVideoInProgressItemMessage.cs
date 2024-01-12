
using CommunityToolkit.Mvvm.Messaging.Messages;

namespace Archivum.Logic.Messages.Video
{
    public class DeleteVideoInProgressItemMessage : ValueChangedMessage<IViewModel>
    {
        public DeleteVideoInProgressItemMessage(IViewModel value) : base(value)
        {
        }
    }
}
