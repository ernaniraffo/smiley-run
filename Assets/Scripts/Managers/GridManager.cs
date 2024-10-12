using UnityEngine;

public class GridManager : MonoBehaviour {

    public Vector2 GetPoint(float horizontalMultiplier, float verticalMultiplier) {
        // Return a point in the grid
        //    *
        // *  *  *
        //    *
        // The multiplier should be -1, 0, 1. Any other value is undefined.
        return new Vector2(GridCenter().x + (HorizontalOffset() * horizontalMultiplier),
                           GridCenter().y + (VerticalOffset() * verticalMultiplier));
    }

    public Vector2 RandomPoint() {
        int[] horizontalOffsets = { -1, 0, 1 };
        int[] verticalOffsets = { -1, 0, 1 };
        return GetPoint(horizontalOffsets[Random.Range(0, horizontalOffsets.Length)],
                        verticalOffsets[Random.Range(0, verticalOffsets.Length)]);
    }

    public bool InBounds(Vector2 point) {
        Vector2 gridCenter = GridCenter();
        return ((int) point.x >= (int) gridCenter.x - HorizontalOffset()) &&
               ((int) point.x <= (int) gridCenter.x + HorizontalOffset()) &&
               ((int) point.y >= (int) gridCenter.y - VerticalOffset()) &&
               ((int) point.y <= (int) gridCenter.y + VerticalOffset());
    }

    public int HorizontalOffset() {
        return GameSingleton.instance.playerManager.horizontalDistance;
    }

    public int VerticalOffset() {
        return GameSingleton.instance.playerManager.verticalDistance;
    }

    public Vector2 GridCenter() {
        return GameSingleton.instance.playerManager.playerStartPosition;
    }
}