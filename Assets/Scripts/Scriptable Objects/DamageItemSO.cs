using UnityEngine;

[CreateAssetMenu(fileName = "Damage Item", menuName = "Scriptable Objects/Damage Item")]
public class DamageItemSO : ItemSO
{
    [Header("Damage Properties")]
    public int Damage;
}
