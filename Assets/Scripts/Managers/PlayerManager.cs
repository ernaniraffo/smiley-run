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
    public float horizontalDistance = 7.5f;
    public float verticalDistance = 3f;

    // Components
    private Rigidbody playerRb;

    // Start is called before the first frame update
    void Start() {
        player = gameObject;
        playerRb = GetComponent<Rigidbody>();
        // make sure gravity is off
        playerRb.useGravity = false;
    }

    // Update is called once per frame
    void Update() {
        HandleMovement();
    }

    void HandleMovement() {
        float x = player.gameObject.transform.position.x;
        float y = player.gameObject.transform.position.y;

        if (!GameSingleton.instance.sectionManager.stopSections) {
            if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow)) {
                y += verticalDistance;
                move = true;
            }
            if (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow)) {
                x -= horizontalDistance;
                move = true;
            }
            if (Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow)) {
                x += horizontalDistance;
                move = true;
            }
            if (Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.DownArrow)) {
                y -= verticalDistance;
                move = true;
            }

            // Check if the new position is valid
            // If not valid, then do not move!
            if (move && !GameSingleton.instance.gridManager.InBounds(new Vector2(x, y))) {
                move = false;
            }

            if (move && !movingX && !movingY) {
                move = false;
                movingX = true;
                movingY = true;
                transform.DOMoveX(x, duration).OnComplete(StopMovingX);
                transform.DOMoveY(y, duration).OnComplete(StopMovingY);
            }
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

    public void OnCollisionEnter(Collision collision) {
        if (collision.gameObject.CompareTag("Obstacle")) {
            Debug.Log("Collided with obstacle: " + collision.gameObject.name);
            // turn gravity on to make it seem we are dead
            playerRb.useGravity = true;
            // should stop the section moving towards camera
            GameSingleton.instance.sectionManager.StopSections();
        } else {
            Debug.Log("Collided with " + collision.gameObject.name);
        }
    }
}
