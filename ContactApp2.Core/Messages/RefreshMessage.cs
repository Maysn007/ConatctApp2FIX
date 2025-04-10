using CommunityToolkit.Mvvm.Messaging.Messages;
using ContactApp2.Data.Models;

namespace ContactApp2.Core.Messages;

public class RefreshMessage : ValueChangedMessage<string>
{
    public RefreshMessage(string value) : base(value)
    {
    }
}