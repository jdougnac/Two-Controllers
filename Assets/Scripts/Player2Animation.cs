using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player2Animation : MonoBehaviour
{
    private Animator _anim;
    // Use this for initialization
    void Start()
    {
        _anim = GetComponent<Animator>();

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Keypad4) || Input.GetKeyDown(KeyCode.LeftArrow))
        {
            _anim.SetBool("Turn_Left", true);
            _anim.SetBool("Turn_Right", false);
        }

        else if (Input.GetKeyUp(KeyCode.Keypad4) || Input.GetKeyUp(KeyCode.LeftArrow))
        {
            _anim.SetBool("Turn_Left", false);
            _anim.SetBool("Turn_Right", false);
        }

        if (Input.GetKeyDown(KeyCode.Keypad6) || Input.GetKeyDown(KeyCode.RightArrow))
        {
            _anim.SetBool("Turn_Right", true);         
            _anim.SetBool("Turn_Left", false);
        }

        else if (Input.GetKeyUp(KeyCode.Keypad6) || Input.GetKeyUp(KeyCode.RightArrow))
        {
            _anim.SetBool("Turn_Right", false);
            _anim.SetBool("Turn_Left", false);
        }

        if (Input.GetKeyDown(KeyCode.Keypad2) || Input.GetKeyDown(KeyCode.DownArrow))
        {
            _anim.SetBool("Turn_Down", true);
            _anim.SetBool("Turn_Up", false);            
        }

        else if (Input.GetKeyUp(KeyCode.Keypad2) || Input.GetKeyUp(KeyCode.DownArrow))
        {
            _anim.SetBool("Turn_Down", false);
            _anim.SetBool("Turn_Up", false);
        }

        if (Input.GetKeyDown(KeyCode.Keypad8) || Input.GetKeyDown(KeyCode.UpArrow))
        {
            _anim.SetBool("Turn_Down", false);
            _anim.SetBool("Turn_Up", true);            
        }

        else if (Input.GetKeyUp(KeyCode.Keypad8) || Input.GetKeyUp(KeyCode.UpArrow))
        {
            _anim.SetBool("Turn_Down", false);
            _anim.SetBool("Turn_Up", false);
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            // _anim.SetBool("Attack", true);
            // _anim.SetBool("Attack", false);
            _anim.SetTrigger("Attack2");
        }
    }
}
