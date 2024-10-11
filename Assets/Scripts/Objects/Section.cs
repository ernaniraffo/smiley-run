using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class Section : MonoBehaviour {
    public GameObject floor { get; private set; }
    public GameObject coinPrefab;
    private int distanceBetweenCoins = 2;

    // Start is called before the first frame update
    void Start() {
        SpawnCoins();
        SpawnObstacle();
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
        float sizeOfSection = SectionSize();
        float startOfSection = SectionStart();
        GameObject spawnedObject = Instantiate(obstacle, transform, true);
        Vector2 randomPoint = GameSingleton.instance.gridManager.RandomPoint();
        Vector3 point = new Vector3(randomPoint.x, randomPoint.y, startOfSection);
        spawnedObject.transform.position = point;
        Debug.Log("Spawned obstacle at " + spawnedObject.transform.position + " from " +
                  gameObject.name);
    }

    private float SectionSize() {
        return transform.lossyScale.z;
    }

    private float SectionStart() {
        return transform.position.z - (transform.lossyScale.z / 2);
    }
}
