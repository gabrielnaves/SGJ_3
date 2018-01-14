using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraOrtoSize : MonoBehaviour {

    public float pixelsPerUnit = 32f;

    void LateUpdate() {
        float height = Screen.height;
        float ortoSize = height / pixelsPerUnit / 4f;
        if (ortoSize < 6f) ortoSize *= 2f;
        Camera.main.orthographicSize = ortoSize;
    }
}
