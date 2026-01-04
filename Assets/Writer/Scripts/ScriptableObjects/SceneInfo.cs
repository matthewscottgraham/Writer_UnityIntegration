using Writer.Scripts.Data;

namespace Writer.Scripts.ScriptableObjects
{
    public class SceneInfo : EntityInfo
    {
        private Sequence[] _sequences;

        public Sequence[] Sequences => _sequences;

        public void Initialize(Scene scene)
        {
            id = scene.Id;
            niceName = scene.Name;
            description = scene.Description;
            _sequences = scene.Sequences;
        }
    }
}
