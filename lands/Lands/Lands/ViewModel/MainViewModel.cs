

namespace Lands.ViewModel
{
    public class MainViewModel
    {
        #region viewModel

        public LoginViewModel Login {
            get;
            set;
        }
        #endregion

        #region constructor
        public MainViewModel()
        {
            this.Login = new LoginViewModel();
        }
        #endregion
    }
}
