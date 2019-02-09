using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    private GameplayManager gameplayManager;

    private float speed = 8f;
    private Rigidbody2D thisRigidbody;
    private float hInput = 0;
    private float vInput = 0;

    private int health;
    private const int MAX_HEALTH = 3;
    private const int MAX_HEALTH_HANDICAP = 10;

    private bool isPaused;

    // Start is called before the first frame update
    void Start()
    {
        health = MAX_HEALTH;
        thisRigidbody = this.GetComponent<Rigidbody2D>();
        isPaused = false;
    }

    // Update is called once per frame
    private void Update()
    {
        hInput = Input.GetAxis("Horizontal");
        vInput = Input.GetAxis("Vertical");
    }

    void FixedUpdate()
    {
        if (!isPaused)
        {
            thisRigidbody.velocity = new Vector2(hInput * speed, vInput * speed);
        }
        else
        {
            thisRigidbody.velocity = Vector2.zero;
        }
    }

    private float GetDistance(Vector2 t1, Vector2 t2)
    {
        float x1 = t1.x;
        float y1 = t1.y;

        float x2 = t2.x;
        float y2 = t2.y;

        float distance = Mathf.Sqrt(Mathf.Pow(x2 - x1, 2) + Mathf.Pow(y2 - y1, 2));

        return distance;
    }

    private Vector2 GetDifferenceVector(Vector2 v1, Vector2 v2)
    {
        Vector2 v = (v1 - v2);
        return v;
    }

    private Vector2 GetNormalizedDifferenceVector(Vector2 v1, Vector2 v2)
    {
        Vector2 v = GetDifferenceVector(v1, v2);
        v.Normalize();
        return v;
    }

    // Getter / Setter Methods

    public GameplayManager SceneGameplayManager
    {
        set
        {
            gameplayManager = value;
        }
    }

    public void Hit(GameObject other)
    { 
        Hit(other, 1);
    }

    public void Hit(GameObject other, int h)
    {
        Vector2 newPosition = GetDifferenceVector(other.GetComponent<Rigidbody2D>().position, thisRigidbody.position);
        health -= h;

        if (health <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        gameplayManager.PlayerDied();
    }

    public void Pause()
    {
        isPaused = true;
    }

    public void Unpause()
    {
        isPaused = false;
    }
}