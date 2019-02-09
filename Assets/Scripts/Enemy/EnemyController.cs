using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    private GameplayManager gameplayManager;
    private float speed = 5f;
    private Rigidbody2D thisRigidbody;
    private float playerDistanceThreshold;

    bool isPaused;

    // Start is called before the first frame update
    void Start()
    {
        gameplayManager = GameObject.Find("Gameplay Manager").GetComponent<GameplayManager>();
        thisRigidbody = this.GetComponent<Rigidbody2D>();
        playerDistanceThreshold = 10.0f;

        isPaused = false;
    }

    [SerializeField]
    float distanceToPlayer;

    // Update is called once per frame
    void FixedUpdate()
    {
        if (!isPaused)
        {
            distanceToPlayer = GetDistance(thisRigidbody.position, gameplayManager.MainPlayerRigidbody.position);
        }
        else
        {
            distanceToPlayer = 0;
        }

        if (Mathf.Abs(distanceToPlayer) < playerDistanceThreshold && Mathf.Abs(distanceToPlayer) > 1.0f)
        {
            MoveTowardPlayer(distanceToPlayer * Time.fixedDeltaTime);
        }
        else
        {
            thisRigidbody.velocity = Vector2.zero;
        }
    }

    private void MoveTowardPlayer(float d)
    {
        Vector2 v = GetNormalizedDifferenceVector(gameplayManager.MainPlayerRigidbody.position, thisRigidbody.position);
        thisRigidbody.position += v * speed * Time.deltaTime;
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
        //Vector2 v = (v1 - v2);
        Vector2 v = new Vector2();
        v.x = v1.x - v2.x;
        v.y = v1.y - v2.y;
        return v;
    }

    private Vector2 GetNormalizedDifferenceVector(Vector2 v1, Vector2 v2)
    {
        Vector2 v = GetDifferenceVector(v1, v2);
        // v.Normalize();
        return v.normalized;
    }

    // Getter / Setter Methods

    public GameplayManager SceneGameplayManager
    {
        set
        {
            gameplayManager = value;
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
