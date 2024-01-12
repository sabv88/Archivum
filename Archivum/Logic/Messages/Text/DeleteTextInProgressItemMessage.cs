using CommunityToolkit.Mvvm.Messaging.Messages;

namespace Archivum.Logic
{
    public class DeleteTextInProgressItemMessage : ValueChangedMessage<IViewModel>
    {
        public DeleteTextInProgressItemMessage(IViewModel value) : base(value)
        {
        }
    }  
}
