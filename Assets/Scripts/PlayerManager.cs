using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class PlayerManager : MonoBehaviour {
    public GameObject player;
    bool move = false;
    bool movingX = false;
    bool movingY = false;
    float duration = 0.075f;
    public float speed = 20f;
    public float moveDistance;

    // Movement grid size
    private float minX;
    private float maxX;
    private float minY;
    private float maxY;

    // Start is called before the first frame update
    void Start() {
        player = gameObject;
        player.transform.position = new Vector3(0, 0, 0);
        moveDistance = 10f;

        minX = -moveDistance;
        maxX = moveDistance;
        minY = -moveDistance;
        maxY = moveDistance;
    }

    // Update is called once per frame
    void Update() {
        MovePlayerForward();
        HandleMovement();
    }

    void HandleMovement() {
        float x = player.gameObject.transform.position.x;
        float y = player.gameObject.transform.position.y;

        if ((Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow)) && y < maxY) {
            y += moveDistance;
            move = true;
        }
        if ((Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow)) && x > minX) {
            x -= moveDistance;
            move = true;
        }
        if ((Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow)) && x < maxX) {
            x += moveDistance;
            move = true;
        }
        if ((Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.DownArrow)) && y > minY) {
            y -= moveDistance;
            move = true;
        }

        if (move && !movingX && !movingY) {
            move = false;
            movingX = true;
            movingY = true;
            transform.DOMoveX(x, duration).OnComplete(StopMovingX);
            transform.DOMoveY(y, duration).OnComplete(StopMovingY);
        }
    }

    private void StopMovingX() {
        movingX = false;
    }

    private void StopMovingY() {
        movingY = false;
    }

    public Vector3 GetPlayerPosition() {
        return player.transform.position;
    }

    public void MovePlayerForward() {
        player.transform.position += new Vector3(0, 0, speed * Time.deltaTime);
    }
}
