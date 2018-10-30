

namespace Lands.ViewModel
{
    using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using Models;
    using Services;
    using Xamarin.Forms;

    public class LandsViewModel:BaseViewModel
    {
        #region Services
        private ApiService apiService;
        #endregion

        #region Atributes
        private ObservableCollection<Land> lands;
        #endregion

        #region Propeties
        public ObservableCollection<Land> Lands
        {
            get { return this.lands;  }
            set { SetValue(ref this.lands, value); }
        }

       
        #endregion

        #region constructor
        public LandsViewModel()
        {
            this.apiService = new ApiService();
            this.LoadLands();
        }


        #endregion

        #region methods
        private async  void LoadLands()
        {
            var response = await this.apiService.GetList<Land>(
                "http://restcountries.eu",
                "/rest",
                "/v2/all");
            if (response.IsSuccess)
            {
                await Application.Current.MainPage.DisplayAlert(
                    "Error",
                    response.Message,
                    "Aeptar");
                return;
            }
            var list = (List<Land>)response.Result;
            this.Lands = new ObservableCollection<Land>(list);
        }
        #endregion
    }
}
