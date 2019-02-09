using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Assets.Scripts.Classes;

public class GameplayManager : MonoBehaviour
{
    private float deadValue;
    private ArrayList enemies;
    private ArrayList humans;
    
    private GameObject mainPlayer;
    private Rigidbody2D mainPlayerRigidbody;

    public Transform enemyPrefab;

    private bool isPaused;

    // Start is called before the first frame update
    void Start()
    {
        deadValue = 0.5f;
        enemies = new ArrayList();
        humans = new ArrayList();

        mainPlayer = GameObject.Find("Player");
        mainPlayerRigidbody = mainPlayer.GetComponent<Rigidbody2D>();
        Debug.Log(mainPlayer.name);

        Instantiate(enemyPrefab, new Vector2(-8, 5), Quaternion.identity);

        FindCharacters();
        Unpause();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetAxis("Pause") > deadValue)
        {
            isPaused = !isPaused;

            if (isPaused)
                Pause();
            else
                Unpause();
        }
    }

    private void Pause()
    {
        Time.timeScale = 0.0f;
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
    }

    private void Unpause()
    {
        Time.timeScale = 1.0f;
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    private void FindCharacters()
    {
        // Add the player to humans
        humans.Add(mainPlayer);
        mainPlayer.GetComponent<PlayerController>().SceneGameplayManager = this;

        // Find all humans -- NOT player
        /* GameObject[] h = GameObject.FindGameObjectsWithTag("Human");
        foreach (GameObject thisHuman in h)
        {
            humans.Add(thisHuman);
        }*/

        // Find all enemies
        GameObject[] e = GameObject.FindGameObjectsWithTag("Enemy");
        foreach (GameObject thisEnemy in e)
        {
            enemies.Add(thisEnemy);
            thisEnemy.GetComponent<EnemyController>().SceneGameplayManager = this;
        }
    }

    // Getter/Setter methods
    public float DeadValue
    {
        get
        {
            return deadValue;
        }
    }

    public GameObject MainPlayer
    {
        get
        {
            return mainPlayer;
        }
    }

    public Rigidbody2D MainPlayerRigidbody
    {
        get
        {
            return mainPlayerRigidbody;
        }
    }

    public ArrayList Enemies
    {
        get
        {
            return enemies;
        }
    }

    public ArrayList Humans
    {
        get
        {
            return humans;
        }
    }
}
