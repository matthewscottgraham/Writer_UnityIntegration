using Writer.Scripts.Data;

[System.Serializable]
public struct Scene
{
    public string Id;
    public string Name;
    public string Description;
    public Sequence[] Sequences;
}
