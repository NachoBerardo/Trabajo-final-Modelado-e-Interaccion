using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Movement : MonoBehaviour
{
    float movementSpeed = 0.1f;
    float rotationSpeed = 1;
    Vector3 Achicarse, Spawn;
    bool HasJumped;
    Rigidbody rb;

    void Start()
    {
        Achicarse = new Vector3(-0.001f, -0.001f, -0.001f);
        Spawn = new Vector3(-4, 0.5f, 0);
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.W))
        {
            transform.Translate(movementSpeed, 0, 0);
            transform.localScale += Achicarse;

            if (transform.localScale.y < 0.2)
            {
                transform.position = Spawn;
                transform.localScale = new Vector3(1, 1, 1);
            }
        }

        if (Input.GetKey(KeyCode.S))
        {
            transform.Translate(-movementSpeed, 0, 0);
            transform.localScale += Achicarse;

            if (transform.localScale.y < 0.2)
            {
                transform.position = Spawn;
                transform.localScale = new Vector3(1, 1, 1);
            }
        }

        if (Input.GetKey(KeyCode.D))
        {
            transform.Rotate(0, rotationSpeed, 0);
        }

        if (Input.GetKey(KeyCode.A))
        {
            transform.Rotate(0, -rotationSpeed, 0);
        }

        if (Input.GetKeyDown(KeyCode.Space) && HasJumped)
        {
            rb.AddForce(Vector3.up * 7, ForceMode.Impulse);
            HasJumped = false;
        }

        if(transform.position.y < -8)
        {
            transform.position = Spawn;
        }

    }

    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.tag == "Ground")
        {
            HasJumped = true;
        }

        if (col.gameObject.tag == "Death")
        {
            transform.position = Spawn;
            transform.localScale = new Vector3(1, 1, 1);
        }
    }
}
