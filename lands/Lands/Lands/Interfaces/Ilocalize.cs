

namespace Lands.Interfaces
{
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.Text;

    public interface Ilocalize
    {
        CultureInfo GetCurrentCultureInfo();

        void SetLocale(CultureInfo ci);

    }
}
