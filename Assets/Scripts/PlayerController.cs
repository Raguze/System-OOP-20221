using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : PhysicsController
{
    [SerializeField]
    private float maxSpeed = 10f;
    [SerializeField]
    private float currentSpeed = 0f;
    [SerializeField]
    private float speedT = 0.05f;

    private float horizontal;
    private float vertical;
    private Vector2 direction;

    public Vector2 pointerPosition;

    public bool hasMove;

    public bool HasMovement { 
        get {
            return direction.magnitude > 0;
        }
    }

    private Vector2 _lastDirection = new Vector2();
    public Vector2 LastDirection
    {
        get
        {
            if(HasMovement)
            {
                _lastDirection = direction;
            }
            return _lastDirection;
        }
    }

    public float targetSpeed;

    protected float TargetSpeed
    {
        get
        {
            if(HasMovement)
            {
                return maxSpeed;
            } 
            else
            {
                return 0;
            }
        }
    }

    public float Velocity;

    private void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        horizontal = Input.GetAxisRaw("Horizontal");
        vertical = Input.GetAxisRaw("Vertical");
        direction = new Vector2(horizontal, vertical);
        currentSpeed = Mathf.Lerp(currentSpeed, TargetSpeed, speedT * Time.deltaTime);
        rb.velocity = LastDirection.normalized * currentSpeed;

        pointerPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        //float deltaX = pointerPosition.x - tf.position.x;
        //float deltaY = pointerPosition.y - tf.position.y;
        //float angleZ = Mathf.Atan2(deltaY, deltaX) * Mathf.Rad2Deg;

        Vector2 deltaPosition = pointerPosition - (Vector2)tf.position;
        float angleZ = Mathf.Atan2(deltaPosition.y, deltaPosition.x) * Mathf.Rad2Deg;

        tf.rotation = Quaternion.Euler(0, 0, angleZ);

        hasMove = HasMovement;
        targetSpeed = TargetSpeed;

    }

}
