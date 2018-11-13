

namespace Lands.Helpers
{
    using Lands.Interfaces;
    using Lands.Resourcea;
    using System;
    using System.Collections.Generic;
    using System.Text;
    using Xamarin.Forms;

    public class Languages
    {
        static Languages()
        {
            var ci = DependencyService.Get<Ilocalize>().GetCurrentCultureInfo();
            Resource.Culture = ci;
            DependencyService.Get<Ilocalize>().SetLocale(ci);
        }

        public static string Accept
        {
            get { return Resource.Accept; }
        }
        public static string EmailValidation
        {
            get { return Resource.EmailValidation; }
        }
        public static string Error
        {
            get { return Resource.Error; }
        }

        public static string Remenberme
        {
            get { return Resource.Remenberme; }
        }

        public static string EmailPlaceholder
        {
            get { return Resource.EmailPlaceholder; }
        }
    }
}
