using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GridSnapping : MonoBehaviour {

    public float pixelsPerUnit = 32f;
    public UnityEvent afterSnapEvent;

    public bool useRigidbody = false;

    Rigidbody2D rigidbody2d;

    void Awake() {
        rigidbody2d = GetComponent<Rigidbody2D>();
    }

    void LateUpdate() {
        var position = transform.position;
        position.x = Mathf.Round(position.x * pixelsPerUnit);
        position.y = Mathf.Round(position.y * pixelsPerUnit);
        position /= pixelsPerUnit;
        if (useRigidbody)
            rigidbody2d.MovePosition(position);
        else
            transform.position = position;
        if (afterSnapEvent != null)
            afterSnapEvent.Invoke();
    }
}
