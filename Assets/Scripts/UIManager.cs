using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [SerializeField]
    private GameObject _player1;
    [SerializeField]
    private GameObject _player2;
    public int Score;
    public Text scoreText;
    [SerializeField]
    private Sprite[] lives;
    public Image livesImageDisplay;
    public Image gameScreen;
    public bool _gameInProgress;
    private spawnManager _spawnManager;

    // Use this for initialization
    void Start ()
    {
        _spawnManager = GameObject.Find("spawnManager").GetComponent<spawnManager>();
        scoreText.text = "0";
        _gameInProgress = false;
	}
	
	// Update is called once per frame
	void Update ()
    {
        StartGame();

    }

    public void UpdateScore(int points)
    {
        Score += points;
        scoreText.text = "Score: " + Score;
    }
    public void UpdateLives(int currentLives)
    {
        livesImageDisplay.sprite = lives[currentLives];
    }

    void StartGame()
    {
        if (Input.GetKeyDown(KeyCode.Space) && _gameInProgress == false)
        {            
            _gameInProgress = true;
            gameScreen.enabled = false;
            Score = 0;
            scoreText.text = "aa"+Score;
            Instantiate(_player1, new Vector3(Random.Range(-10f, 10f), -3.5f, 0), Quaternion.identity);
            Instantiate(_player2, new Vector3(Random.Range(-10f, 10f), -3.5f, 0), Quaternion.identity);
            _spawnManager.checkGame();
        }
        // si space presionado y game in progress es falso.
        
        // aparecen jugador 1 y jugador 2
        //spawnmanager hace checkgame
    }

    void EndGame()
    {
        //hace aparecer nuevamente la imagen inicial
        //score vuelve a 0
        // game in progress es falso, spawnmanager hace checkgame
    }
}
