using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Overmind : MonoBehaviour {

    static public Overmind instance { get; private set; }

    public GameObject bustedText;
    public GameObject gotAwayText;
    public float restartDelay = 1f;

    public bool gameEnded { get; private set; }

    public void WinGame() {
        gameEnded = true;
        Time.timeScale = 0f;
        Player.instance.movement.enabled = false;
        gotAwayText.SetActive(true);
        StartCoroutine("RestartGame");
    }

    public void LoseGame() {
        gameEnded = true;
        Time.timeScale = 0f;
        Player.instance.movement.enabled = false;
        bustedText.SetActive(true);
        StartCoroutine("RestartGame");
    }

    public IEnumerator RestartGame() {
        while (!Input.GetKeyDown(KeyCode.Space))
            yield return null;
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    void Awake() {
        instance = this;
    }
}
