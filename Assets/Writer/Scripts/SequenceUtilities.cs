using Writer.Scripts.Data;

public static class SequenceUtilities
{
    public static string GetTagValue(string key, Tag[] tags)
    {
        if (tags == null || tags.Length == 0) return null;
        foreach (var tag in tags)
        {
            if (tag.key == key) return tag.value;
        }
        return null;
    }
}