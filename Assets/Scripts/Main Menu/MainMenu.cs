using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    private void Awake()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Confined;
    }

    void Start()
    {
        
    }

    public void StartGame()
    {
        SceneManager.LoadScene("DungeonScene");
    }

    public void QuitToDesktop()
    {
        Application.Quit();
    }
}
