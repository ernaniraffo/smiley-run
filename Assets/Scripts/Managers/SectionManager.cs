using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SectionManager : MonoBehaviour {
    public GameObject sectionPrefab;
    public int level {get; private set;} = 1;

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

    public void ActivatePillars(List<GameObject> pillars) {
        // default values for number of pillars to enable
        int minPillars = 1;
        int maxPillars = 1;
        if (level == 1) {
            // when in level 1, max pillars enabled is 3
            maxPillars = 3;
        }
        // figure out how many pillars to enable using random
        int pillarsToEnable = Random.Range(minPillars, maxPillars + 1);
        for (int i = 0; i < pillarsToEnable; i++) {
            // get pillar to enable
            int pillarIndex = Random.Range(0, pillars.Count);
            pillars[pillarIndex].SetActive(true);
            // remove from list so we dont roll it again in our RNG
            pillars.RemoveAt(pillarIndex);
        }
    }

    public void StopSections() {
        stopSections = true;
    }
}
