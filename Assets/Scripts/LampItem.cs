using UnityEngine;
using UnityEngine.Rendering.Universal;

public class LampItem : Item
{
    private Light2D light2D;
    public float Intensity
    {
        get => light2D.intensity;
        set => light2D.intensity = value;
    }
    public Color LampColor
    {
        get => light2D.color;
        set => light2D.color = value;
    }

    protected override void Awake()
    {
        base.Awake();
        light2D = GetComponentInChildren<Light2D>();
    }

    public override void RandomizeProperties()
    {
        base.RandomizeProperties();
        Intensity = Random.Range(0.1f, 10f);
        LampColor = new Color(Random.value, Random.value, Random.value);
    }

    public override ItemData GetData() =>
        new LampItemData(
            GetId(),
            gameObject.name,
            transform.position,
            transform.rotation.eulerAngles.z,
            transform.localScale,
            Color,
            Intensity,
            LampColor
        );

    public override void SetData(ItemData data)
    {
        base.SetData(data);
        if (data is LampItemData lampItemData)
        {
            Intensity = lampItemData.Intensity;
            LampColor = lampItemData.LampColor;
        }
    }
}

[MessagePack.MessagePackObject(keyAsPropertyName: true)]
public class LampItemData : ItemData
{
    public float Intensity { get; set; }
    public Color LampColor { get; set; }

    public LampItemData(
        int id,
        string name,
        Vector2 position,
        float rotationZ,
        Vector2 scale,
        Color color,
        float intensity,
        Color lampColor
    )
        : base(id, name, position, rotationZ, scale, color)
    {
        Intensity = intensity;
        LampColor = lampColor;
    }
}
