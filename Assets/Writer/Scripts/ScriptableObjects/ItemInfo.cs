using UnityEngine;
using Writer.Scripts.ScriptableObjects;

public class ItemInfo : EntityInfo
{
    public override void Initialize(Entity entity)
    {
        this.id = entity.id;
        this.niceName = entity.name;
    }
}