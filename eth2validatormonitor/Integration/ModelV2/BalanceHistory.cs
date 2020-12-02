using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace eth2validatormonitor.Integration.ModelV2
{
    public class BalanceHistory
    {
        [JsonProperty("status")]
        public string Status { get; set; }

        [JsonProperty("data")]
        public List<BalanceHistoryData> Data { get; set; }
    }

    public class BalanceHistoryData
    {
        [JsonProperty("balance")]
        public long Balance { get; set; }

        [JsonProperty("effectivebalance")]
        public long Effectivebalance { get; set; }

        [JsonProperty("epoch")]
        public int Epoch { get; set; }

        [JsonProperty("validatorindex")]
        public int Validatorindex { get; set; }
    }
}
