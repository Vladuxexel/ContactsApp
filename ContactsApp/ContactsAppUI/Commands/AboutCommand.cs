using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContactsAppUI.Commands
{
    public class AboutCommand : TypedCommand<MainWindowVM>
    {
        protected override void Execute(MainWindowVM parameter)
        {
            AboutWindow _aboutWindow = new AboutWindow();

            _aboutWindow.ShowDialog();
        }
    }
}
