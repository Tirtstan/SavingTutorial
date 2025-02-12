using UnityEngine;

public class CompassItem : Item
{
    public enum Direction
    {
        North = 0,
        South = 1,
        East = 2,
        West = 3,
    }

    private Direction currentDir;

    public Direction GetCurrentDirection() => currentDir;

    public override void RandomizeProperties()
    {
        base.RandomizeProperties();
        currentDir = (Direction)Random.Range(0, 4);
    }
}
