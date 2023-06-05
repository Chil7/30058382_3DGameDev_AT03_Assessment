using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] private Area[] areas;
    [SerializeField] private Player player;

    [SerializeField] private GameObject victoryPanel;
    [SerializeField] private GameObject gameOverPanel;

    public Area[] Areas { get { return areas; } }
    
    public static GameManager Instance { get; private set; }

    private void Awake()
    {
        Cursor.visible = false;
    }

    // Start is called before the first frame update
    void Start()
    {
        if(Instance == null)
        {
            Instance = this;
        }

        if (gameOverPanel != null)
        {
            if (gameOverPanel.activeSelf == true)
            {
                gameOverPanel.SetActive(false);
            }
        }
        else
        {
            Debug.LogError("It neds a Gameover Panel");
        }

        if (victoryPanel != null)
        {
            if (victoryPanel.activeSelf == true)
            {
                victoryPanel.SetActive(false);
            }
        }
        else
        {
            Debug.LogError("It neds a VictoryPanel");
        }

        FindObjectOfType<Enemy>().GameOverEvent += GameOver;
        FindObjectOfType<GameEnd>().GameWinEvent += Victory;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }
    }

    //Disables the player and pops out the option if player wants to restart or go to main menu
    private void GameOver()
    {
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.Confined;
        gameOverPanel.SetActive(true);
        player.enabled = false;
    }

    private void Victory()
    {
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.Confined;
        victoryPanel.SetActive(true);
        player.enabled = false;
    }
}
