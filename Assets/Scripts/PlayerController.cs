using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : PhysicsController
{
    [SerializeField]
    private float speed = 10f;

    private float horizontal;
    private float vertical;

    public Vector2 pointerPosition;

    // Update is called once per frame
    void Update()
    {
        horizontal = Input.GetAxis("Horizontal");
        vertical = Input.GetAxis("Vertical");
        rb.velocity = new Vector2(horizontal, vertical) * speed;

        pointerPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        //float deltaX = pointerPosition.x - tf.position.x;
        //float deltaY = pointerPosition.y - tf.position.y;
        //float angleZ = Mathf.Atan2(deltaY, deltaX) * Mathf.Rad2Deg;

        Vector2 deltaPosition = pointerPosition - (Vector2)tf.position;
        float angleZ = Mathf.Atan2(deltaPosition.y, deltaPosition.x) * Mathf.Rad2Deg;

        tf.rotation = Quaternion.Euler(0, 0, angleZ);
    }
}
