using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SectionManager : MonoBehaviour {
    public GameObject sectionPrefab;

    // Start is called before the first frame update
    void Start() {
    }

    // Update is called once per frame
    void Update() {
    }

    public void SpawnNextSection(Vector3 pos, Quaternion rot) {
        Instantiate(sectionPrefab, pos, rot);
    }
}
