using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Assets.Scripts.Classes;

public class GameplayManager : MonoBehaviour
{
    private float deadValue;
    private ArrayList enemies;
    private ArrayList humans;
    
    [SerializeField]
    private GameObject mainPlayer;
    [SerializeField]
    private Transform mainPlayerTransform;
    private Rigidbody2D mainPlayerRigidbody;

    public Transform enemyPrefab;

    private bool isPaused;

    // Singleton
    private GameplayManager instance = null;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else if (instance != this)
        {
            Destroy(gameObject);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        deadValue = 0.9f;
        enemies = new ArrayList();
        humans = new ArrayList();

        //mainPlayer = GameObject.Find("Player");
        mainPlayer = mainPlayerTransform.gameObject;
        mainPlayerRigidbody = mainPlayer.GetComponent<Rigidbody2D>();
        Debug.Log(mainPlayer.name);

        // Instantiate(enemyPrefab, new Vector2(-8, 5), Quaternion.identity);

        FindCharacters();

        Debug.Log("Pause() : Paused == " + isPaused);
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetAxis("Pause") > deadValue)
        {
            isPaused = !isPaused;

            /* if (isPaused)
                Pause();
            else
                Unpause(); */

            // System.Threading.Thread.Sleep(100);

#if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
#else
            // Application.Quit();
#endif
        }
    }

    private void Pause()
    {
        //isPaused = true;
        Debug.Log("Pause() : Paused == " + isPaused);
        mainPlayer.GetComponent<PlayerController>().Pause();

        foreach (GameObject thisHuman in humans)
        {
            // ((GameObject)thisHuman).Pause();
        }

        foreach (GameObject thisEnemy in enemies)
        {
            thisEnemy.GetComponent<EnemyController>().Pause();
        }

        Time.timeScale = 0.0f;
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
    }

    private void Unpause()
    {
       // isPaused = false;
        Debug.Log("Pause() : Paused == " + isPaused);
        Time.timeScale = 1.0f;
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;


        mainPlayer.GetComponent<PlayerController>().Unpause();

        foreach (GameObject thisHuman in humans)
        {
            // ((GameObject)thisHuman).Pause();
        }

        foreach (GameObject thisEnemy in enemies)
        {
            thisEnemy.GetComponent<EnemyController>().Unpause();
        }
    }

    private void FindCharacters()
    {
        // Add the player to humans
        // humans.Add(mainPlayer);
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

    public void PlayerDied()
    {
        // TODO: Implement death
        Pause();
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
