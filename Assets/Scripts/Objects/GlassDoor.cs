using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using Unity.VisualScripting;

public class GlassDoor : MonoBehaviour {
    // Top and bottom doors
    public GameObject topDoor;
    public GameObject bottomDoor;
    private float animationDuration = 3f;

    private int UP = 1;
    private int DOWN = -1;

    // Start is called before the first frame update
    void Start() {
    }

    // Update is called once per frame
    void Update() {
    }

    /// <summary>
    /// Moves the door transform either up or down according to the direction.
    /// Direction = 1 means door will move up.
    /// Direction = -1 means door will move down
    /// </summary>
    /// <param name="doorTransform"></param>
    /// <param name="direction"></param>
    public void MoveDoor(Transform doorTransform, int direction) {
        doorTransform.DOMoveY(doorTransform.position.y + (doorTransform.lossyScale.y * direction),
                              animationDuration, false);
    }

    public void OpenDoors() {
        MoveDoor(topDoor.transform, UP);
        MoveDoor(bottomDoor.transform, DOWN);
    }

    public void OnTriggerEnter(Collider other) {
        if (other.gameObject.CompareTag("Player")) {
            OpenDoors();
        }
    }
}
