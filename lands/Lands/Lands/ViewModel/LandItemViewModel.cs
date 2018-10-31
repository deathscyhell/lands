

namespace Lands.ViewModel
{
   
    using System.Windows.Input;
    using GalaSoft.MvvmLight.Command;
    using View;
    using Models;
    using Xamarin.Forms;

    public class LandItemViewModel: Land
    {
        #region Command
        public ICommand SelectLandCommand
        {
            get
            {
                return new RelayCommand(Selectland);
            }
            
        }

        private async void Selectland()
        {
            MainViewModel.GetInstance().Land = new LandViewModel(this);
            await Application.Current.MainPage.Navigation.PushAsync(new LandTabbedPage());
        }
        #endregion
    }
}
