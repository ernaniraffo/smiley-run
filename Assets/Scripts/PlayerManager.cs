using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class PlayerManager : MonoBehaviour {
  public GameObject player;
  bool move = false;
  bool moving = false;
  float duration = 0.075f;

  // Start is called before the first frame update
  void Start() {
    player = gameObject;
    player.transform.position = new Vector3(0, 0, 0);
  }

  // Update is called once per frame
  void Update() { HandleMovement(); }

  void HandleMovement() {
    float x = player.gameObject.transform.position.x;
    float y = player.gameObject.transform.position.y;
    if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow)) {
      y += 10;
      move = true;
    }
    if (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow)) {
      x -= 10;
      move = true;
    }
    if (Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow)) {
      x += 10;
      move = true;
    }
    if (Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.DownArrow)) {
      y -= 10;
      move = true;
    }
    // transform.position = new Vector3(x, y, 0);
    if (move && !moving) {
      move = false;
      moving = true;
      transform.DOMove(new Vector3(x, y, 0), duration).OnComplete(StopMoving);
    }
  }

  private void StopMoving() {
    Debug.Log("Stop moving!!");
    moving = false;
  }

  public Vector3 GetPlayerPosition() { return player.transform.position; }
}
