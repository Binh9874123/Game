using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScenesController : MonoBehaviour
{
    private static string previousScene = "MenuScene";

    private void Awake()
    {
        
    }

    public void MoveToGameOverScene()
    {
        previousScene = SceneManager.GetActiveScene().name;
        UnityEngine.SceneManagement.SceneManager.LoadScene("GameOverScene");
    }

    public void MoveToGameScene()
    {
        previousScene = SceneManager.GetActiveScene().name;
        UnityEngine.SceneManagement.SceneManager.LoadScene("GameScene");
    }

    public void MoveToMenuScene()
    {
        previousScene = SceneManager.GetActiveScene().name;
        UnityEngine.SceneManagement.SceneManager.LoadScene("MenuScene");
    }

    public void UniversalBack()         //Function for button "back". Script recognizes previous scene and loads it.
    {
        string temp = previousScene;
        previousScene = SceneManager.GetActiveScene().name;
        UnityEngine.SceneManagement.SceneManager.LoadScene(temp);
    }

    public void ExitApplication()
    {
        Application.Quit();
    }


}
