using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour {

    Rigidbody2D rigidbody2d;
    float startingRotation;

    void Awake() {
        rigidbody2d = GetComponent<Rigidbody2D>();
        startingRotation = rigidbody2d.rotation;
    }

    void LateUpdate() {
        if (rigidbody2d.rotation > startingRotation + 90f)
            rigidbody2d.rotation = startingRotation + 90f;
        if (rigidbody2d.rotation < startingRotation - 90f)
            rigidbody2d.rotation = startingRotation - 90f;
    }
}
