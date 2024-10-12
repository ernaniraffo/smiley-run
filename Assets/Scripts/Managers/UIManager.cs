using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour {
    public TMP_Text currencyText;
    public Canvas playAgainMenu;

    // Start is called before the first frame update
    void Start() {
        playAgainMenu.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update() {
        UpdateCurrency();
    }

    public void UpdateCurrency() {
        currencyText.text = "Currency: " + GameSingleton.instance.currencyManager.GetCurrency();
    }

    public void PlayAgain() {
        Scene s = SceneManager.GetActiveScene();
        SceneManager.LoadScene(s.name);
    }

    public void ShowPlayAgainMenu() {
        playAgainMenu.gameObject.SetActive(true);
    }
}
