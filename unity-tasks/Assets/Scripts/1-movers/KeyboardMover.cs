using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/**
 * This component moves its object when the player clicks the arrow keys.
 */
public class KeyboardMover: MonoBehaviour {
    [Tooltip("Speed of movement, in meters per second")]
    [SerializeField] float speed = 1f;

    void FixedUpdate() {
        float horizontal = Input.GetAxis("Horizontal"); // +1 if right arrow is pushed, -1 if left arrow is pushed, 0 otherwise
        float vertical = Input.GetAxis("Vertical");     // +1 if up arrow is pushed, -1 if down arrow is pushed, 0 otherwise
        Vector2 movementVector = new Vector2(horizontal, vertical) * speed * Time.deltaTime * 1;
        var rbd2d = GetComponent<Rigidbody2D>();
        rbd2d.MovePosition(rbd2d.position + movementVector);
        //rbd2d.velocity = movementVector;
        //transform.Translate(movementVector);

    }
}
