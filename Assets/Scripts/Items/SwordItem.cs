using UnityEngine;

public class SwordItem : Item
{
    // make sure you pass in the correct type in the inspector
    private DamageItemSO DamageItemSO => (DamageItemSO)itemSO;
    public float DamageMultiplier { get; set; } = 1f;

    public override void RandomizeProperties()
    {
        base.RandomizeProperties();
        DamageMultiplier = Random.Range(0.1f, 10f);
    }

    public void Attack()
    {
        Debug.Log($"Attacking with sword at {DamageItemSO.Damage}");
    }

    public override ItemData GetData() =>
        new SwordItemData(
            GetId(),
            gameObject.name,
            transform.position,
            transform.rotation.eulerAngles.z,
            transform.localScale,
            Color,
            DamageMultiplier
        );

    public override void SetData(ItemData data)
    {
        base.SetData(data);
        if (data is SwordItemData swordItemData)
            DamageMultiplier = swordItemData.DamageMultiplier;
    }
}

[MessagePack.MessagePackObject(keyAsPropertyName: true)]
public class SwordItemData : ItemData
{
    public float DamageMultiplier { get; set; }

    public SwordItemData(
        int id,
        string name,
        Vector2 position,
        float rotationZ,
        Vector2 scale,
        Color color,
        float damageMultiplier
    )
        : base(id, name, position, rotationZ, scale, color)
    {
        DamageMultiplier = damageMultiplier;
    }
}
