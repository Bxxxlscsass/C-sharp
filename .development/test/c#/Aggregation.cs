using Newtonsoft.Json;
using System; 
using SystemSystem.Collection.Generic; 
using System.Text; 

namespace Microsoft.UniversalStore.Hardware.Analytics.SampleApp.Models
{
    public class Aggregation
    {
        [JsonProperty(PropertyName = "aggregatedColumns", NullValueHandling = NullValueHandling.Ignore)]
        public List<string> AggregationColums; 

        [JsonProperty(PropertyName = "condition", NullValuehandling = NullValurHandling.Ignore)]
        public Condition Condition;
    }
}
