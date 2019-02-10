using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameplayManager : MonoBehaviour
{
    private const float DEAD_VALUE = 0.5f;
    private bool isPaused;
    private GameObject mainPlayer;
    private Transform mainPlayerTransform;
    private Rigidbody2D mainPlayerRigidbody;
    public Transform enemyPrefab;

    // Singleton
    private GameplayManager instance = null;

    void Awake()
    {
        if (instance != null)
        {
            Destroy(gameObject);
            return;
        }

        instance = this;
        DontDestroyOnLoad(gameObject);
    }

    void Start()
    {
        isPaused = false;

        mainPlayer = mainPlayerTransform.gameObject;
        mainPlayerRigidbody = mainPlayer.GetComponent<Rigidbody2D>();

        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
        if (Input.GetAxis("Pause") > DEAD_VALUE)
        {
#if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
#else
#endif
        }
    }

    public void PlayerDied()
    {
        Scene activeScene = SceneManager.GetActiveScene();
        int activeSceneIndex = activeScene.buildIndex;
        SceneManager.LoadScene(activeSceneIndex);
    }

    // Getter/Setter methods
    public float DeadValue
    {
        get
        {
            return DEAD_VALUE;
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
}