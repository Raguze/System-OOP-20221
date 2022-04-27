using System;
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
    [SerializeField]
    private RangeFloat accTime = new RangeFloat(0,1f);

    private float accDuration = 0.5f;

    public float acc;

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

    public AnimationCurve accelerationCurve;

    public float Velocity;

    protected List<Weapon> weapons = new List<Weapon>();

    private void Start()
    {
        weapons.AddRange(tf.GetComponentsInChildren<Weapon>());

        WeaponDTO revolver = new WeaponDTO()
        {
            Accuracy = 0.95f,
            AmmoMax = 6,
            Damage = 50,
            Distance = 5,
            FireRate = 1,
            ReloadTime = 2,
            Speed = 8
        };

        WeaponDTO machineGun = new WeaponDTO()
        {
            Accuracy = 0.8f,
            AmmoMax = 30,
            Damage = 50,
            Distance = 8,
            FireRate = 0.2f,
            ReloadTime = 1.5f,
            Speed = 8
        };

    }

    // Update is called once per frame
    void Update()
    {
        horizontal = Input.GetAxisRaw("Horizontal");
        vertical = Input.GetAxisRaw("Vertical");
        direction = new Vector2(horizontal, vertical);
        //currentSpeed = Mathf.Lerp(currentSpeed, TargetSpeed, speedT * Time.deltaTime);
        
        if(HasMovement)
        {
            accTime.Add(Time.deltaTime / accDuration);
        } 
        else
        {
            accTime.Sub(Time.deltaTime / accDuration);
        }
        acc = accTime.Current;

        currentSpeed = maxSpeed * accelerationCurve.Evaluate(accTime.Current);
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

        HandleWeapons();
    }

    private void HandleWeapons()
    {
        if(Input.GetMouseButtonDown(0))
        {
            FireWeapon();
        }
    }

    private void FireWeapon()
    {
        //BulletController bulletController = Instantiate<BulletController>(bulletPrefab, tf.position, tf.rotation);
        //bulletController.Init(10f, 3f);

        weapons[0].Fire();
    }
}
