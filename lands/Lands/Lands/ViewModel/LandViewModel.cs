

namespace Lands.ViewModel
{
    using Models;
    using System;
    using System.Collections.ObjectModel;
    using System.Linq;

    public class LandViewModel :BaseViewModel
    {
        #region Atributes
        private ObservableCollection<Border> bordes;
        private ObservableCollection<Currency> currencies;
        private ObservableCollection<Language> language;
        #endregion


        #region properties
        public Land Land
        {
            get;
            set;
        }
        //para la pagina Border
        public ObservableCollection<Border> Bordes
        {
            get { return this.bordes; }
            set { this.SetValue(ref this.bordes,value); }
        }
        //para la pagina currency
        public ObservableCollection<Currency> Currencies
        {
            get { return this.currencies; }
            set { this.SetValue(ref this.currencies, value); }
        }

        public ObservableCollection<Language> Language
        {
            get { return this.language; }
            set { this.SetValue(ref this.language, value); }
        }
        #endregion

        #region Constructor
        public LandViewModel(Land land)
        {
            this.Land = land;
            this.LoadBorders();
            this.Currencies = new ObservableCollection<Currency>(this.Land.Currencies);
            this.Language = new ObservableCollection<Language>(this.Land.Languages);
        }


        #endregion


        #region methods
        private void LoadBorders()
        {
            this.Bordes = new ObservableCollection<Border>();
            foreach (var border in this.Land.Borders)
            {
                var land = MainViewModel.GetInstance().LandList.
                    Where( l => l.Alpha3Code == border).FirstOrDefault();
                if (land != null)
                {
                    this.Bordes.Add(new Border
                    {
                        Code = land.Alpha3Code,
                        Name = land.Name,
                    });
                        
                }
            }
        }
        #endregion
    }
}
