using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShapeSpawnerManager : MonoBehaviour {

    public GameObject spawner;
    public List<GameObject> shapes;
    public float spawnDelay = 0.5f;
    public int distanceFromPlayer = 50;
    public bool startSpawner = true;
    public bool spawnShapes = true;

    // Start is called before the first frame update
    void Start() {
        spawner = new GameObject("ShapeSpawner");
        spawner.transform.parent = transform;
        spawner.gameObject.transform.position = new Vector3(0, 0, 30);
    }

    // Update is called once per frame
    void Update() {
        // MoveSpawnerWithPlayer();
        if (startSpawner) {
            StartCoroutine(SpawnShapes());
            startSpawner = false;
        }
    }

    IEnumerator SpawnShapes() {
        while (spawnShapes) {
            Vector2 randomSpawnPoint = GameSingleton.instance.gridManager.RandomPoint();
            Vector3 playerPosition = GameSingleton.instance.playerManager.GetPlayerPosition();
            Vector3 spawnPoint = new Vector3(randomSpawnPoint.x, randomSpawnPoint.y,
                                             playerPosition.z + distanceFromPlayer);
            int randomShapeIndex = Random.Range(0, shapes.Count);
            Instantiate(shapes[randomShapeIndex], spawnPoint, transform.rotation);
            yield return new WaitForSeconds(spawnDelay);
        }
    }

    // private void MoveSpawnerWithPlayer() {
    //     Vector3 playerPosition = GameSingleton.instance.playerManager.GetPlayerPosition();
    //     spawner.gameObject.transform.position =
    //         new Vector3(0, 0, playerPosition.z + distanceFromPlayer);
    // }
}
