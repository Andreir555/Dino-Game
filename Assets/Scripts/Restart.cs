using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class Restart : MonoBehaviour
{
    public ShowHighscoreOnMainMenu changeTo0;
    private int sceneToContinue;
    public ChangeMuteAndSound scenesettings;
    public ChangeMuteAndSound verifySoundButton;
    public void RestartGame()
    {
        SceneManager.LoadScene("Gameplay");
    }
    public void MainMenu()
    {
        SceneManager.LoadScene("MainMenu");
        if (verifySoundButton.isMuted) verifySoundButton.button.image.sprite = verifySoundButton.newButtonImage;
        else verifySoundButton.button.image.sprite = verifySoundButton.oldButtonImage;
        
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void ClearScore()
    {
        PlayerPrefs.SetFloat("highscore", 0.0f);
        changeTo0.scormare.text = "HIGHSCORE 0!";

    }

}
