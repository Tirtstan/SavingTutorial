using System.Collections.Generic;
using System.Linq;
using MessagePack;

[MessagePackObject(keyAsPropertyName: true)]
public class LevelData
{
    public LevelData() { }

    public LevelData(List<ISaveable> items) =>
        Items = items.Select(x => (object)x.GetData()).ToList();

    public int Version => 1;
    public List<object> Items { get; set; }
}
