using Writer.Scripts.ScriptableObjects;

public class CharacterInfo : EntityInfo
{
    public override void Initialize(Entity entity)
    {
        this.id = entity.id;
        this.niceName = entity.name;
    }
}
