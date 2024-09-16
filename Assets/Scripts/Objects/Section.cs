using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class Section : MonoBehaviour {
    public GameObject floor { get; private set; }
    private List<GameObject> pillars;
    public GameObject coinPrefab;
    private int distanceBetweenCoins = 2;

    // Start is called before the first frame update
    void Start() {
        pillars = GetPillars();
        GameSingleton.instance.sectionManager.ActivatePillars(pillars);
        SpawnCoins();
    }

    // Update is called once per frame
    void Update() {
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

    private void SpawnCoins() {
        Vector2 frontRowStart = GameSingleton.instance.gridManager.RandomPoint();
        Vector2 backRowStart = GameSingleton.instance.gridManager.RandomPoint();
        // start the coin row 5 meters away from player
        float cointDistanceFromPlayer = 20;
        for (int i = 0; i < 10; i += 1) {
            GameObject frontCoinSpawned = Instantiate(coinPrefab, gameObject.transform);
            GameObject backCoinSpawned = Instantiate(coinPrefab, gameObject.transform);
            frontCoinSpawned.transform.position = new Vector3(
                frontRowStart.x, frontRowStart.y, cointDistanceFromPlayer + (distanceBetweenCoins * i));
            backCoinSpawned.transform.position = new Vector3(
                backRowStart.x, backRowStart.y, (cointDistanceFromPlayer * 2) + (distanceBetweenCoins * i));
        }
    }
}
