using UnityEngine;

public class GridManager : MonoBehaviour {

    private float horizontalOffset;
    private float verticalOffset;

    void Start() {
        horizontalOffset = GameSingleton.instance.playerManager.horizontalDistance;
        verticalOffset = GameSingleton.instance.playerManager.verticalDistance;
    }

    public Vector2 GetPoint(float horizontalMultiplier, float verticalMultiplier) {
        // Return a point in the grid
        //    *
        // *  *  *
        //    *
        // The multiplier should be -1, 0, 1. Any other value is undefined.
        Vector2 gridCenter = GameSingleton.instance.playerManager.playerStartPosition;
        return new Vector2(gridCenter.x + (horizontalOffset * horizontalMultiplier),
                           gridCenter.y + (verticalOffset * verticalMultiplier));
    }

    public Vector2 RandomPoint() {
        int[] horizontalOffsets = { -1, 0, 1 };
        int[] verticalOffsets = { -1, 0, 1 };
        return GetPoint(horizontalOffsets[Random.Range(0, horizontalOffsets.Length)],
                        verticalOffsets[Random.Range(0, verticalOffsets.Length)]);
    }

    public bool InBounds(Vector2 point) {
        Vector2 gridCenter = GameSingleton.instance.playerManager.playerStartPosition;
        return (point.x >= gridCenter.x - horizontalOffset) &&
               (point.x <= gridCenter.x + horizontalOffset) &&
               (point.y >= gridCenter.y - verticalOffset) &&
               (point.y <= gridCenter.y + verticalOffset);
    }
}