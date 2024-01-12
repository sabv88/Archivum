using CommunityToolkit.Mvvm.Messaging.Messages;

namespace Archivum.Logic.Messages.Text
{
    public class AddTextInProgressItemMessage : ValueChangedMessage<IViewModel>
    {
        public AddTextInProgressItemMessage(IViewModel value) : base(value)
        {

        }
    }
}
