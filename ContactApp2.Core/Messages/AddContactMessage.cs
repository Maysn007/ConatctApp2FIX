using CommunityToolkit.Mvvm.Messaging.Messages;
using ContactApp2.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContactApp2.Core.Messages;

public class AddContactMessage : ValueChangedMessage<Contact>
{
    public AddContactMessage(Contact c) : base(c)
    {
    }
}
