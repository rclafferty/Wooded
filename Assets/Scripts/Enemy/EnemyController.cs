using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    private GameplayManager gameplayManager;
    private float speed = 5f;
    private Rigidbody2D thisRigidbody;

    // Start is called before the first frame update
    void Start()
    {
        gameplayManager = GameObject.Find("Gameplay Manager").GetComponent<GameplayManager>();
        thisRigidbody = this.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float distanceToPlayer = GetDistance(thisRigidbody.position, gameplayManager.MainPlayerRigidbody.position);
        if (Mathf.Abs(distanceToPlayer) < 30.0f)
        {
            MoveTowardPlayer(distanceToPlayer);
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
}
