using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace eth2validatormonitor.Integration.ModelV2
{
    public class AttestationHistory
    {
        [JsonProperty("status")]
        public string Status { get; set; }

        [JsonProperty("data")]
        public List<AttestationData> Data { get; set; }
    }

    public class AttestationData
    {
        [JsonProperty("attesterslot")]
        public int Attesterslot { get; set; }

        [JsonProperty("committeeindex")]
        public int Committeeindex { get; set; }

        [JsonProperty("epoch")]
        public int Epoch { get; set; }

        [JsonProperty("inclusionslot")]
        public int Inclusionslot { get; set; }

        [JsonProperty("status")]
        public int Status { get; set; }

        [JsonProperty("validatorindex")]
        public int Validatorindex { get; set; }
    }
}
