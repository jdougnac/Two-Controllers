using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectAI : MonoBehaviour
{
    [SerializeField]
    private bool _isCoin;
    [SerializeField]
    private bool _isMeteor;
    [SerializeField]
    private float _Speed;
    private int _scoreValue;
    public UIManager _UIManager;
	// Use this for initialization
	void Start ()
    {
        _UIManager = GameObject.Find("Canvas").GetComponent<UIManager>();
        _Speed = 1.5f;	 
        if (_isCoin == true)
        {
            _scoreValue = 4;
        }
        else if (_isMeteor == true)
        {
            _scoreValue = 3;
        }
	}	
	// Update is called once per frame
	void Update ()
    {
        transform.Translate(Vector3.down * _Speed * Time.deltaTime);
        if (transform.position.y < -5.5f)
        {
            float randomX = Random.Range(-8.48f, 8.48f);
            transform.position = new Vector3(randomX, 11.5f, 0);
        }
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player1" && _isCoin == true)
        {
            
          //  Player1 player = other.GetComponent<Player1>();
            _UIManager.UpdateScore(_scoreValue);
            Destroy(this.gameObject);
        }

        else if (other.tag == "Player1" && _isMeteor == true)
        {
            Player1 player = other.GetComponent<Player1>();
            player.Damaged();
            Destroy(this.gameObject);
        }
        else if (other.tag == "Player2" && _isMeteor == true)
        {
          //  Player2 player = other.GetComponent<Player2>();
            _UIManager.UpdateScore(_scoreValue);
            Destroy(this.gameObject);
        }

        else if (other.tag == "Player2" && _isCoin == true)
        {
         //   Player2 player = other.GetComponent<Player2>();
            Destroy(this.gameObject);
        }
    }
}

