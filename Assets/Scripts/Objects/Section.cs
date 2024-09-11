using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class Section : MonoBehaviour {
    public GameObject floor { get; private set; }
    private List<GameObject> pillars;

    // Start is called before the first frame update
    void Start() {
        pillars = GetPillars();
        DeactiveSomePillars();
    }

    // Update is called once per frame
    void Update() {
    }

    void SpawnObject(Transform parent) {
        // Vector3 spawnPosition = new Vector3(parent.position.x + (parent.lossyScale.x / 2) - 10,
        //                                     parent.position.y + parent.lossyScale.y +
        //                                         objectToSpawn.transform.lossyScale.y + 10,
        //                                     parent.position.z);
        // GameObject spawnedObject = Instantiate(objectToSpawn, spawnPosition, Quaternion.identity);
        // spawnedObject.GetComponent<Rigidbody>().isKinematic = true;
    }

    List<GameObject> GetPillars() {
        List<GameObject> pillars = new List<GameObject>();
        for (int i = 0; i < gameObject.transform.childCount; i++) {
            Transform child = gameObject.transform.GetChild(i);
            if (child.CompareTag("Pillar")) {
                pillars.Add(child.gameObject);
            }
        }
        return pillars;
    }

    void DeactiveSomePillars() {
        int section = 1;
        int numToDeactive = pillars.Count;
        if (section == 1) {
            // get the number of pillars to deactive in the section
            numToDeactive = (pillars.Count / 2) - Random.Range(1, pillars.Count / 2);
        }
        for (int i = 0; i < numToDeactive; i++) {
            int index = Random.Range(0, pillars.Count);
            // destroy the game object at the index
            Destroy(pillars[i]);
            // remove object at index so the next random number cannot be the same game object
            // in case the generayed index by random is the same as previous
            pillars.RemoveAt(index);
        }
    }
}
