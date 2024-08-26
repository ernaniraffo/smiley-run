using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnNextSection : MonoBehaviour {
    public GameObject sectionPrefab;
    public float distance = 75f;

    // Start is called before the first frame update
    void Start() {
    }

    // Update is called once per frame
    void Update() {
    }

    void OnTriggerEnter(Collider other) {
        if (other.gameObject.CompareTag("Player")) {
            Debug.Log("Player Entered");
            Instantiate(sectionPrefab,
                        new Vector3(transform.parent.position.x, transform.parent.position.y,
                                    transform.parent.position.z + distance),
                        Quaternion.identity);
        } else {
            Debug.Log(other.gameObject.tag + " entered");
        }
    }
}
