﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour {

    public string levelName;

    void Update() {
        if (Input.anyKeyDown) {
            SceneManager.LoadScene(levelName);
        }
    }
}
