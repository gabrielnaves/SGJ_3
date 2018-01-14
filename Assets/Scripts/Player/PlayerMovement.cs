using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

    public float speed;
    new public bool enabled = true;

    Rigidbody2D rigidbody2d;
    new Camera camera;

    void Awake() {
        rigidbody2d = GetComponent<Rigidbody2D>();
        camera = Camera.main;
    }

    void Update() {
        if (enabled)
            rigidbody2d.velocity = CalculateMovementSpeed() * CalculateMovementDirection();
        else
            rigidbody2d.velocity = Vector2.zero;
        UpdateRotation();
    }

    void UpdateRotation() {
        Vector2 mousePosition = camera.ScreenToWorldPoint(Input.mousePosition);
        transform.rotation = Quaternion.Euler(0, 0, Angle(mousePosition - (Vector2)transform.position));
    }

    float Angle(Vector2 point) {
        return Mathf.Atan2(point.y, point.x) * Mathf.Rad2Deg;
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
