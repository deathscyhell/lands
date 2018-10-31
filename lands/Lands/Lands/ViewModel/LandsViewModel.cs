

namespace Lands.ViewModel
{
    using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.Linq;
    using System.Windows.Input;
    using GalaSoft.MvvmLight.Command;
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
        private bool isRefreshing;
        private string filter;
        private List<Land> landList;
        #endregion

        #region Propeties
        public ObservableCollection<Land> Lands
        {
            get { return this.lands;  }
            set { SetValue(ref this.lands, value); }
        }

        public bool IsRefreshing {
            get { return this.isRefreshing; }
            set { SetValue(ref this.isRefreshing, value); }
        }

        public string Filter
        {
            get { return this.filter; }
            set { SetValue(ref this.filter, value);
                this.Search();
            }
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
            this.IsRefreshing = true;
            var connetion = await this.apiService.CheckConnection();
            if (!connetion.IsSuccess)
            {
                this.IsRefreshing = false;
                await Application.Current.MainPage.DisplayAlert(
                    "Error",
                    connetion.Message,
                    "Aeptar");
                await Application.Current.MainPage.Navigation.PopAsync();
                return;
            }

            var response = await this.apiService.GetList<Land>(
                "http://restcountries.eu",
                "/rest",
                "/v2/all");
            //if (response.IsSuccess)
            //{
            //    await Application.Current.MainPage.DisplayAlert(
            //        "todo bien",
            //        response.Message,
            //        "Aeptar");
            //    return;
            //}
           this.landList = (List<Land>)response.Result;
            this.Lands = new ObservableCollection<Land>(this.landList);
            this.IsRefreshing = false;
        }

        private void Search()
        {
            if (string.IsNullOrEmpty(this.Filter))
            {
                this.Lands = new ObservableCollection<Land>(
                    this.landList);
            }
            else
            {
                //llamamos la libreria using linq para utilizar el Where. lo que hacemos es filtrar
                //el resultadoprimero por nombre convirtiendo los dos en minuscula y la segunda busqueda 
                //por medio de letras es decir al escribir una letra que aparezca resutlado y al eliminarla que aparezca otros.
                this.Lands = new ObservableCollection<Land>(
                this.landList.Where(l => l.Name.ToLower().Contains(this.Filter.ToLower()) ||
                l.Capital.ToLower().Contains(this.Filter.ToLower()) ));
            }
        }
        #endregion

        #region Command
        public ICommand RefreshCommand {
            get
            {
                //el relay es por medio de unp lugin
                return new RelayCommand(LoadLands);
            } 
        }

        public ICommand SearchCommand
        {
            get
            {
                return new RelayCommand(Search);
            }
        }

       
        #endregion
    }
}
