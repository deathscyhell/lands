namespace Lands.ViewModel
{
    using GalaSoft.MvvmLight.Command;
    using System;
    using System.ComponentModel;
    using System.Windows.Input;
    using Xamarin.Forms;

    public class LoginViewModel : BaseViewModel
    {
        

        #region Atributes
       // private string email;
        private string password;
        private bool isRunning;
        private bool isEnabled;

        #endregion

        #region propiedades
        public string Email
        {
            get;
            set;
        }
        public string Password
        {
            get
            {
                return this.password;
            }
            set
            {
                SetValue(ref this.password, value);
            }
        }
        public bool IsRunning
        {
            get
            {
                return this.isRunning;
            }
            set
            {
                SetValue(ref this.isRunning, value);
            }
        }
        public bool IsRemembered
        {
            get;
            set;
        }
        public bool IsEnabled
        {
            get
            {
                return this.isEnabled;
            }
            set
            {
                SetValue(ref this.isEnabled, value);
            }
        }
        #endregion

        #region Constructor
        public LoginViewModel()
        {
            this.IsRemembered = true;
         this.IsEnabled = true ;
        }
        #endregion

        #region Commandos
        public ICommand LoginCommand
        {
            get
            {
                return new RelayCommand(Login);
            }

        }



        private async void Login()
        {
            if (string.IsNullOrEmpty(this.Email))
            {
                
                await Application.Current.MainPage.DisplayAlert(
                    "Error ",
                    "You must enter an email ",
                    "Accept ");
                return;
            }
            
            if (string.IsNullOrEmpty(this.Password))
            {
                
                await Application.Current.MainPage.DisplayAlert(
                    "Error ",
                    "You must enter an password ",
                    "Accept ");
                
                return;
            }
            this.IsRunning = true;
            this.IsEnabled = false;
            if (this.Email != "w" || this.Password != "123")
            {
                this.IsRunning = false;
                this.IsEnabled = true;
                await Application.Current.MainPage.DisplayAlert(
                   "ok ",
                   "email or password incorrent ",
                   "Accept ");
                this.Password = string.Empty;
                return;
            }
            this.IsRunning = false;
            this.IsEnabled = true;
            await Application.Current.MainPage.DisplayAlert(
                 "ok ",
                 "fuckyea ",
                 "Accept ");
            return;
        }

        #endregion
    }
}
