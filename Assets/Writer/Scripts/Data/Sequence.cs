namespace Writer.Scripts.Data
{
    [System.Serializable]
    public struct Sequence
    {
        public string Id;
        public string Name;
        public InvokeType invokeOn;
        public bool isSingleUse;
        public Passage[] passages;
    }
}
