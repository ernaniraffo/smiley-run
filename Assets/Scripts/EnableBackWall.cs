using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnableBackWall : MonoBehaviour {
    public MeshRenderer meshRenderer;
    // Start is called before the first frame update
    void Start() {
        meshRenderer = GetComponent<MeshRenderer>();
    }

    // Update is called once per frame
    void Update() {
    }

    void OnTriggerExit(Collider other) {
        if (other.gameObject.tag == "Player") {
            meshRenderer.enabled = true;
        }
    }
}
