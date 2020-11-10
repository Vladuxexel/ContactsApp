using ContactsApp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContactsAppUI.Commands
{
    public class ClosingWindowSaveCommand : TypedCommand<MainWindowVM>
    {
        protected override void Execute(MainWindowVM parameter)
        {
            ProjectManager.SaveToFile(parameter.Project, ProjectManager.PathFile());
        }
    }
}
