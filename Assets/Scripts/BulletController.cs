using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : PhysicsController
{
    private float speed;

    public float Speed
    {
        get { return speed; }
        set { 
            speed = value;
            rb.velocity = tf.right * speed;
        }
    }

    private void Start()
    {
        //Speed = 1f;
    }
}
