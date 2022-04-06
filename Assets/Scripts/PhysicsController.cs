using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PhysicsController : MonoBehaviour
{
    protected Rigidbody2D rb;
    protected Collider2D collidr;
    protected Transform tf;

    protected void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        collidr = GetComponent<Collider2D>();
        tf = GetComponent<Transform>();
    }
}
