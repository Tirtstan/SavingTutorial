using UnityEngine;

[CreateAssetMenu(fileName = "Item SO", menuName = "Scriptable Objects/ItemSO")]
public class ItemSO : ScriptableObject
{
    [Header("Base Properties")]
    public int Id;
    public string Name;
    public GameObject Prefab;
}
