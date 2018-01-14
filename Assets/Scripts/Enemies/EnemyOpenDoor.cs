using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyOpenDoor : MonoBehaviour {

    void OnTriggerStay2D(Collider2D other) {
        var door = other.gameObject.GetComponent<Door>();
        if (door)
            door.OpenDoor();
    }

    void OnTriggerExit2D(Collider2D other) {
        var door = other.gameObject.GetComponent<Door>();
        if (door)
            door.CloseDoor();
    }
}
