using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Assets.Scripts.Classes;

public class GameplayManager : MonoBehaviour
{
    private float deadValue;
    private ArrayList enemies;
    private ArrayList humans;
    private GameObject mainPlayer;

    private bool isPaused;

    // Start is called before the first frame update
    void Start()
    {
        deadValue = 0.5f;
        enemies = new ArrayList();
        humans = new ArrayList();

        mainPlayer = GameObject.Find("Player");

        FindCharacters();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetAxis("Pause") > deadValue)
        {
            isPaused = !isPaused;
            Pause(isPaused);
        }
    }

    private void Pause(bool p)
    {
        Time.timeScale = 0.0f;
    }

    private void FindCharacters()
    {
        // Add the player to humans
        humans.Add(mainPlayer);

        // Find all humans -- NOT player
        GameObject[] h = GameObject.FindGameObjectsWithTag("Human");
        foreach (GameObject thisHuman in h)
        {
            humans.Add(thisHuman);
        }

        // Find all enemies
        GameObject[] e = GameObject.FindGameObjectsWithTag("Enemy");
        foreach (GameObject thisEnemy in e)
        {
            enemies.Add(thisEnemy);
        }
    }
}
