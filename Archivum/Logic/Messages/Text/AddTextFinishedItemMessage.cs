using CommunityToolkit.Mvvm.Messaging.Messages;

namespace Archivum.Logic
{
    public class AddTextFinishedItemMessage : ValueChangedMessage<IViewModel>
    {
        public AddTextFinishedItemMessage(IViewModel value) : base(value)
        {

        }
    }
}
