﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Death : MonoBehaviour
{
    Vector3 Spawn;
    Rigidbody rb;

    void Start()
    {
        Spawn = new Vector3(-4, 0.5f, 0);
        rb = GetComponent<Rigidbody>();
    }

    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.tag == "Death")
        {
            Death();
        }
    }

    void Update()
    {
        if (transform.localScale.y < 0.2)
        {
            Death();
        }
    }

    public void Death()
    {
        transform.position = Spawn;
        transform.localScale = new Vector3(1, 1, 1);
        transform.rotation = new Quaternion(0, 0, 0, 0);
        rb.velocity = Vector3.zero;
        rb.angularVelocity = Vector3.zero;
    }

}
