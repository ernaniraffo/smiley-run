using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameSingleton : MonoBehaviour {

    static public GameSingleton instance { get; private set; }

    // Manage other singletons
    public PlayerManager playerManager { get; private set; }
    public CameraManager cameraManager { get; private set; }
    public GridManager gridManager { get; private set; }
    public ShapeSpawnerManager shapeSpawnerManager { get; private set; }
    public SectionManager sectionManager { get; private set; }

    void Awake() {
        if (instance != null && instance != this) {
            Destroy(gameObject);
        } else {
            instance = this;
        }

        playerManager = gameObject.GetComponentInChildren<PlayerManager>();
        cameraManager = gameObject.GetComponentInChildren<CameraManager>();
        gridManager = gameObject.GetComponentInChildren<GridManager>();
        shapeSpawnerManager = gameObject.GetComponentInChildren<ShapeSpawnerManager>();
        sectionManager = gameObject.GetComponentInChildren<SectionManager>();
    }

    void Start() {
    }
}