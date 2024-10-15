using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SectionManager : MonoBehaviour {
    
    // Objects to spawn
    public GameObject sectionPrefab;
    public GameObject obstacle1;

    // Section manager members
    public int level { get; private set; } = 1;
    public bool stopSections { get; private set; } = false;
    public int distanceBetweenObjects { get; private set; } = 50;
    public int minDistanceBetweenObjects { get; private set;} = 5;
    public int decrementCount {get; private set;} = 5;

    // Start is called before the first frame update
    void Start() {
    }

    // Update is called once per frame
    void Update() {
    }

    public void SpawnNextSection(Vector3 pos, Quaternion rot) {
        // TODO: make a complete new section/environment reset distance between objects to provide
        // a new feel for the player

        // make objects closer to each other to spawn more objects and make it harder 
        distanceBetweenObjects -= decrementCount;
        if (distanceBetweenObjects <= 0) {
            distanceBetweenObjects = minDistanceBetweenObjects;
        }
        Instantiate(sectionPrefab, pos, rot);
    }

    public void StopSections() {
        stopSections = true;
    }
}
