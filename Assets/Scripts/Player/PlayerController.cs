using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private GameplayManager gameplayManager;
    private float deadValue;

    private Rigidbody2D thisRigidbody;

    // Start is called before the first frame update
    void Start()
    {
        thisRigidbody = GetComponent<Rigidbody2D>();
        gameplayManager = GameObject.Find("Gameplay Manager").GetComponent<GameplayManager>();

        deadValue = gameplayManager.DeadValue;
    }

    // Update is called once per frame
    void Update()
    {
        float hInput = Input.GetAxis("Horizontal");
        if (Mathf.Abs(hInput) > deadValue)
        {
            thisRigidbody.velocity = Vector2.right * hInput;
        }

        float vInput = Input.GetAxis("Vertical");
        if (Mathf.Abs(vInput) > deadValue)
        {
            thisRigidbody.velocity = Vector2.up * vInput;
        }
    }
}
