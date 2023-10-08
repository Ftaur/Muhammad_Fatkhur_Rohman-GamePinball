using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenuUIController : MonoBehaviour
{
    public Button playButton;
    public Button creditButton;
    // public Button mainMenuButton;
    public Button exitButton;
    private void Start()
    {
        playButton.onClick.AddListener(PlayGame);
        creditButton.onClick.AddListener(CreditGame);
        // mainMenuButton.onClick.AddListener(MainMenu);
        exitButton.onClick.AddListener(ExitGame);
    }

    public void PlayGame()
    {
        SceneManager.LoadScene("Pinball_Game");
    }

    public void CreditGame()
    {
        SceneManager.LoadScene("CreditsMenu");
    }

    // public void MainMenu()
    // {
    //     // kembali ke main menu
    //     SceneManager.LoadScene("MainMenu");
    // }

    private void ExitGame()
    {
        Application.Quit();
    }
}
