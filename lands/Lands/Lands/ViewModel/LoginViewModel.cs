namespace Lands.ViewModel
{
    using System.Windows.Input;

    public class LoginViewModel
    {
        #region propiedades
        public string Email
        {
            get;
            set;
        }
        public string Password
        {
            get;
            set;
        }
        public bool IsRunning
        {
            get;
            set;
        }
        public bool IsRemembered
        {
            get;
            set;
        }
        #endregion

        #region Constructor
        public LoginViewModel()
        {
            this.IsRemembered = true;
        }
        #endregion

        #region Commandos
        public ICommand LoginCommand
        {
            get;
            set;
        }

        #endregion
    }
}
