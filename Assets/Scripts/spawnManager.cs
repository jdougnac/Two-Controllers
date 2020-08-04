using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//< >
public class spawnManager : MonoBehaviour
{
    [SerializeField]
    public GameObject[] objects;
    public GameObject[] enemies;
    private IEnumerator objectSpawn;
    private IEnumerator enemySpawn;
    private UIManager _uiManager;

    // Use this for initialization
    void Start()
    {
        _uiManager = GameObject.Find("Canvas").GetComponent<UIManager>();
        objectSpawn = spawnObjects();
        enemySpawn = spawnEnemies();
       // StartCoroutine(objectSpawn); // al agregar ui, esto iría dentro de un checkgame, lo que serviría para detener la co rutina tb.
       // StartCoroutine(enemySpawn);
    }

    // Update is called once per frame
    void Update()
    {

    }

    IEnumerator spawnObjects()
    {
        while (true)
        {
            int randomObject = Random.Range(0, 11);
            int randomObject1 = Random.Range(0, 11);
            if (randomObject <= 5)
            {
                Instantiate(objects[0], new Vector3(Random.Range(-8.5f, 8.5f), Random.Range(7f, 8.5f), 0), Quaternion.identity);
            }
            else if (randomObject > 5)
            {
                Instantiate(objects[1], new Vector3(Random.Range(-8.5f, 8.5f), Random.Range(7f, 8.5f), 0), Quaternion.identity);
            }
            if (randomObject1 <= 5)
            {
                Instantiate(objects[0], new Vector3(Random.Range(-8.5f, 8.5f), Random.Range(7f, 8.5f), 0), Quaternion.identity);
            }
            else if (randomObject1 > 5)
            {
                Instantiate(objects[1], new Vector3(Random.Range(-8.5f, 8.5f), Random.Range(7f, 8.5f), 0), Quaternion.identity);
            }
            yield return new WaitForSeconds(1.1f);
        }
    }

    IEnumerator spawnEnemies()
    {
        while (true)
        {
            int randomEnemy = Random.Range(0, 13); //despues cambiar
            if (randomEnemy <= 3)
            {
                Instantiate(enemies[0], new Vector3(-9.4f, Random.Range(5f, 6.5f), 0), Quaternion.identity);
            }
            else if (randomEnemy <= 7)
            {
                Instantiate(enemies[1], new Vector3(9.4f, Random.Range(4.4f, -4.6f), 0), Quaternion.identity);
            }
            else if (randomEnemy <= 12)
            {
                Instantiate(enemies[2], new Vector3(9.4f, Random.Range(4.4f, -4.6f), 0), Quaternion.identity);
            }
            yield return new WaitForSeconds(3.5f);
        }
    }

    public void checkGame()
    {
        if (_uiManager._gameInProgress == true)
        {
            StartCoroutine(enemySpawn);
            StartCoroutine(objectSpawn);
        }
        else if (_uiManager._gameInProgress == false) //this stops all spawning co routines and destroys all enemies and powerups in the screen, as well as the drone
        {
            StopCoroutine(enemySpawn);
            StopCoroutine(objectSpawn);
            List<GameObject> objectsToDestroy = new List<GameObject>(GameObject.FindGameObjectsWithTag("enemy"));
            for (int i = 0; i < objectsToDestroy.Count; i++)
            {
                Destroy(objectsToDestroy[i]);
            }
            List<GameObject> objectsTooDestroy = new List<GameObject>(GameObject.FindGameObjectsWithTag("Player2"));
            for (int i = 0; i < objectsTooDestroy.Count; i++)
            {
                Destroy(objectsTooDestroy[i]);
            }
            List<GameObject> oobjectsTooDestroy = new List<GameObject>(GameObject.FindGameObjectsWithTag("object"));
            for (int i = 0; i < oobjectsTooDestroy.Count; i++)
            {
                Destroy(oobjectsTooDestroy[i]);
            }
            _uiManager.gameScreen.enabled = true;
        }
    }
}
