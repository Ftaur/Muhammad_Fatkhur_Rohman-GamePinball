using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TriggerGameOver : MonoBehaviour
{
    public Collider bola;
    public GameObject gameOverCanvas;
    private void OnTriggerEnter(Collider other)
    {
        if (other == bola)
        {
            // disini game over canvas di aktifkan
            gameOverCanvas.SetActive(true);
        }
    }
}
