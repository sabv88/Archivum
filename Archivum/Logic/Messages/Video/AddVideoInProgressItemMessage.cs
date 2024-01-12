using CommunityToolkit.Mvvm.Messaging.Messages;

namespace Archivum.Logic.Messages.Video
{
    public class AddVideoInProgressItemMessage : ValueChangedMessage<IViewModel>
    {
        public AddVideoInProgressItemMessage(IViewModel value) : base(value)
        {

        }
    }
}