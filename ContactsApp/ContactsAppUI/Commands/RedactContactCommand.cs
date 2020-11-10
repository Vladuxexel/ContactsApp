using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContactsAppUI.Commands
{
    public class RedactContactCommand : TypedCommand<MainWindowVM>
    {
        protected override void Execute(MainWindowVM parameter)
        {
            ContactManagerWindow _contactManagerWindow = new ContactManagerWindow(parameter.Project, 
                                                                                  parameter.SelectedContact, true);
            _contactManagerWindow.ShowDialog();
        }
    }
}
