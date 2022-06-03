using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Movement : MonoBehaviour
{
    float movementSpeed = 0.1f;
    float rotationSpeed = 1;
    Vector3 Achicarse; 

    void Start()
    {
        Achicarse = new Vector3(-0.001f, -0.001f, -0.001f);
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.W))
        {
            transform.Translate(movementSpeed, 0, 0);
            transform.localScale += Achicarse;

            if (transform.localScale.y < 0.2)
            {
                transform.position = new Vector3(0, 1.30f, 0);
                transform.localScale = new Vector3(1, 1, 1);
            }
        }

        if (Input.GetKey(KeyCode.S))
        {
            transform.Translate(-movementSpeed, 0, 0);
            transform.localScale += Achicarse;

            if (transform.localScale.y < 0.2)
            {
                transform.position = new Vector3(0, 1.30f, 0);
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

    }
}
