using Unity.VisualScripting;
using UnityEngine;

public class FlyTowardsPlayer : MonoBehaviour {
    public float moveSpeed = 0.1f; // Speed at which the object moves towards the player
    private Rigidbody rb;
    private Vector3 direction;
    private float thrust = 50f;
    private bool moveTowards = true;

    void Start() {
        rb = GetComponent<Rigidbody>();
        rb.useGravity = false;
    }

    void Update() {
        Vector3 playerPos = GameSingleton.instance.playerManager.GetPlayerPosition();
        float distance = transform.position.z - playerPos.z;
        if (distance > 10f) {
            direction = (playerPos - transform.position).normalized;
        } else {
            moveTowards = false;
        }
    }

    void FixedUpdate() {
        if (moveTowards) {
            rb.AddForce(direction * thrust);
        }
    }
}
