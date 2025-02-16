using UnityEngine;

public class Item : MonoBehaviour, ISaveable
{
    [Header("Components")]
    [SerializeField]
    protected ItemSO itemSO;
    private SpriteRenderer spriteRenderer;
    public Color Color
    {
        get => spriteRenderer.color;
        set => spriteRenderer.color = value;
    }

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
            transform.localScale,
            Color
        );

    public virtual void SetData(ItemData data)
    {
        gameObject.name = data.Name;
        transform.rotation = Quaternion.Euler(0, 0, data.RotationZ);
        transform.localScale = data.Scale;
        Color = data.Color;
    }
}

[MessagePack.MessagePackObject(keyAsPropertyName: true)]
public class ItemData
{
    public int Id { get; set; }
    public string Name { get; set; }
    public Vector2 Position { get; set; }
    public float RotationZ { get; set; }
    public Vector2 Scale { get; set; }
    public Color Color { get; set; }

    public ItemData(
        int id,
        string name,
        Vector2 position,
        float rotationZ,
        Vector2 scale,
        Color color
    )
    {
        Id = id;
        Name = name;
        Position = position;
        RotationZ = rotationZ;
        Scale = scale;
        Color = color;
    }

    public Quaternion GetRotation() => Quaternion.Euler(0, 0, RotationZ);
}
