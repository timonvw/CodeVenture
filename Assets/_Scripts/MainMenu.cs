using System.Collections;
using System.Collections.Generic;
using CodeVenture;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void Awake()
    {
        MusicManager.Instance.SetMenuMusic();
    }

    public void ExitGame()
    {
        Application.Quit();
        MusicManager.Instance.PlayButtonClick();
    }

    public void PlayGame()
    {
        SceneManager.LoadSceneAsync(2);
        MusicManager.Instance.PlayButtonClick();
    }
}
