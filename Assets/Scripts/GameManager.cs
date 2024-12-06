using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private bool isGamePaused = false;

    // Method to toggle game pause state
    public void PauseGame()
    {
        if (isGamePaused)
        {
            // Resume the game
            Time.timeScale = 1;
            isGamePaused = false;
        }
        else
        {
            // Pause the game
            Time.timeScale = 0;
            isGamePaused = true;
        }
    }
}
