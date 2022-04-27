using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PhysicsController : BaseTransform
{
    protected Rigidbody2D rb;
    protected Collider2D collidr;

    protected override void Awake()
    {
        base.Awake();

        rb = GetComponent<Rigidbody2D>();
        collidr = GetComponent<Collider2D>();
    }
}
