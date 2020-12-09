namespace ContactsAppUI
{
    /// <summary>
    /// Вью-модель окна "About".
    /// </summary>
    public class AboutWindowVM
    {
        /// <summary>
        /// Команда перехода на почту.
        /// </summary>
        private RelayCommand _goToMailCommand;

        /// <summary>
        /// Команда перехода в GitHub.
        /// </summary>
        private RelayCommand _goToGitCommand;

        /// <summary>
        /// Свойство команды перехода на почту.
        /// </summary>
        public RelayCommand GoToMailCommand
        {
            get
            {
                return _goToMailCommand ??
                    (_goToMailCommand = new RelayCommand(obj =>
                    {
                        System.Diagnostics.Process.Start("mailto:vladuxexel@gmail.com");
                    }));
            }
        }

        /// <summary>
        /// Свойство команды перехода на GitHub.
        /// </summary>
        public RelayCommand GoToGitCommand
        {
            get
            {
                return _goToGitCommand ??
                   (_goToGitCommand = new RelayCommand(obj =>
                   {
                       System.Diagnostics.Process.Start("https://github.com/Vladuxexel/ContactsApp");
                   }));
            }
        }
    }
}
