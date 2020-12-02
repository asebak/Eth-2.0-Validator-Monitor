using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace eth2validatormonitor.Integration.ModelV2
{
   public class ValidatorObj
    {
        [JsonProperty("status")]
        public string Status { get; set; }

        [JsonProperty("data")]
        public Data Data { get; set; }
    }

   public class Data
   {
       [JsonProperty("activationeligibilityepoch")]
       public int Activationeligibilityepoch { get; set; }

       [JsonProperty("activationepoch")]
       public int Activationepoch { get; set; }

       [JsonProperty("balance")]
       public long Balance { get; set; }

       [JsonProperty("effectivebalance")]
       public long Effectivebalance { get; set; }

       [JsonProperty("exitepoch")]
       public string Exitepoch { get; set; }

       [JsonProperty("lastattestationslot")]
       public int Lastattestationslot { get; set; }

       [JsonProperty("name")]
       public string Name { get; set; }

       [JsonProperty("pubkey")]
       public string Pubkey { get; set; }

       [JsonProperty("slashed")]
       public bool Slashed { get; set; }

       [JsonProperty("validatorindex")]
       public int Validatorindex { get; set; }

       [JsonProperty("withdrawableepoch")]
       public string Withdrawableepoch { get; set; }

       [JsonProperty("withdrawalcredentials")]
       public string Withdrawalcredentials { get; set; }
   }
}
