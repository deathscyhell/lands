

namespace Lands.ViewModel
{
    using Models;
    

    public class LandViewModel
    {
        #region properties
        public Land Land
        {
            get;
            set;
        }
        #endregion

        #region Constructor
        public LandViewModel(Land land)
        {
            this.Land = land;
        } 
        #endregion
    }
}
