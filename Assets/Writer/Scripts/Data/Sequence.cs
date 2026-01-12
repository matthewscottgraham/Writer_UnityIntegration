using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using UnityEngine.Serialization;

namespace Writer.Scripts.Data
{
    [System.Serializable]
    public struct Sequence
    {
        public string id;
        public string name;
        [JsonConverter(typeof(StringEnumConverter))]
        public InvokeType invokeType;
        public bool isSingleUse;
        public Passage[] passages;
    }
}
