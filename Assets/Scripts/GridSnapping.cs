using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridSnapping : MonoBehaviour {

    public float pixelsPerUnit = 32f;

    void LateUpdate() {
        var position = transform.position;
        position.x = Mathf.Round(position.x * pixelsPerUnit);
        position.y = Mathf.Round(position.y * pixelsPerUnit);
        position /= pixelsPerUnit;
        transform.position = position;
    }
}
