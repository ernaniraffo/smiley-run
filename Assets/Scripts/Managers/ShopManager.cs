using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopManager : MonoBehaviour {
    public List<GameObject> characters;
    private int characterOnScreen = 0;
    private int characterSelected;
    public GameObject player;

    // UI buttons
    public Button selectButton;

    // Start is called before the first frame update
    void Start() {
        // Make sure all characters are inactive when menu loads
        // Position the characters at (0, 0, 0) in world position
        for (int i = 0; i < characters.Count; i += 1) {
            characters[i].SetActive(false);
            characters[i].gameObject.transform.position = Vector3.zero;
        }

        // Pull currently selected character from Player Prefs
        characterSelected = PlayerPrefs.GetInt("CharacterSelected", 0);
        // Make sure that the character on screen is the character last selected
        characterOnScreen = characterSelected;
    }

    // Update is called once per frame
    void Update() {
        HandleCharacter();
    }

    public void Next() {
        if (characterOnScreen + 1 < characters.Count) {
            DisableCharacter(characterOnScreen);
            characterOnScreen += 1;
            EnableCharacter(characterOnScreen);
        }
    }

    public void Prev() {
        if (characterOnScreen - 1 >= 0) {
            DisableCharacter(characterOnScreen);
            characterOnScreen -= 1;
            EnableCharacter(characterOnScreen);
        }
    }

    private void DisableCharacter(int character) {
        characters[character].SetActive(false);
    }

    private void EnableCharacter(int character) {
        characters[character].SetActive(true);
    }

    public void EnableSelectedCharacter() {
        EnableCharacter(characterSelected);
    }

    private void DisableSelectButton() {
        selectButton.gameObject.SetActive(false);
    }

    private void EnableSelectButton() {
        selectButton.gameObject.SetActive(true);
    }

    private void HandleCharacter() {
        if (!selectButton.IsActive() && (characterOnScreen != characterSelected)) {
            EnableSelectButton();
        } else if (selectButton.IsActive() && (characterOnScreen == characterSelected)) {
            DisableSelectButton();
        }
    }

    public void SelectCharacter() {
        characterSelected = characterOnScreen;
        PlayerPrefs.SetInt("CharacterSelected", characterSelected);
    }

    public void DisableCharacterOnScreen() {
        DisableCharacter(characterOnScreen);
    }
}
