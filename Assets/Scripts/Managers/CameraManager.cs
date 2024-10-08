using UnityEngine;

public class CameraManager : MonoBehaviour {
    public GameObject mainCamera;
    private float distanceFromPlayer = 10;

    void Start() {
        mainCamera = Camera.main.gameObject;

        mainCamera.transform.position =
            GameSingleton.instance.playerManager.GetPlayerPosition() - new Vector3(0, 0, distanceFromPlayer);
        mainCamera.GetComponent<Camera>().fieldOfView = 60f;
    }

    void Update() {
        FollowPlayer();
    }

    void FollowPlayer() {
        Vector3 playerPosition = GameSingleton.instance.playerManager.GetPlayerPosition();
        if (GameSingleton.instance.sectionManager.stopSections) {
            mainCamera.transform.position =
                new Vector3(playerPosition.x, playerPosition.y, playerPosition.z - distanceFromPlayer);
        }
    }
}