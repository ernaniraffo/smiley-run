using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UIManager : MonoBehaviour {
    public TMP_Text currencyText;

    // Start is called before the first frame update
    void Start() {
    }

    // Update is called once per frame
    void Update() {
        UpdateCurrency();
    }

    public void UpdateCurrency() {
        currencyText.text = "Currency: " + GameSingleton.instance.currencyManager.GetCurrency();
    }
}
