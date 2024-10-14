using UnityEngine;

public class CameraManager : MonoBehaviour {
    public GameObject mainCamera {get; private set;}
    public float distanceFromPlayer = 10;

    public float rotationX = 5;
    public float posY = 3;

    void Start() {
        mainCamera = Camera.main.gameObject;

        mainCamera.transform.position = GameSingleton.instance.playerManager.GetPlayerPosition() +
                                        new Vector3(0, posY, -distanceFromPlayer);
        mainCamera.transform.rotation = Quaternion.Euler(rotationX, 0, 0);
        mainCamera.GetComponent<Camera>().fieldOfView = 60f;
    }

    void Update() {
        FollowPlayer();
    }

    void FollowPlayer() {
        Vector3 playerPosition = GameSingleton.instance.playerManager.GetPlayerPosition();
        if (GameSingleton.instance.sectionManager.stopSections) {
            mainCamera.transform.position = new Vector3(playerPosition.x, playerPosition.y,
                                                        playerPosition.z - distanceFromPlayer);
        } else {
            mainCamera.transform.position = GameSingleton.instance.playerManager.GetPlayerPosition() +
                                        new Vector3(0, posY, -distanceFromPlayer);
            mainCamera.transform.rotation = Quaternion.Euler(rotationX, 0, 0);
        }
    }
}