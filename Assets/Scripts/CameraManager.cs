using UnityEngine;

public class CameraManager : MonoBehaviour {
  public GameObject mainCamera;

  void Start() {
    mainCamera = Camera.main.gameObject;
    mainCamera.transform.position = new Vector3(0, 0, -30);
    mainCamera.GetComponent<Camera>().fieldOfView = 60f;
  }

  void Update() {}
}