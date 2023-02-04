using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartGame : MonoBehaviour
{
    private const string Shooter = "Shooter";

    private void OnGUI()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    public void StartGameButtonClick()
    {
        SceneManager.LoadScene(Shooter);
    }

    public void MainMenuButtonClick()
    {
        SceneManager.LoadScene(0);
    }

    public void ExitButtonClick()
    {
        Application.Quit();
    }
}
