using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SectionManager : MonoBehaviour {
    public GameObject sectionPrefab;
    public int level { get; private set; } = 1;

    // boolean to stop sections when player "dies"
    public bool stopSections { get; private set; }

    // Obstacles to spawn
    public GameObject obstacle1;

    // Start is called before the first frame update
    void Start() {
    }

    // Update is called once per frame
    void Update() {
    }

    public void SpawnNextSection(Vector3 pos, Quaternion rot) {
        Instantiate(sectionPrefab, pos, rot);
    }

    public void StopSections() {
        stopSections = true;
    }
}
