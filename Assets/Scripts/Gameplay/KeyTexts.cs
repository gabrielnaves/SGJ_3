using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyTexts : MonoBehaviour {

    static public KeyTexts instance { get; private set; }

    public GameObject gotKeyText;
    public GameObject nokeyText;

    public void ShowNoKeyWarning() {
        nokeyText.SetActive(true);
        Invoke("DeactivateTexts", 0.5f);
    }

    public void ShowGotKeyText() {
        gotKeyText.SetActive(true);
        Invoke("DeactivateTexts", 1f);
    }

    void DeactivateTexts() {
        gotKeyText.SetActive(false);
        nokeyText.SetActive(false);
    }

    void Awake() {
        instance = this;
    }
}
