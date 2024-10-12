using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class Section : MonoBehaviour {
    public GameObject floor;
    public GameObject coinPrefab;
    private int distanceBetweenCoins = 2;
    private int distanceBetweenObjects = 10;

    // Start is called before the first frame update
    void Start() {
        SpawnCoins();
        SpawnObstacle();
        Debug.Log("Section size: " + SectionSize());
        Debug.Log("Num objects to spawn: " + NumObjectsToSpawn());
    }

    // Update is called once per frame
    void Update() {
    }

    private void SpawnCoins() {
        Vector2 frontRowStart = GameSingleton.instance.gridManager.RandomPoint();
        Vector2 backRowStart = GameSingleton.instance.gridManager.RandomPoint();
        // start the coin row 5 meters away from player
        float coinDistanceFromPlayer = 20;
        for (int i = 0; i < 10; i += 1) {
            GameObject frontCoinSpawned = Instantiate(coinPrefab, gameObject.transform);
            GameObject backCoinSpawned = Instantiate(coinPrefab, gameObject.transform);
            frontCoinSpawned.transform.position =
                new Vector3(frontRowStart.x, frontRowStart.y,
                            coinDistanceFromPlayer + (distanceBetweenCoins * i));
            backCoinSpawned.transform.position =
                new Vector3(backRowStart.x, backRowStart.y,
                            (coinDistanceFromPlayer * 2) + (distanceBetweenCoins * i));
        }
    }

    private void SpawnObstacle() {
        GameObject obstacle = GameSingleton.instance.sectionManager.obstacle1;
        float startOfSection = SectionStart();

        // spawn a number of obstacles in the section
        for (int i = 0; i < NumObjectsToSpawn(); i++) {
            GameObject spawnedObject = Instantiate(obstacle, transform, true);
            Vector2 randomPoint = GameSingleton.instance.gridManager.RandomPoint();

            // don't spawn objects in the middle, probably will revert this because
            // otherwise you can stay in the middle forever and not lose
            if (randomPoint != GameSingleton.instance.gridManager.GridCenter()) {
                Vector3 point = new Vector3(randomPoint.x, randomPoint.y,
                                            startOfSection + (distanceBetweenObjects * i));
                spawnedObject.transform.position = point;
            }
        }
    }

    private float SectionSize() {
        return floor.transform.lossyScale.z;
    }

    private float SectionStart() {
        return floor.transform.position.z - (floor.transform.lossyScale.z / 2);
    }

    private float NumObjectsToSpawn() {
        return SectionSize() / distanceBetweenObjects;
    }
}
