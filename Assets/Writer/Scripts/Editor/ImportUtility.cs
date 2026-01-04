using System.IO;
using Newtonsoft.Json;
using UnityEditor;
using UnityEngine;
using Writer.Scripts.Data;
using Writer.Scripts.ScriptableObjects;

namespace Writer.Scripts.Editor
{
    public class ImportUtility : MonoBehaviour
    {
        private static readonly string CharactersFileName = "characters.json";
        private static readonly string ItemsFileName = "items.json";

        [MenuItem("Writer/Import")]
        public static void Import()
        {
            var files = Directory.GetFiles(
                Application.streamingAssetsPath + "/Writer/", "*.json", SearchOption.AllDirectories);
            foreach (var file in files)
            {
                var fileInfo = new FileInfo(file);
                switch (fileInfo.Name)
                {
                    case var name when name.Equals(CharactersFileName):
                        ImportEntities<CharacterInfo>(ReadJsonFile<Entity[]>(file), "Characters");
                        break;
                    case var name when name.Equals(ItemsFileName):
                        ImportEntities<ItemInfo>(ReadJsonFile<Entity[]>(file), "Items");
                        break;
                    case var name when name.StartsWith("scene_") && name.EndsWith(".json"):
                        ImportScene(ReadJsonFile<Scene>(file));
                        break;
                    default:
                        Debug.LogWarning("Unknown file: " + fileInfo.Name);
                        break;
                }
            }
        }

        private static T ReadJsonFile<T>(string filePath)
        {
            var jsonContent = File.ReadAllText(filePath);
            return string.IsNullOrEmpty(jsonContent)
                ? default(T)
                : JsonConvert.DeserializeObject<T>(jsonContent);
        }

        private static void ImportEntities<T>(Entity[] entities, string subFolder) where T : EntityInfo
        {
            if (entities == null || entities.Length == 0) return;

            foreach (var entity in entities)
            {
                var characterInfo = ScriptableObject.CreateInstance<T>();
                characterInfo.Initialize(entity);

                CreateDirectory(subFolder);
                DeleteAsset(subFolder, characterInfo.Id);
                AssetDatabase.CreateAsset(characterInfo, $"Assets/Resources/{subFolder}/{entity.id}.asset");
            }
        }

        private static void CreateDirectory(string subFolder)
        {
            if (!AssetDatabase.IsValidFolder("Assets/Resources"))
                AssetDatabase.CreateFolder("Assets", "Resources");
            if (!AssetDatabase.IsValidFolder($"Assets/Resources/{subFolder}"))
                AssetDatabase.CreateFolder("Assets/Resources", subFolder);
        }

        private static void DeleteAsset(string subFolder, string entityID)
        {
            if (AssetDatabase.LoadAssetAtPath<EntityInfo>($"Assets/Resources/{subFolder}/{entityID}.asset") != null)
            {
                AssetDatabase.DeleteAsset($"Assets/Resources/{subFolder}/{entityID}.asset");
            }
        }

        private static void ImportScene(Scene? scene)
        {
            if (scene == null) return;
            var sceneInfo = ScriptableObject.CreateInstance<SceneInfo>();
            sceneInfo.Initialize(scene.Value);

            CreateDirectory("Scenes");
            DeleteAsset("Scenes", sceneInfo.Id);
            AssetDatabase.CreateAsset(sceneInfo, $"Assets/Resources/Scenes/{sceneInfo.Id}.asset");

            foreach (var sequence in scene.Value.Sequences)
            {
                ImportSequence(sequence);
            }
        }

        private static void ImportSequence(Sequence sequence)
        {
            var sequenceInfo = ScriptableObject.CreateInstance<SequenceInfo>();
            sequenceInfo.Initialize(sequence);
        
            CreateDirectory("Sequences");
            DeleteAsset("Sequences", sequence.Id);
            AssetDatabase.CreateAsset(sequenceInfo, $"Assets/Resources/Sequences/{sequence.Id}.asset");
        }
    }
}
