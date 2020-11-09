using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;

namespace TestListBoxBinding
{
    public class MainWindowVM
    {
        public Project Project { get; set; } = new Project();

        public ObservableCollection<String> TestCollection { get; set; }

        public MainWindowVM()
        {
            Project.Names = new ObservableCollection<String>
            {
                "Name1",
                "Name2",
                "Name3",
                "Name4",
                "Name5"
            };

            TestCollection = Project.Names;
        }
    }
}
