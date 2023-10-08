using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameOverUIController : MonoBehaviour
{
    // reference untuk button
    public Button mainMenuButton;
    public GameObject gameOverCanvas;
    private void Start()
    {
        gameOverCanvas.SetActive(false);
        // setup event saat button di klik
        mainMenuButton.onClick.AddListener(MainMenu);
    }

    public void MainMenu()
    {
        // kembali ke main menu
        SceneManager.LoadScene("MainMenu");
    }
}
