using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//<>
public class EnemyAI : MonoBehaviour
{
    [SerializeField]
    private bool _isSkeleton;

    [SerializeField]
    private bool _isBlob;

    [SerializeField]
    private bool _isSnake;

    [SerializeField]
    private int _lives;

    private float latestDirectionChangeTime;
    private readonly float directionChangeTime = 3f;
    [SerializeField]
    private float _speed;
    private Vector2 movementDirection;
    private Vector2 movementPerSecond;
    public int _movSnake;
    private int _movSkeleton;
    public int skeletonFacing;
    private bool _arrived;
    private int _scoreValue;
    private UIManager _UIManager;


    void Start()
    {
        _UIManager = GameObject.Find("Canvas").GetComponent<UIManager>();
        _arrived = false;
        if (_isBlob == true)
        {
            _lives = 1;
            _scoreValue = 10;
            latestDirectionChangeTime = 0f;
            calculateVectorBlob();
        }
        else if (_isSnake == true)
        {
            _movSnake = Random.Range(1, 3);
            _lives = 1;
            _scoreValue = 5;
        }
        else if (_isSkeleton == true)
        {
            _lives = 1;
            _scoreValue = 20;
            _movSkeleton = Random.Range(0, 2);
        }

    }

    void Update()
    {

        if (_isBlob == true)
        {
            blobMovement();
        }

        else if (_isSnake == true)
        {
            snakeMovement();     
        }
        else if (_isSkeleton == true)
        {
            skeletonMovement();
        }

    }    

    void calculateVectorBlob()
    {
        //create a random direction vector with the magnitude of 1, later multiply it with the velocity of the enemy
        //movementDirection = new Vector2(Random.Range(-1.0f, 1.0f), Random.Range(-1.0f, 1.0f)).normalized;
        int randomMove = Random.Range(0, 5); //cambiar a 0, 5
        if (randomMove == 0) //derecha
        {
            movementDirection = new Vector2(1, 0).normalized;
        }

        else if (randomMove == 1) //abajo
        {
            movementDirection = new Vector2(0, -1).normalized;
        }

        else if (randomMove == 2) //izquierda
        {
            movementDirection = new Vector2(-1, 0).normalized;
        }
        else if (randomMove == 3) //arriba
        {
            movementDirection = new Vector2(0, 1).normalized;
        }
        else if (randomMove == 4) //nada
        {
            movementDirection = new Vector2(0, 0).normalized;
        }

        movementPerSecond = movementDirection * _speed;
    }


    private void OnTriggerEnter2D(Collider2D other)
    {        
        if (other.tag == "Player1")
        {
            Player1 player = other.GetComponent<Player1>();
            if (player != null)
            {
                player.Damaged();             
            }            
        }

        else if (other.tag == "attack")
        {
            hasBeenStruck(other.name);
            Damage();
        }
    }

    void snakeMovement()
    {
        if (_movSnake == 1)
        {
            //mover hacia la izquierda
            transform.position = new Vector2(transform.position.x + (_speed *-1* Time.deltaTime), transform.position.y);                       
        }
        else if (_movSnake == 2)
        {
            //mover hacia la derecha
            transform.position = new Vector2(transform.position.x + (_speed * Time.deltaTime),transform.position.y);
        }
        continuingHorizontalBorders();
        fixedVerticalBorders();
    }

    void blobMovement()
    { 
        //if the changeTime was reached, calculate a new movement vector
        if (Time.time - latestDirectionChangeTime > directionChangeTime)
        {
            latestDirectionChangeTime = Time.time;
            calculateVectorBlob();
        }

        //move enemy: 
        transform.position = new Vector2(transform.position.x + (movementPerSecond.x * Time.deltaTime), transform.position.y + (movementPerSecond.y * Time.deltaTime));
        continuingHorizontalBorders();
        continuingVerticalBorders();

    }

