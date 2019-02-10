using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private const float SPEED = 8.0f;
    private Rigidbody2D thisRigidbody;
    private int health;
    private const int MAX_HEALTH = 5;
    private const int MAX_HEALTH_HANDICAP = 10;

    private bool isPaused;

    void Start()
    {
        health = MAX_HEALTH;
        thisRigidbody = GetComponent<Rigidbody2D>();
        isPaused = false;
    }

    void FixedUpdate()
    {
        float hInput = Input.GetAxis("Horizontal");
        float vInput = Input.GetAxis("Vertical");

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

        if (thisRigidbody.position.x < x1 && thisRigidbody.position.x > x2)
        {
            if (thisRigidbody.position.y < y1 && thisRigidbody.position.y > y2)
            {
                thisRigidbody.position = new Vector2(143, 39);
                UnityEngine.SceneManagement.SceneManager.LoadScene("maze");
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
        //Vector2 diffVector = GetNormalizedDifferenceVector(other.GetComponent<Rigidbody2D>().position, thisRigidbody.position);
        //thisRigidbody.position += diffVector;

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