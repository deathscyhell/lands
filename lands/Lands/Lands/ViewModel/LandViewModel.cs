

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
        #endregion


        #region properties
        public Land Land
        {
            get;
            set;
        }
        public ObservableCollection<Border> Bordes
        {
            get { return this.bordes; }
            set { this.SetValue(ref this.bordes,value); }
        }
        #endregion

        #region Constructor
        public LandViewModel(Land land)
        {
            this.Land = land;
            this.LoadBorders();
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