    void skeletonMovement()
    {

        if (_movSkeleton == 0)
        {
            if (GameObject.FindGameObjectWithTag("Player1").transform.position.x < transform.position.x && (Mathf.Abs(GameObject.FindGameObjectWithTag("Player1").transform.position.x - transform.position.x)) > 0.1f)
            {
                transform.Translate(Vector3.left * _speed * Time.deltaTime);
                skeletonFacing = 2;
            }
            else if (GameObject.FindGameObjectWithTag("Player1").transform.position.x > transform.position.x && (Mathf.Abs(GameObject.FindGameObjectWithTag("Player1").transform.position.x - transform.position.x)) > 0.1f)
            {
                transform.Translate(Vector3.right * _speed * Time.deltaTime);
                skeletonFacing = 0;
            }

            else
            {
                if (GameObject.FindGameObjectWithTag("Player1").transform.position.y < transform.position.y && (Mathf.Abs(GameObject.FindGameObjectWithTag("Player1").transform.position.y - transform.position.y)) > 0.1f)
                {
                    transform.Translate(Vector3.down * _speed * Time.deltaTime);
                    skeletonFacing = 1;
                }
                else if (GameObject.FindGameObjectWithTag("Player1").transform.position.y > transform.position.y && (Mathf.Abs(GameObject.FindGameObjectWithTag("Player1").transform.position.y - transform.position.y)) > 0.1f)
                {
                    transform.Translate(Vector3.up * _speed * Time.deltaTime);
                    skeletonFacing = 3;
                }
            }
        }

        else if (_movSkeleton == 1)
        {
            if (GameObject.FindGameObjectWithTag("Player1").transform.position.y < transform.position.y && (Mathf.Abs(GameObject.FindGameObjectWithTag("Player1").transform.position.y - transform.position.y)) > 0.1f)
            {
                transform.Translate(Vector3.down * _speed * Time.deltaTime);
                skeletonFacing = 1;
            }
            else if (GameObject.FindGameObjectWithTag("Player1").transform.position.y > transform.position.y && (Mathf.Abs(GameObject.FindGameObjectWithTag("Player1").transform.position.y - transform.position.y)) > 0.1f)
            {
                transform.Translate(Vector3.up * _speed * Time.deltaTime);
                skeletonFacing = 3;
            }

            else
            {
            if (GameObject.FindGameObjectWithTag("Player1").transform.position.x < transform.position.x && (Mathf.Abs(GameObject.FindGameObjectWithTag("Player1").transform.position.x - transform.position.x)) > 0.1f)
            {
                transform.Translate(Vector3.left * _speed * Time.deltaTime);
                skeletonFacing = 2;
            }
            else if (GameObject.FindGameObjectWithTag("Player1").transform.position.x > transform.position.x && (Mathf.Abs(GameObject.FindGameObjectWithTag("Player1").transform.position.x - transform.position.x)) > 0.1f)
            {
                transform.Translate(Vector3.right * _speed * Time.deltaTime);
                skeletonFacing = 0;
            }
            }
        }
    }

    void continuingHorizontalBorders()
    {
        if (transform.position.x > 9.3f)
        {
            transform.position = new Vector3(-9.29f, transform.position.y, 0);
        }
        else if (transform.position.x < -9.3f)
        {
            transform.position = new Vector3(9.29f, transform.position.y, 0);
        }
    }

    void continuingVerticalBorders()
    {
        if (transform.position.y > 5.4f)
        {
            transform.position = new Vector3(transform.position.x, -5.3f, 0);
        }

        else if (transform.position.y < -5.4f)
        {
            transform.position = new Vector3(transform.position.x, 5.3f, 0);
        }
    }

    void fixedHorizontalBorders()
    {

    } //en caso de que se necesite que los monstruos no pasen el borde de la pantalla

    void fixedVerticalBorders()
    {
        if (transform.position.y > 4.4f)
        {
            transform.position = new Vector2 (transform.position.x, 4.39f);
        }

        else if (transform.position.y < -4.6f)
        {
            transform.position = new Vector2 (transform.position.x, -4.59f);
        }
    }

    void Damage()
    {
        if (_lives > 1)
        {
            _lives -= 1;
        }
        else if (_lives <= 1)
        {
            _UIManager.UpdateScore(_scoreValue);
            Destroy(this.gameObject);
        }
    }

    void hasBeenStruck(string angle) //recordar, una vez que funcione, tirar la función junto con el parámetro del nombre.
    {
        _arrived = false;
        //float step = 5.1f * Time.deltaTime;

        if (angle == "AttackColliderDown")
        {
            float newY = transform.position.y - 3;
            while (_arrived == false)
            {
                transform.Translate(Vector3.down * 1 * Time.deltaTime);
                if (transform.position.y <= newY)
                {
                    _arrived = true;
                }
            }
        }
        else if (angle == "AttackColliderUp")
        {
            float newY = transform.position.y + 3;
            while (_arrived == false)
            {
                transform.Translate(Vector3.up * 1 * Time.deltaTime);
                if (transform.position.y >= newY)
                {
                    _arrived = true;                    
                }
            }
        }
        else if (angle == "AttackColliderRight")
        {
            float newX = transform.position.x + 3;
            while (_arrived == false)
            {
                transform.Translate(Vector3.right * 1 * Time.deltaTime);
                if (transform.position.x >= newX)
                {
                    _arrived = true;                    
                }
            }
        }
        if (angle == "AttackColliderLeft")
        {
            float newX = transform.position.x - 3;
            while (_arrived == false)
            {
                transform.Translate(Vector3.left * 1 * Time.deltaTime);
                if (transform.position.x <= newX)
                {
                    _arrived = true;
                }
            }
        }

    }
}



