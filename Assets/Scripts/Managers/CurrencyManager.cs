using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CurrencyManager : MonoBehaviour {
    private int currency;

    // Start is called before the first frame update
    void Start() {
        currency = PlayerPrefs.GetInt("Currency", 0);
    }

    // Update is called once per frame
    void Update() {
        // Developer shortcut to clear player prefs
        if (Input.GetKeyDown(KeyCode.C)) {
            ClearPlayerCurrency();
        }
    }

    public void AddCurrency(int value) {
        currency += value;
        PlayerPrefs.SetInt("Currency", currency);
    }

    public void RemoveCurrency(int value) {
        currency -= value;
        if (currency < 0) {
            currency = 0;
        }
        PlayerPrefs.SetInt("Currency", currency);
    }

    public int GetCurrency() {
        return currency;
    }

    private void ClearPlayerCurrency() {
        currency = 0;
        PlayerPrefs.SetInt("Currency", 0);
    }
}
