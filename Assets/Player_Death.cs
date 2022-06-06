using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Death : MonoBehaviour
{
    Vector3 Spawn;

    void Start()
    {
        Spawn = new Vector3(-4, 0.5f, 0);
    }

    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.tag == "Death")
        {
            transform.localScale = new Vector3(1.0f, 1.0f, 1.0f);
            transform.position = Spawn;
        }
    }
}
