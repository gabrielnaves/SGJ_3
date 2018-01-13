using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

    public float speed;

    Rigidbody2D rigidbody2d;

    void Awake() {
        rigidbody2d = GetComponent<Rigidbody2D>();
    }

    void Update() {
        rigidbody2d.velocity = CalculateMovementSpeed() * CalculateMovementDirection();
    }

    Vector2 CalculateMovementDirection() {
        Vector2 direction = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
        return direction.normalized;
    }

    float CalculateMovementSpeed() {
        if (Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift))
            return speed / 4f;
        return speed;
    }
}
