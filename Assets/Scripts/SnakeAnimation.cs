using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnakeAnimation : MonoBehaviour
{
    private Animator _anim;
    private EnemyAI _EnemyAI;

    // Use this for initialization
    public int facing = 0;
    void Start()
    {
        _anim = GetComponent<Animator>();
        _EnemyAI = GetComponent<EnemyAI>();

    }

    // Update is called once per frame
    void Update ()
    {
        if (_EnemyAI._movSnake == 1)
        {            
            _anim.SetBool("goingLeft", true);
            _anim.SetBool("goingRight", false);
        }
        else if (_EnemyAI._movSnake == 2)
        {            
            _anim.SetBool("goingRight", true);
            _anim.SetBool("goingLeft", false);
        }
    }
}
