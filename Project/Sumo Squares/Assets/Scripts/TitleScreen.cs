using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class TitleScreen : MonoBehaviour {
    public Button PlayButton, ExitButton, HelpButton;

    public void PlayGame()
    {
        PlayButton.GetComponent<AudioSource>().Play();
        Invoke("LoadRoundSelect", PlayButton.GetComponent<AudioSource>().clip.length);
    }

    public void LoadHelp()
    {
        PlayButton.GetComponent<AudioSource>().Play();
        Invoke("LoadHelpScreen", PlayButton.GetComponent<AudioSource>().clip.length);
    }

    public void ExitGame()
    {
        PlayButton.GetComponent<AudioSource>().Play();
        Invoke("Exit", PlayButton.GetComponent<AudioSource>().clip.length);
    }

    private void LoadRoundSelect()
    {
        SceneManager.LoadScene("RoundSelect");
    }
    
    private void LoadHelpScreen()
    {
        SceneManager.LoadScene("TutorialScene");
    }

    private void Exit()
    {
        Application.Quit();
    }
}
