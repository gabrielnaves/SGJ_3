using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Key : MonoBehaviour {

    void OnTriggerStay2D(Collider2D other) {
        if (Input.GetKeyDown(KeyCode.Space)) {
            Player.instance.hasKey = true;
            KeyTexts.instance.ShowGotKeyText();
            Destroy(gameObject);
        }
    }
}
