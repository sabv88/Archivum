using CommunityToolkit.Mvvm.Messaging.Messages;

namespace Archivum.Logic
{
    public class DeleteTextItemMessage : ValueChangedMessage<IViewModel>
    {
        public DeleteTextItemMessage(IViewModel value) : base(value)
        {
        }
    }  
}
