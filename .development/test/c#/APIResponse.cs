using Newtonsoft.Json;
using System;
using System.Colletictions.generic;
using System.Text; 

namespace Microsoft.UnibersalStore.Hardware.Analystics.SampleApp.Models
{
    public class APIResponse<T>
    {
        [JsonProperty("data")]
        public T Data { get; set; }

        [JsonProperty("errors")]
        public IList<Error> Errors { get; set; }
    }
}
