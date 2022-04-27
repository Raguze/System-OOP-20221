using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : PhysicsController
{
    private Vector2 startPosition;

    private float speed;

    public float Speed
    {
        get { return speed; }
        set { 
            speed = value;
            rb.velocity = tf.right * speed;
        }
    }

    public float Distance { get; protected set; }

    public void Init(float speed, float distance)
    {
        this.Speed = speed;
        this.Distance = distance;

        startPosition = tf.position;
    }

    private void Update()
    {
        if(Vector2.Distance(startPosition,tf.position) >= Distance)
        {
            Destroy(gameObject);
        }
    }
}
