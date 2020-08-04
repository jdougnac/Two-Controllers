using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player2 : MonoBehaviour
{
    [SerializeField]
    private float _speed;

	// Use this for initialization
	void Start ()
    {
        _speed = 10f;
    }
	
	// Update is called once per frame
	void Update ()
    {
        Movement();
	}


    private void Movement()
    {
        float horizontalInput = Input.GetAxis("Horizontal"); 
        float verticalInput = Input.GetAxis("Vertical"); 

        transform.Translate(Vector3.right * horizontalInput * _speed * Time.deltaTime);
        transform.Translate(Vector3.up * verticalInput * _speed * Time.deltaTime);
       
        //limita el movimiento del personaje

        if (transform.position.y > 4.47f)
        {
            transform.position = new Vector3(transform.position.x, 4.47f, 0);           
        }
        else if (transform.position.y < -4.47f)
        {
            transform.position = new Vector3(transform.position.x, -4.47f, 0);
        }

        if (transform.position.x > 8.38f)
        {
            transform.position = new Vector3(8.38f, transform.position.y, 0);
        }
        else if (transform.position.x < -8.38f)
        {
            transform.position = new Vector3(-8.38f, transform.position.y, 0);
        }
    }
    //private void Movement()
    //{

    //    if (Input.GetKey(KeyCode.Keypad4)||Input.GetKey(KeyCode.LeftArrow))
    //    {
    //        transform.Translate(Vector3.left * _speed * Time.deltaTime);
    //    }

    //    else if (Input.GetKey(KeyCode.Keypad6) || Input.GetKey(KeyCode.RightArrow))
    //    {
    //        transform.Translate(Vector3.right * _speed * Time.deltaTime);
    //    }

    //    if (Input.GetKey(KeyCode.Keypad8) || Input.GetKey(KeyCode.UpArrow))
    //    {
    //        transform.Translate(Vector3.up * _speed * Time.deltaTime);
    //    }

    //    else if (Input.GetKey(KeyCode.Keypad5) || Input.GetKey(KeyCode.LeftArrow))
    //    {
    //        transform.Translate(Vector3.down * _speed * Time.deltaTime);
    //    }

    //    //limita el movimiento de la nave
    //    if (transform.position.y > 4.47f)
    //    {
    //        transform.position = new Vector3(transform.position.x, 4.47f, 0);
    //    }
    //    else if (transform.position.y < -4.47f)
    //    {
    //        transform.position = new Vector3(transform.position.x, -4.47f, 0);
    //    }

    //    if (transform.position.x > 8.38f)
    //    {
    //        transform.position = new Vector3(8.38f, transform.position.y, 0);
    //    }
    //    else if (transform.position.x < -8.38f)
    //    {
    //        transform.position = new Vector3(-8.38f, transform.position.y, 0);
    //    }
    //}
}
