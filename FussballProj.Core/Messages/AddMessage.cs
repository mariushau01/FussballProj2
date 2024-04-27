using CommunityToolkit.Mvvm.Messaging.Messages;
using FussballProj.Lib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FussballProj.Core.Messages
{
    public class AddMessage : ValueChangedMessage<Entry>
    {
        public AddMessage(Entry value) : base(value)
        {
            
        }
    }
}
