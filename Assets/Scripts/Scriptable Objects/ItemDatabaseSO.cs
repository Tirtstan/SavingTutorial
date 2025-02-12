using System;
using UnityEngine;

[CreateAssetMenu(fileName = "Item Database", menuName = "Scriptable Objects/Item Database")]
public class ItemDatabaseSO : ScriptableObject
{
    [Header("Items")]
    public ItemSO[] items;

    [ContextMenu("Fill Database")]
    public void FillDatabase()
    {
        items = Resources.FindObjectsOfTypeAll<ItemSO>();
        SortDatabase();
    }

    [ContextMenu("Sort Items")]
    public void SortDatabase() => Array.Sort(items, (a, b) => a.Id.CompareTo(b.Id));
}
