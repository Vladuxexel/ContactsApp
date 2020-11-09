using System;
using System.Collections.ObjectModel;

namespace TestListBoxBinding
{
    public class Project
    {
        public ObservableCollection<String> Names { get; set; } = new ObservableCollection<String>();
    }
}
