using UnityEngine;
using UnityEngine.InputSystem;

public class ObjectCreator : MonoBehaviour
{
    [Header("Configs")]
    [SerializeField]
    private int objectCount = 50;

    private void Update()
    {
        if (Keyboard.current.cKey.wasPressedThisFrame)
            CreateItems();
    }

    private void CreateItems()
    {
        for (int i = 0; i < objectCount; i++)
        {
            GameObject prefab = ItemDatabase.Instance.GetRandomItem().Prefab;

            Item item = Instantiate(prefab, Random.insideUnitCircle * 10f, GetRandomZ())
                .GetComponent<Item>();
            item.RandomizeProperties();
        }
    }

    private Quaternion GetRandomZ() => Quaternion.Euler(0, 0, Random.Range(0, 360));
}
