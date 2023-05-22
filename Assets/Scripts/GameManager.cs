using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] private Area[] areas;
    [SerializeField] private Player player;

    public Area[] Areas { get { return areas; } }

    public static GameManager Instance { get; private set; }

    // Start is called before the first frame update
    void Start()
    {
        if(Instance == null)
        {
            Instance = this;
        }
        FindObjectOfType<Enemy>().GameOverEvent += GameOver;
    }

    //Disables the player and pops out the option if player wants to restart or go to main menu
    private void GameOver()
    {
        player.enabled = false;
    }

    
}
