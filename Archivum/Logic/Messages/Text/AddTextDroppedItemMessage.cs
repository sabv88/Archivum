using CommunityToolkit.Mvvm.Messaging.Messages;

namespace Archivum.Logic.Messages.Text
{
    public class AddTextDroppedItemMessage : ValueChangedMessage<IViewModel>
    {
        public AddTextDroppedItemMessage(IViewModel value) : base(value)
        {

        }
    }
}
