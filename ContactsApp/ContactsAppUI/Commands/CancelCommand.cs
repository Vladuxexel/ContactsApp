using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContactsAppUI.Commands
{
    public class CancelCommand : TypedCommand<ContactManagerWindowVM>
    {
        protected override void Execute(ContactManagerWindowVM parameter)
        {
            parameter.ContactManagerWindow.Close();
        }
    }
}
