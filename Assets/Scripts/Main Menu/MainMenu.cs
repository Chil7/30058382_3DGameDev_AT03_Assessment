using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    private void Awake()
    {
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.Confined;
    }

    void Start()
    {
        
    }

    public void StartGame()
    {
        SceneManager.LoadScene("GameScene");
    }

    public void QuitToDesktop()
    {
        Application.Quit();
    }
}
