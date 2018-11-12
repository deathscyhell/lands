namespace Lands.ViewModel
{
    using GalaSoft.MvvmLight.Command;
    using Lands.View;
    using System;
    using System.ComponentModel;
    using System.Windows.Input;
    using Xamarin.Forms;
    using Services;
    

    public class LoginViewModel : BaseViewModel
    {
        #region Servicies
        private ApiService apiService;
        #endregion

        #region Atributes
        private string email;
        private string password;
        private bool isRunning;
        private bool isEnabled;

        #endregion

        #region property

        public string Email
        {
            get
            {
                return this.email;
            }
            set
            {
                SetValue(ref this.email, value);
            }
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

           this.apiService = new ApiService();

            this.Email = "w@gmail.com";
            this.Password = "123456";
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

            //
            var connetion = await this.apiService.CheckConnection();

            if (!connetion.IsSuccess)
            {
                this.IsRunning = false;
                this.IsEnabled = true;

                await Application.Current.MainPage.DisplayAlert(
                   "Error ",
                   connetion.Message,
                   "Accept ");

                return;
            }

            var token = await this.apiService.GetToken(
               "http://192.168.16.2:7010/",
               this.Email,
               this.Password);


            if (token == null)
            {

                this.IsRunning = false;
                this.IsEnabled = true;
                await Application.Current.MainPage.DisplayAlert(
                   "Error ",
                   "something was wrong, please try later",
                   "Accept ");

                return;
            }

            if (string.IsNullOrEmpty(token.AccessToken))
            {
                this.IsRunning = false;
                this.IsEnabled = true;
                await Application.Current.MainPage.DisplayAlert(
                   "Error ",
                   token.ErrorDescription,
                   "Accept ");
                this.password = string.Empty;
                return;
            }
        
           
            var mainViewModel =  MainViewModel.GetInstance();
            mainViewModel.Token = token;
             mainViewModel.Lands = new LandsViewModel();
            await Application.Current.MainPage.Navigation.PushAsync(new LandsPage());

            //
            this.IsRunning = false;
            this.IsEnabled = true;


            this.Email = string.Empty;
            this.Password = string.Empty;

         
        }

        #endregion
    }
}
