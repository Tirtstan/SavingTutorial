using UnityEngine;

public class Item : MonoBehaviour, ISaveable
{
    [Header("Components")]
    [SerializeField]
    private ItemSO itemSO;
    private SpriteRenderer spriteRenderer;

    protected virtual void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    public virtual void RandomizeProperties()
    {
        spriteRenderer.color = new Color(Random.value, Random.value, Random.value);
        transform.localScale = new Vector2(Random.Range(0.5f, 2f), Random.Range(0.5f, 2f));
        gameObject.name = $"{itemSO.Name}{Random.Range(0, 1000)}";
    }

    public int GetId() => itemSO.Id;

    public virtual ItemData GetData() =>
        new(
            GetId(),
            gameObject.name,
            transform.position,
            transform.rotation.eulerAngles.z,
            transform.localScale
        );

    public virtual void SetData(ItemData itemData)
    {
        gameObject.name = itemData.Name;
        transform.rotation = Quaternion.Euler(0, 0, itemData.RotationZ);
        transform.localScale = itemData.Scale;
    }
}

public class ItemData
{
    public int Id { get; set; }
    public string Name { get; set; }
    public Vector2 Position { get; set; }
    public float RotationZ { get; set; }
    public Vector2 Scale { get; set; }

    public ItemData(int id, string name, Vector2 position, float rotationZ, Vector2 scale)
    {
        Id = id;
        Name = name;
        Position = position;
        RotationZ = rotationZ;
        Scale = scale;
    }
}
