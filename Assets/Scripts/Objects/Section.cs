using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class Section : MonoBehaviour {
    public GameObject floor { get; private set; }
    private List<GameObject> pillars;

    // Start is called before the first frame update
    void Start() {
        pillars = GetPillars();
        Debug.Log(GameSingleton.instance.sectionManager);
        GameSingleton.instance.sectionManager.ActivatePillars(pillars);
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
}
