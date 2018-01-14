using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyActions : MonoBehaviour {

    public float startTime = 3f;
    public float loopTime = 10f;
    public Vector3[] startPath;
    public Vector3[] loopPath;

    float currentPos;
    float elapsedTime = 0f;
    Vector3 previousPosition;
    Rigidbody2D rigidbody2d;
    bool passedStart = false;
    bool forward = true;

    void Start() {
        rigidbody2d = GetComponent<Rigidbody2D>();
        currentPos = 0f;
        iTween.PutOnPath(gameObject, startPath, currentPos);
        previousPosition = startPath[0];
    }

    void FixedUpdate() {
        elapsedTime += Time.fixedDeltaTime;
        if (!passedStart)
            UpdateStartMovement();
        else
            UpdateLoopMovement();

    }

    void UpdateStartMovement() {
        currentPos = elapsedTime / startTime;
        var nextPoint = iTween.PointOnPath(startPath, currentPos);
        rigidbody2d.MovePosition(nextPoint);
        if (currentPos > 1f) {
            passedStart = true;
            elapsedTime = 0f;
        }
    }

    void UpdateLoopMovement() {
        if (forward)
            currentPos = elapsedTime / loopTime;
        else
            currentPos = 1 - elapsedTime / loopTime;
        currentPos = Mathf.Clamp01(currentPos);
        var nextPoint = iTween.PointOnPath(loopPath, currentPos);
        rigidbody2d.MovePosition(nextPoint);
        if (currentPos == 1f) {
            forward = false;
            elapsedTime = 0f;
        }
        else if (currentPos == 0f) {
            forward = true;
            elapsedTime = 0f;
        }
    }

    public void LookTowardsMovement() {
        var dir = transform.position - previousPosition;
        if (!Mathf.Approximately(dir.x, 0f) || !Mathf.Approximately(dir.y, 0f)) {
            transform.rotation = Quaternion.Euler(0, 0, Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg);
            previousPosition = transform.position;
        }
    }

    void OnDrawGizmosSelected() {
        if (startPath != null)
            iTween.DrawPath(startPath, Color.white);
        if (loopPath != null)
            iTween.DrawPath(loopPath, Color.red);
    }
}
