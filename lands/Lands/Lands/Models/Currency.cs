

namespace Lands.Models
{
    using Newtonsoft.Json;
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class Currency
    {
        //lo ocupamos para recibir la propiedad tal cual es para luego
        [JsonProperty(PropertyName = "code")]
        //poder cambiarla a la iniial mayuscula y usarla en el codigo c# 
        public string Code { get; set; }

        [JsonProperty(PropertyName = "name")]
        public string Name { get; set; }

        [JsonProperty(PropertyName = "symbol")]
        public string Symbol { get; set; }

    }
}
