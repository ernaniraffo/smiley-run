using UnityEngine;

public class GridManager : MonoBehaviour {

    public Vector2 gridCenter { get; private set; }
    private int offset;

    void Start() {
        gridCenter = new Vector2(0, 0);
    }

    public Vector2 UpperLeft() {
        return new Vector2(gridCenter.x - offset, gridCenter.y + offset);
    }

    public Vector2 UpperCenter() {
        return new Vector2(gridCenter.x, gridCenter.y + offset);
    }

    public Vector2 UpperRight() {
        return new Vector2(gridCenter.x + offset, gridCenter.y + offset);
    }

    public Vector2 MiddleLeft() {
        return new Vector2(gridCenter.x - offset, gridCenter.y);
    }

    public Vector2 Center() {
        return new Vector2(gridCenter.x, gridCenter.y);
    }

    public Vector2 MiddleRight() {
        return new Vector2(gridCenter.x + offset, gridCenter.y);
    }

    public Vector2 LowerLeft() {
        return new Vector2(gridCenter.x - offset, gridCenter.y - offset);
    }

    public Vector2 LowerCenter() {
        return new Vector2(gridCenter.x, gridCenter.y - offset);
    }

    public Vector2 LowerRight() {
        return new Vector2(gridCenter.x + offset, gridCenter.y - offset);
    }

    public Vector2 RandomPoint() {
        int[] offsets = { -10, 10 };
        int random_x = (int) gridCenter.x + offsets[Random.Range(0, offsets.Length)];
        int random_y = (int) gridCenter.y + offsets[Random.Range(0, offsets.Length)];
        return new Vector2(random_x, random_y);
    }
}