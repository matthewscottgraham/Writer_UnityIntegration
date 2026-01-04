using UnityEngine;

namespace Writer.Scripts.ScriptableObjects
{
    public class EntityInfo : ScriptableObject
    {
        [SerializeField] protected string id;
        [SerializeField] protected string niceName;
        [SerializeField] protected string description;

        public string Id => id;
        public string NiceName => niceName;
        public string Description => description;

        public virtual void Initialize(Entity entity)
        {
            id = entity.id;
            niceName = entity.name;
            description = entity.description;
        }
    }
}
