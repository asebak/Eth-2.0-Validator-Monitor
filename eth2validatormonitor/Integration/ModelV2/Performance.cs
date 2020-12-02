using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace eth2validatormonitor.Integration.ModelV2
{
    public class Performance
    {
        [JsonProperty("status")]
        public string Status { get; set; }

        [JsonProperty("data")]
        public PerformanceData Data { get; set; }
    }

    public class PerformanceData
    {
        [JsonProperty("balance")]
        public long Balance { get; set; }

        [JsonProperty("performance1d")]
        public int Performance1d { get; set; }

        [JsonProperty("performance31d")]
        public int Performance31d { get; set; }

        [JsonProperty("performance365d")]
        public int Performance365d { get; set; }

        [JsonProperty("performance7d")]
        public int Performance7d { get; set; }

        [JsonProperty("validatorindex")]
        public int Validatorindex { get; set; }
    }
}
