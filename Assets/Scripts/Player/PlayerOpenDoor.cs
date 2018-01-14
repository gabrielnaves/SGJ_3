using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerOpenDoor : MonoBehaviour {

    public PlayerMovement playerMovement;
    List<Door> adjacentDoors = new List<Door>();

    void OnTriggerEnter2D(Collider2D other) {
        var door = other.gameObject.GetComponent<Door>();
        if (door)
            if (!adjacentDoors.Contains(door))
                adjacentDoors.Add(door);
    }

    void OnTriggerExit2D(Collider2D other) {
        var door = other.gameObject.GetComponent<Door>();
        if (door)
            if (adjacentDoors.Contains(door)) {
                adjacentDoors.Remove(door);
                door.StopPeekingDoor();
            }
    }

    void Update() {
        if (Input.GetKeyDown(KeyCode.Space))
            foreach(var door in adjacentDoors)
                door.ToggleDoor();
        if (Input.GetKey(KeyCode.E)) {
            foreach(var door in adjacentDoors)
                door.PeekDoor();
            playerMovement.enabled = false;
        }
        else if (Input.GetKeyUp(KeyCode.E) && !Overmind.instance.gameEnded) {
            foreach(var door in adjacentDoors)
                door.StopPeekingDoor();
            playerMovement.enabled = true;
        }
    }
}
