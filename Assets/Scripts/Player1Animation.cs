using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player1Animation : MonoBehaviour
{
    private Animator _anim;
    // Use this for initialization
  //  public int facing = 0;
    void Start()
    {
        _anim = GetComponent<Animator>();        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow))
        {
            _anim.SetBool("Turn_Left", true);
            _anim.SetBool("Turn_Right", false);
            _anim.SetBool("Turn_Down", false); //
            _anim.SetBool("Turn_Up", false); //
        }

        else if (Input.GetKeyUp(KeyCode.A) || Input.GetKeyUp(KeyCode.LeftArrow))
        {
            _anim.SetBool("Turn_Left", false);
            _anim.SetBool("Turn_Right", false);
            _anim.SetBool("Turn_Down", false); //
            _anim.SetBool("Turn_Up", false); //
        }

        if (Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow))
        {
            _anim.SetBool("Turn_Right", true);         
            _anim.SetBool("Turn_Left", false);
            _anim.SetBool("Turn_Down", false);//
            _anim.SetBool("Turn_Up", false); //
        }

        else if (Input.GetKeyUp(KeyCode.D) || Input.GetKeyUp(KeyCode.RightArrow))
        {
            _anim.SetBool("Turn_Right", false);
            _anim.SetBool("Turn_Left", false);
            _anim.SetBool("Turn_Down", false);//
            _anim.SetBool("Turn_Up", false);//
        }

        if (Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.DownArrow))
        {
            _anim.SetBool("Turn_Down", true);
            _anim.SetBool("Turn_Up", false);
        }

        else if (Input.GetKeyUp(KeyCode.S) || Input.GetKeyUp(KeyCode.DownArrow))
        {
            _anim.SetBool("Turn_Down", false);
            _anim.SetBool("Turn_Up", false);
        }

        if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow))
        {
            _anim.SetBool("Turn_Down", false);
            _anim.SetBool("Turn_Up", true);
        }

        else if (Input.GetKeyUp(KeyCode.W) || Input.GetKeyUp(KeyCode.UpArrow))
        {
            _anim.SetBool("Turn_Down", false);
            _anim.SetBool("Turn_Up", false);
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            _anim.SetTrigger("Attack2");
        }
    }
}
