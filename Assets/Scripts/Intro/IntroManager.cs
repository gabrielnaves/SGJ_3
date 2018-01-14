using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class IntroManager : MonoBehaviour {

    public string level1Name = "Level1";
    public float totalTime = 10f;
    public GameObject heart;
    public GameObject exclamation;
    public Animator crush;
    public Animator player;
    public Vector2[] interestPoints;
    public float[] eventTimes;

    float elapsedTime = 0f;
    bool[] used;

    void Start() {
        GameObject heart = Instantiate(this.heart);
        heart.transform.position = interestPoints[0];
        used = new bool[eventTimes.Length];
    }

    void Update() {
        elapsedTime += Time.deltaTime;
        if (elapsedTime >= eventTimes[0] && !used[0]) {
            used[0] = true;
            GameObject exclamation = Instantiate(this.exclamation);
            exclamation.transform.position = interestPoints[1];
        }
        if (elapsedTime >= eventTimes[1] && !used[1]) {
            used[1] = true;
            crush.SetTrigger("start");
            player.SetTrigger("start");
        }
        if (elapsedTime >= totalTime)
            SceneManager.LoadScene(level1Name);
    }

    void OnDrawGizmos() {
        for (int i=0; i < interestPoints.Length; i++) {
            Gizmos.color = Color.red;
            Gizmos.DrawLine(interestPoints[i] + Vector2.down/4, interestPoints[i] + Vector2.up/4);
            Gizmos.DrawLine(interestPoints[i] + Vector2.left/4, interestPoints[i] + Vector2.right/4);
        }
    }
}
