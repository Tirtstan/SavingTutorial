using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using MessagePack;
using MessagePack.Resolvers;
using UnityEngine;
using UnityEngine.InputSystem;

public class SaveLevel : MonoBehaviour
{
    [Header("Configs")]
    [SerializeField]
    private int MaxObjectsPerFrame = 100;
    private string SavePath => Path.Combine(Application.persistentDataPath, "Saves");
    private readonly MessagePackSerializerOptions options =
        MessagePackSerializerOptions.Standard.WithResolver(
            TypelessContractlessStandardResolver.Instance
        );

    private void Update()
    {
        if (Keyboard.current.sKey.wasPressedThisFrame)
            Save();
        else if (Keyboard.current.lKey.wasPressedThisFrame)
            Load();
    }

    private void Save()
    {
        if (!Directory.Exists(SavePath))
            Directory.CreateDirectory(SavePath);

        List<ISaveable> saveables = FindObjectsByType<MonoBehaviour>(
                FindObjectsInactive.Include,
                FindObjectsSortMode.None
            )
            .OfType<ISaveable>()
            .ToList();

        LevelData levelData = new(saveables);

        byte[] bytes = MessagePackSerializer.Serialize(levelData, options);
        File.WriteAllBytes(Path.Combine(SavePath, "Level.dat"), bytes);

        Debug.Log("Saved with binary!");

        WriteBinaryToJson(bytes);
    }

    private void Load()
    {
        string path = Path.Combine(SavePath, "Level.dat");
        if (File.Exists(path))
        {
            byte[] bytes = File.ReadAllBytes(path);
            LevelData levelData = MessagePackSerializer.Deserialize<LevelData>(bytes, options);

            StartCoroutine(LoadLevelDataAsync(levelData));
        }
        else
        {
            Debug.LogWarning($"Save file not found at {path}");
        }
    }

    private IEnumerator LoadLevelDataAsync(LevelData levelData)
    {
        for (int i = 0; i < levelData.Items.Count; i++)
        {
            ItemData itemData = (ItemData)levelData.Items[i];

            GameObject prefab = ItemDatabase.Instance.GetItemByID(itemData.Id).Prefab;
            ISaveable saveable = Instantiate(prefab, itemData.Position, itemData.GetRotation())
                .GetComponent<ISaveable>();
            saveable.SetData(itemData);

            if (i % MaxObjectsPerFrame == 0) // spread instantiation over multiple frames
                yield return null;
        }

        Debug.Log($"Loaded all {levelData.Items.Count} items!");
    }

    private void WriteBinaryToJson(byte[] bytes)
    {
        string json = MessagePackSerializer.ConvertToJson(bytes);
        File.WriteAllText(Path.Combine(SavePath, "Level.json"), json);
    }
}
