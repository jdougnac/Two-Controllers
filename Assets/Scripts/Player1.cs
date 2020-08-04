using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//<>
public class Player1 : MonoBehaviour
{
    [SerializeField]
    private float _speed;
    [SerializeField]
    private GameObject _attackColliderRight;
    [SerializeField]
    private GameObject _attackColliderLeft;
    [SerializeField]
    private GameObject _attackColliderUp;
    [SerializeField]
    private GameObject _attackColliderDown;
    public UIManager _UIManager;
    private spawnManager _spawnManager;

    [SerializeField]
    private int _lives;
    Animator anim; 
    AnimatorStateInfo animInfo;
    Collider2D rightCollider;
    Collider2D leftCollider;
    Collider2D upCollider;
    Collider2D downCollider;

    // Use this for initialization
    void Start()
    {
        _UIManager = GameObject.Find("Canvas").GetComponent<UIManager>();
        _spawnManager = GameObject.Find("spawnManager").GetComponent<spawnManager>();
        anim = GetComponent<Animator>();
        rightCollider = _attackColliderRight.GetComponent<Collider2D>();
        leftCollider = _attackColliderLeft.GetComponent<Collider2D>();
        upCollider = _attackColliderUp.GetComponent<Collider2D>();
        downCollider = _attackColliderDown.GetComponent<Collider2D>();

        _speed = 10f;
        _lives = 5; //cambiar después
        _UIManager.UpdateLives(_lives);
    }

    // Update is called once per frame
    void Update()
    {
        animInfo = anim.GetCurrentAnimatorStateInfo(0);
        Movement();
        Attack();                
    }


    private void Movement()
    {
        float horizontalInput = Input.GetAxis("Horizontal2"); //cambiar a horizontal y vertical para usar el control de ps4
        float verticalInput = Input.GetAxis("Vertical2");

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

    private void Attack()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (animInfo.IsName("IdleRight")|| animInfo.IsName("WalkRight"))
            {
                rightCollider.enabled = true;          
                StartCoroutine(DisableAttackCollider());
            }
            else if (animInfo.IsName("IdleLeft") || animInfo.IsName("WalkLeft"))
            {
                leftCollider.enabled = true;
                StartCoroutine(DisableAttackCollider());
            }
            else if (animInfo.IsName("IdleUp") || animInfo.IsName("WalkUp"))
            {
                upCollider.enabled = true;
                StartCoroutine(DisableAttackCollider());
            }
            else if (animInfo.IsName("IdleDown") || animInfo.IsName("WalkDown"))
            {
                downCollider.enabled = true;
                StartCoroutine(DisableAttackCollider());
            }
        }

    }
    public IEnumerator DisableAttackCollider()
    {
        yield return new WaitForSeconds(0.5f);
        rightCollider.enabled = false;
        leftCollider.enabled = false;
        upCollider.enabled = false;
        downCollider.enabled = false;
    }

public void Damaged()
    {
        if (_lives > 1 )
        {
            _lives -= 1;
            _UIManager.UpdateLives(_lives);
        }
        else if (_lives <= 1)
        {
            _UIManager.UpdateLives(0);
            _UIManager._gameInProgress = false;
            _spawnManager.checkGame();
            Destroy(this.gameObject);
        }
    }
}



