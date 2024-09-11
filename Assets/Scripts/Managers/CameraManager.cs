using UnityEngine;

public class CameraManager : MonoBehaviour {
    public GameObject mainCamera;

    void Start() {
        mainCamera = Camera.main.gameObject;
        mainCamera.transform.position = new Vector3(0, 0, -30);
        mainCamera.GetComponent<Camera>().fieldOfView = 60f;
    }

    void Update() {
        FollowPlayer();
    }

    void FollowPlayer() {
        Vector3 playerPosition = GameSingleton.instance.playerManager.GetPlayerPosition();
        mainCamera.transform.position = new Vector3(0, 0, playerPosition.z - 30);
    }
}