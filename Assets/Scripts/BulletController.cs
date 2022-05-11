using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : PhysicsController, IPoolable
{
    private Vector2 startPosition;

    private float speed;

    //protected override void Awake()
    //{
    //    base.Awake();
    //    Distance = float.MaxValue;
    //}

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

    public void Init(float speed, float distance, Vector2 position, Quaternion rotation)
    {
        tf.position = position;
        tf.rotation = rotation;
        Init(speed, distance);

        Debug.Log($"Bullet {speed} {distance} {position} {rotation.eulerAngles.z}");
    }

    public void Recycle()
    {
        gameObject.SetActive(false);
    }

    public void TurnOn()
    {
        gameObject.SetActive(true);
    }

    private void Update()
    {
        if(Vector2.Distance(startPosition,tf.position) >= Distance)
        {
            SendToPool();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Enemy")
        {
            SendToPool();
        }
    }

    protected void SendToPool()
    {
        Factory.Instance.ReturnObject(FactoryItem.Bullet, this);
    }
}
