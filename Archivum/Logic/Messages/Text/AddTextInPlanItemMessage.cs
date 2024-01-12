using CommunityToolkit.Mvvm.Messaging.Messages;

namespace Archivum.Logic.Messages.Text
{
    public class AddTextInPlanItemMessage : ValueChangedMessage<IViewModel>
    {
        public AddTextInPlanItemMessage(IViewModel value) : base(value)
        {

        }
    }
}
