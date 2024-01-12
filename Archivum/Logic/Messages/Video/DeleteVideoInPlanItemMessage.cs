using CommunityToolkit.Mvvm.Messaging.Messages;

namespace Archivum.Logic.Messages.Video
{
    public class DeleteVideoInPlanItemMessage : ValueChangedMessage<IViewModel>
    {
        public DeleteVideoInPlanItemMessage(IViewModel value) : base(value)
        {
        }
    }
}
