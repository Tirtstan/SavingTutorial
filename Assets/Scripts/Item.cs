using UnityEngine;

public class Item : MonoBehaviour
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
}
