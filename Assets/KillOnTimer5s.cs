using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillOnTimer5s : MonoBehaviour
{
    public GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    private float timer = 20.0f;

    // Update is called once per frame
    void Update()
    {
        timer -= Time.deltaTime;
        if (timer <= 0)
        {
            Destroy(gameObject);
            player.SetActive(true);
        } 


    }
}
