using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkeletonAnimation : MonoBehaviour
{
    private Animator _anim;
    private EnemyAI _EnemyAI;
    // Use this for initialization
    void Start()
    {
        _anim = GetComponent<Animator>();
        _EnemyAI = GetComponent<EnemyAI>();

    }

    // Update is called once per frame
    void Update()
    {
        if (_EnemyAI.skeletonFacing == 0)
        {
                _anim.SetBool("Turn_Left", false);
                _anim.SetBool("Turn_Right", true);
                _anim.SetBool("Turn_Up", false);
                _anim.SetBool("Turn_Down", false);
        }

        else if (_EnemyAI.skeletonFacing == 1)
        {
            _anim.SetBool("Turn_Left", false);
            _anim.SetBool("Turn_Right", false);
            _anim.SetBool("Turn_Up", false);
            _anim.SetBool("Turn_Down", true);
        }
        else if (_EnemyAI.skeletonFacing == 2)
        {
            _anim.SetBool("Turn_Left", true);
            _anim.SetBool("Turn_Right", false);
            _anim.SetBool("Turn_Up", false);
            _anim.SetBool("Turn_Down", false);
        }
        else if (_EnemyAI.skeletonFacing == 3)
        {
            _anim.SetBool("Turn_Left", false);
            _anim.SetBool("Turn_Right", false);
            _anim.SetBool("Turn_Up", true);
            _anim.SetBool("Turn_Down", false);
        }
    }
}
