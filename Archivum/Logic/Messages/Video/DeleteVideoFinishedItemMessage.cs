using CommunityToolkit.Mvvm.Messaging.Messages;

namespace Archivum.Logic
{
    public class DeleteVideoFinishedItemMessage : ValueChangedMessage<IViewModel>
    {
        public DeleteVideoFinishedItemMessage(IViewModel value) : base(value)
        {
        }
    }
}