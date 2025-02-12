using System.Linq;
using UnityEngine;

public class ItemDatabase : MonoBehaviour
{
    public static ItemDatabase Instance { get; private set; }

    [Header("Components")]
    [SerializeField]
    private ItemDatabaseSO itemDatabaseSO;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
            return;
        }
    }

    public ItemSO GetItemByID(int id) => itemDatabaseSO.items.FirstOrDefault(i => i.Id == id);

    public ItemSO GetRandomItem() =>
        itemDatabaseSO.items[Random.Range(0, itemDatabaseSO.items.Length)];
}
