/**
 *      Lama Abbas - 251035313
 *      Individual Game Prototype
 *      Pause Menu contains everything required to pause and unpause the game
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour {

    public static bool GameIsPaused = false;
    public GameObject pauseMenuUI;

    // Pausing/resuming the game through the use of the escape key
    private void Update() {
        if (Input.GetKeyDown(KeyCode.Escape)) {
            if (GameIsPaused) {
                Resume();
            } else {
                Pause();
            }
        }
    }

    // Resuming ensures the game returns to normal speed
    public void Resume() {
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        GameIsPaused = false;
    }

    // Pausing ensures the game is frozen and brings up the pause menu
    public void Pause() {
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        GameIsPaused = true;
    }

    // Actions delivered via pause menu
    public void LoadMenu() {
        SceneManager.LoadScene(0);
        Resume();
    }

    public void ExitGame() {
        Application.Quit();
     }
}
