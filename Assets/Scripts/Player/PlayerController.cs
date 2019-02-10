using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private const float SPEED = 8.0f;
    private Rigidbody2D thisRigidbody;
    private int health;
    private const int MAX_HEALTH = 3;
    private const int MAX_HEALTH_CANVAS = 10;
    private float hInput = 0;
    private float vInput = 0;
    private bool attack = false;
    private Animator animator;

    private bool isPaused;

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }

    void Start()
    {
        health = MAX_HEALTH;
        thisRigidbody = GetComponent<Rigidbody2D>();
        isPaused = false;
    }

    private void Update()
    {
        hInput = Input.GetAxis("Horizontal");
        vInput = Input.GetAxis("Vertical");
        attack = Input.GetKeyDown("space");

        if (attack)
        {
            animator.SetTrigger("Attack");
        }
        animator.SetFloat("DownSpeed", vInput);
        animator.SetFloat("RightSpeed", hInput);

    }

    void FixedUpdate()
    {

        if (isPaused)
        {
            thisRigidbody.velocity = Vector2.zero;
        }
        else
        {
            thisRigidbody.velocity = new Vector2(hInput * SPEED, vInput * SPEED);
        }

        int x1 = 305;
        int x2 = 300;
        int y1 = 21;
        int y2 = 16;

        int x4 = -95;
        int x5 = -104;
        int y4 = 4;
        int y5 = -8;

        if (thisRigidbody.position.x < x1 && thisRigidbody.position.x > x2)
        {
            if (thisRigidbody.position.y < y1 && thisRigidbody.position.y > y2)
            {

                if (UnityEngine.SceneManagement.SceneManager.GetActiveScene().name == "forest")
                {
                    thisRigidbody.position = new Vector2(143, 39);
                    UnityEngine.SceneManagement.SceneManager.LoadScene("maze");
                }
            }
        }

        if (thisRigidbody.position.x < x4 && thisRigidbody.position.x > x5)
        {
            if (thisRigidbody.position.y < y4 && thisRigidbody.position.y > y5)
            {

                if (UnityEngine.SceneManagement.SceneManager.GetActiveScene().name == "maze")
                {
                    thisRigidbody.position = new Vector2(143, 39);
                    UnityEngine.SceneManagement.SceneManager.LoadScene("end");
                }
            }
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
    
    public void Hit(GameObject other)
    { 
        Hit(other, 1);
    }

    public void Hit(GameObject other, int h)
    {
        Vector2 diffVector = GetNormalizedDifferenceVector(other.GetComponent<Rigidbody2D>().position, thisRigidbody.position);
        thisRigidbody.position += diffVector;

        health -= h;

        if (health <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        GameObject.Find("Gameplay Manager").GetComponent<GameplayManager>().PlayerDied();
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