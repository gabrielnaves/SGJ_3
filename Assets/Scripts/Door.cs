using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour {

    public bool requireKey = false;
    public float doorCloseTime = 0.4f;
    public float doorOpenTime = 2f;
    public bool open = false;
    public float maxAngle = 150f;

    Rigidbody2D rigidbody2d;
    float startingRotation;

    public void ToggleDoor() {
        if (open)
            CloseDoor();
        else
            OpenDoor();
    }

    public void OpenDoor(float doorOpenTime=-1f) {
        StopAllCoroutines();
        CancelInvoke();
        open = true;
        rigidbody2d.bodyType = RigidbodyType2D.Dynamic;
        if (doorOpenTime == -1f)
            Invoke("CloseDoor", this.doorOpenTime);
        else
            Invoke("CloseDoor", doorOpenTime);
    }

    public void CloseDoor() {
        open = false;
        StartCoroutine(CloseDoor_());
    }

    public void PeekDoor() {
        gameObject.layer = LayerMask.NameToLayer("DoorsPeek");
    }

    public void StopPeekingDoor() {
        gameObject.layer = LayerMask.NameToLayer("Doors");
    }

    void Awake() {
        rigidbody2d = GetComponent<Rigidbody2D>();
        startingRotation = rigidbody2d.rotation;
        CloseDoor();
    }

    void LateUpdate() {
        if (rigidbody2d.rotation > startingRotation + maxAngle)
            rigidbody2d.rotation = startingRotation + maxAngle;
        if (rigidbody2d.rotation < startingRotation - maxAngle)
            rigidbody2d.rotation = startingRotation - maxAngle;
    }

    IEnumerator CloseDoor_() {
        if (!Mathf.Equals(rigidbody2d.rotation, startingRotation)) {
            float elapsedTime = 0f;
            float start = rigidbody2d.rotation;
            while (elapsedTime < doorCloseTime) {
                rigidbody2d.rotation = Mathf.Lerp(start, startingRotation, elapsedTime / doorCloseTime);
                elapsedTime += Time.deltaTime;
                yield return null;
            }
            rigidbody2d.rotation = startingRotation;
        }
        rigidbody2d.bodyType = RigidbodyType2D.Static;
    }
}
