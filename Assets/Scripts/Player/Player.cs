using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    static public Player instance { get; private set; }

    public PlayerMovement movement;
    public PlayerOpenDoor openDoor;
    public PlayerFieldOfView fieldOfView;

    public Vector3 position {
        get {
            return transform.position;
        }
    }

    void Awake() {
        instance = this;
    }
}
