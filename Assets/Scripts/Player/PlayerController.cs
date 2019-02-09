using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // Editable from Unity Editor (needs to be initialzed directly);
    private GameplayManager gameplayManager;
    private float speed = 8f;
    private Rigidbody2D thisRigidbody;

    // Start is called before the first frame update
    void Start()
    {

        thisRigidbody = this.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float hInput = Input.GetAxis("Horizontal");
        float vInput = Input.GetAxis("Vertical");

        if(Mathf.Abs(hInput) > gameplayManager.DeadValue || Mathf.Abs(vInput) > gameplayManager.DeadValue)
        {
            thisRigidbody.velocity = new Vector2(hInput * speed, vInput * speed);

            // MoveLeft(x, y) --> Move diagonally with left animation

            // MoveRight(x, y)

            // ...
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
}
