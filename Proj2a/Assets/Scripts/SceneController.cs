// taken from https://medium.com/@johnathanmiller/scene-based-player-positioning-in-unity-4499f25e0521

using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{
    GameObject enemyGO;
    public static string prevScene = "";
    public static string currentScene = "";

    public void Start()
    {
        currentScene = SceneManager.GetActiveScene().name;
        Debug.Log(currentScene);
    }

    public void LoadNextScene()
    {
        Debug.Log(prevScene);
        prevScene = currentScene;
        //SceneManager.LoadScene(sceneName);
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex + 1);
    }

    private object ActiveScene()
    {
        throw new NotImplementedException();
    }

    public void LoadStartScene()
    {
        SceneManager.LoadScene(0);
    }

    public void OnApplicationQuit()
    {
        Application.Quit();
    }
}