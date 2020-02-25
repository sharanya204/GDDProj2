using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance = null;

    #region Unity_functions

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != this)
        {
            Destroy(this.gameObject);
        }

        DontDestroyOnLoad(gameObject);
    }
    #endregion

    #region scene_transitions

    public void StartGame()
    {
        Debug.Log("button");
        SceneManager.LoadScene("Level1");
    }

    public void WinGame()
    {
        SceneManager.LoadScene("WinScene");
    }

    public void LoseGame()
    {
        SceneManager.LoadScene("LoseScene");
        Debug.Log("LoseScene");
    }

    public void GoToMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
    #endregion

}
