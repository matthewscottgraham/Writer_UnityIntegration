using System.Runtime.Serialization;

namespace Writer.Scripts.Data
{
    [System.Serializable]
    public enum InvokeType
    {
        [EnumMember(Value = "sceneStart")]
        SceneStart,
        [EnumMember(Value = "interaction")]
        Interaction,
        [EnumMember(Value = "scripted")]
        Scripted
    }
}
