using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player_Movement : MonoBehaviour
{
    float movementSpeed = 0.2f;
    float rotationSpeed = 2f;
    Vector3 Achicarse, ScaleFrio, ScaleCaliente, RotacionInicial;
    bool HasJumped;
    Rigidbody rb;
    public Text Porcentaje;
    public GameObject Confeti;
    GameObject clon;

    void Start()
    {
        Achicarse = new Vector3(-0.001f, -0.001f, -0.001f);
        ScaleFrio = new Vector3(0.008f, 0.008f, 0.008f);
        ScaleCaliente = new Vector3(-0.0055f, -0.0055f, -0.0055f);
        rb = GetComponent<Rigidbody>();
        RotacionInicial = new Vector3(0, 0, 0);
    }

    void Update()
    {
        Debug.Log(Time.time);

        if (Input.GetKey(KeyCode.W))
        {
            transform.Translate(movementSpeed, 0, 0);
            transform.localScale += Achicarse;
        }

        if (Input.GetKey(KeyCode.S))
        {
            transform.Translate(-movementSpeed, 0, 0);
            transform.localScale += Achicarse;
        }

        if (Input.GetKey(KeyCode.D))
        {
            transform.Rotate(0, rotationSpeed, 0);
        }

        if (Input.GetKey(KeyCode.A))
        {
            transform.Rotate(0, -rotationSpeed, 0);
        }

        if (Input.GetKey(KeyCode.R))
        {
            GetComponent<Player_Death>().Death();
        }

        if (Input.GetKeyDown(KeyCode.Space) && HasJumped)
        {
            rb.AddForce(Vector3.up * 7, ForceMode.Impulse);
            HasJumped = false;
        }

        if (transform.position.y < -11)
        {
            GetComponent<Player_Death>().Death();
        }

        //if (Input.GetKeyDown(KeyCode.UpArrow))
        //{
        //    rb.AddForce(transform.right * movementSpeed, ForceMode.Acceleration);
        //}
        //Idea para que el cubo se deslice 

        Porcentaje.text = Mathf.Floor(((transform.localScale.y - 0.2f) / 0.8f * 100f)).ToString() + "%";
        //time. deltatie para hacer lo de contador 

    }

    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.tag == "Ground")
        {
            HasJumped = true;
        }

        if (col.gameObject.tag == "Ganaste")
        {
            HasJumped = true;
            for(int i = 0; i<20; i++)
            {
                clon = Instantiate(Confeti);
                Destroy(clon, 4);
            }
        }

        if (col.gameObject.tag == "Placa Fria")
        {
            HasJumped = true;
            GetComponent<Play_Sound>().SonidoCongelarse();
        }

        if (col.gameObject.tag == "Placa Caliente")
        {
            HasJumped = true;
            GetComponent<Play_Sound>().SonidoDerretirse();
        }
    }

    void OnCollisionStay(Collision col)
    {
        if (col.gameObject.tag == "Placa Fria")
        {

            if (transform.localScale.y < 3.0)
            {
                transform.localScale += ScaleFrio;
            }
        }

        if (col.gameObject.tag == "Placa Caliente")
        {
            if (transform.localScale.y > 0.2)
            {
                transform.localScale += ScaleCaliente;
            }

            else
            {
                GetComponent<Player_Death>().Death();
                
            }
        }
    }



    //private void OnTriggerStay(Collider other)
    //{
    //idea Gero de que sea un espcio y no algo fisico. Pero deberia poner el prefab de las placas on trigger. 
    //}

}
