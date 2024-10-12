using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnNextSection : MonoBehaviour {
    public GameObject sectionPrefab;
    private float distance = 75f;

    // Start is called before the first frame update
    void Start() {
    }

    // Update is called once per frame
    void Update() {
    }

    void OnTriggerEnter(Collider other) {
        if (other.gameObject.CompareTag("Player")) {
            Vector3 pos = new Vector3(transform.parent.position.x, transform.parent.position.y,
                                      transform.parent.position.z + distance);
            GameSingleton.instance.sectionManager.SpawnNextSection(pos, Quaternion.identity);
        }
    }
}
