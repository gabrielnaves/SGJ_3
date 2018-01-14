using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Fading : MonoBehaviour {

    public float fadeTime = 2f;
    public float startDelay = 1f;
    public UnityEvent endFadeEvent;

    public void RequestFadeOut() {
        StopAllCoroutines();
        StartCoroutine(fadeRoutine());
    }

    IEnumerator fadeRoutine() {
        float startingScale = transform.localScale.x;
        float endingScale = 0f;
        float elapsedTime = 0f;

        while (elapsedTime < startDelay) {
            elapsedTime += Time.unscaledDeltaTime;
            yield return null;
        }
        elapsedTime = 0f;

        while (elapsedTime < fadeTime) {
            float percentage = elapsedTime / fadeTime;
            transform.localScale = ScaleVector(Mathf.Lerp(startingScale, endingScale, percentage));
            transform.position = Vector3.Lerp(transform.position, Player.instance.position, percentage);
            elapsedTime += Time.unscaledDeltaTime;
            yield return null;
        }

        if (endFadeEvent != null)
            endFadeEvent.Invoke();
        Destroy(gameObject);
    }

    Vector3 ScaleVector(float scale) {
        return new Vector3(scale, scale, 1f);
    }
}
