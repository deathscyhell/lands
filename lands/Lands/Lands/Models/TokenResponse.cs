﻿

namespace Lands.Models
{
    using Newtonsoft.Json;

    public class TokenResponse
    {

            [JsonProperty(PropertyName = "access_token")]
            public string AccessToken { get; set; }

            [JsonProperty(PropertyName = "token_type")]
            public string TokenType { get; set; }

            [JsonProperty(PropertyName = "expires_in")]
            public int ExpiresIn { get; set; }

            [JsonProperty(PropertyName = "userName")]
            public string UserName { get; set; }

            [JsonProperty(PropertyName = "issued")]
            public string Issued { get; set; }

            [JsonProperty(PropertyName = "expires")]
            public string Expires { get; set; }

            [JsonProperty(PropertyName = "error_descriptio")]
            public string ErrorDescription { get; set; }

            

        


    }
}
