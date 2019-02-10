using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NextScene : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Collided with scene transitioner");
        GameObject.Find("Player").GetComponent<PlayerController>().GetComponent<Rigidbody2D>().position = new Vector2(143, 39);
        UnityEngine.SceneManagement.SceneManager.LoadScene("maze");
    }
}
