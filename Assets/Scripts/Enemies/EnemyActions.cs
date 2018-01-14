using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyActions : MonoBehaviour {

    public float movementSpeed = 1f;
    public Vector3[] path;

    float currentPos;
    Vector3 previousPosition;
    Rigidbody2D rigidbody2d;

    void Start() {
        rigidbody2d = GetComponent<Rigidbody2D>();
        currentPos = 0f;
        iTween.PutOnPath(gameObject, path, currentPos);
        previousPosition = path[0];
    }

    void FixedUpdate() {
        currentPos += Time.deltaTime * movementSpeed;
        var nextPoint = iTween.PointOnPath(path, currentPos);
        rigidbody2d.MovePosition(nextPoint);
        if (currentPos > 1f)
            enabled = false;
    }

    public void LookTowardsMovement() {
        var dir = transform.position - previousPosition;
        if (!Mathf.Approximately(dir.x, 0f) || !Mathf.Approximately(dir.y, 0f)) {
            transform.rotation = Quaternion.Euler(0, 0, Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg);
            previousPosition = transform.position;
        }
    }

    void OnDrawGizmosSelected() {
        iTween.DrawPath(path, Color.red);
    }
}
