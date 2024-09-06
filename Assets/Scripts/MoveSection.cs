using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;

public class MoveSection : MonoBehaviour {
    public float speed;
    public float moveDistance;

    // Start is called before the first frame update
    void Start() {
        speed = 1;
        moveDistance = 20;
    }

    // Update is called once per frame
    void Update() {
        Move();
    }

    void Move() {
        transform.position -= new Vector3(0, 0, moveDistance * speed) * Time.deltaTime;
    }

    void OnTriggerEnter(Collider other) {
        Debug.Log("TRIGGER ENTER: " + other.gameObject.tag);
        if (other.gameObject.CompareTag("Destroy")) {
            Destroy(gameObject);
        }
    }
}
