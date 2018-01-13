using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraOrtoSize : MonoBehaviour {

    public float pixelsPerUnit = 32f;

    void Start() {
        float height = Screen.height;
        float ortoSize = height / pixelsPerUnit / 4f;
        Camera.main.orthographicSize = ortoSize;
    }
}
