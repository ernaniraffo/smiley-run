using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pillar : MonoBehaviour {
    // array of objects to spawn
    public List<GameObject> flyingObjects;
    // the body of the pillar so we can calculate the height of it
    public GameObject pillarBody;
    // global offset to make the object look like it is floating on top of pillar
    private int offsetFromPillarSurface = 2;

    // Start is called before the first frame update
    void Start() {
        SpawnFlyingObject();
    }

    // Update is called once per frame
    void Update() {
    }

    void SpawnFlyingObject() {
        int randomObjectIndex = Random.Range(0, flyingObjects.Count);
        GameObject flyingObject = flyingObjects[randomObjectIndex];
        // the object should be at (0, 0, 0) + half the height of the pillar + offset from pillar +
        // half the height of the object to spawn
        float posY = (pillarBody.transform.lossyScale.y / 2) + offsetFromPillarSurface +
                     (flyingObject.transform.lossyScale.y / 2);
        GameObject spawnedObject = Instantiate(flyingObjects[randomObjectIndex], transform);
        spawnedObject.transform.localPosition = new Vector3(0, posY, 0);
    }
}
