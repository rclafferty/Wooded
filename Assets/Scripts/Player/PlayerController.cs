using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private GameplayManager gameplayManager;
    private float speed = 8f;
    private Rigidbody2D thisRigidBody;
    private float hInput = 0;
    private float vInput = 0;

    // Start is called before the first frame update
    void Start()
    {
        thisRigidBody = this.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    private void Update()
    {
        hInput = Input.GetAxis("Horizontal");
        vInput = Input.GetAxis("Vertical");
    }

    void FixedUpdate()
    {
        //if(Mathf.Abs(hInput) > 0.5 || Mathf.Abs(vInput) > 0.5)
        //{
            thisRigidBody.velocity = new Vector2(hInput * speed, vInput * speed);

            // MoveLeft(x, y) --> Move diagonally with left animation

            // MoveRight(x, y)

            // ...
        //}
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