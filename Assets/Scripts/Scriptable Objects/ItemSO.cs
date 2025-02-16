using UnityEngine;

[CreateAssetMenu(fileName = "Item", menuName = "Scriptable Objects/Item")]
public class ItemSO : ScriptableObject
{
    [Header("Base Properties")]
    public int Id;
    public string Name;
    public GameObject Prefab;
}
