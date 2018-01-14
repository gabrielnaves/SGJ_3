using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Overmind : MonoBehaviour {

    static public Overmind instance { get; private set; }

    public GameObject bustedText;
    public GameObject gotAwayText;
    public float restartDelay = 1f;
    public Fading fading;

    public void WinGame() {
        Time.timeScale = 0f;
        Player.instance.movement.enabled = false;
        gotAwayText.SetActive(true);
        StartCoroutine("RestartGame");
    }

    public void LoseGame() {
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

    void Start() {
        Player.instance.movement.enabled = false;
        fading.endFadeEvent.AddListener(() => { BeginGame(); });
        fading.RequestFadeOut();
    }

    public void BeginGame() {
        Player.instance.movement.enabled = true;
    }
}
