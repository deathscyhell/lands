

namespace Lands.Infrastructure
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using Lands.Infrastructure;
    using ViewModel;

    //instancia el locator para encontrar la main viewmodel
    public class InstanceLocator
    {
        #region Propiedades

        public MainViewModel  Main
        {
            get;
            set;
        }
        #endregion

        #region Constructor
        public InstanceLocator()
        {
            this.Main = new MainViewModel();
        }
        #endregion

        #region MyRegion

        #endregion
    }



}
