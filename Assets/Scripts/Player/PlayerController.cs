using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private GameplayManager gameplayManager;
    private float deadValue;
    // Editable from Unity Editor (needs to be initialzed directly);
    [SerializeField]
    private float speed = 5f;

    private Rigidbody2D thisRigidBody;

    // Start is called before the first frame update
    void Start()
    {
        thisRigidBody = GetComponent<Rigidbody2D>();
        gameplayManager = GameObject.Find("Gameplay Manager").GetComponent<GameplayManager>();
        deadValue = gameplayManager.DeadValue;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float hInput = Input.GetAxis("Horizontal");
        float vInput = Input.GetAxis("Vertical");

        if(Mathf.Abs(hInput) > deadValue || Mathf.Abs(vInput) > deadValue)
        {
            thisRigidBody.velocity = new Vector2(hInput * speed, vInput * speed);

            // MoveLeft(x, y) --> Move diagonally with left animation

            // MoveRight(x, y)

            // ...
        }
    }
}
