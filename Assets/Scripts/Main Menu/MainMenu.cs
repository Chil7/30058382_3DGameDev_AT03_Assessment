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

    public void StartGame()
    {
        Cursor.visible = false;
        SceneManager.LoadScene("DungeonScene");
    }

    public void QuitToDesktop()
    {
        Application.Quit();
    }
}
