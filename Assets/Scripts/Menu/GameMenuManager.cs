/**
 *      Lama Abbas - 251035313
 *      Individual Game Prototype
 *      Pause Menu contains everything required to pause and unpause the game
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameMenuManager : MonoBehaviour {

    public static bool GameIsPaused = false;
    public GameObject pauseMenuUI;
    public TextMeshProUGUI scoreUI;
    public TMP_InputField inputNameUI;
    private string nameSubstring;

    public static float score;

    public float scoreModifier = 1;
    private void Start()
    {
        score = 0;
        scoreUI.text = $"Score: {score}";
    }

    // Pausing/resuming the game through the use of the escape key
    private void Update() {
        if (Input.GetKeyDown(KeyCode.Escape)) {
            if (GameIsPaused) {
                Resume();
            } else {
                Pause();
            }
        }
        score += Time.deltaTime * 10 * scoreModifier;
        scoreUI.text = $"Score: {(int)score}";
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
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#endif
    }

    // TODO: Make the player lose
    // At the momment no name means don't save
    public void EndGame()
    {
        if (inputNameUI.text != "")
        {
            if (inputNameUI.text.Length > 6) {
                nameSubstring = inputNameUI.text.Substring(0, 6);
            } else {
                nameSubstring = inputNameUI.text;
            }
            ScoreData.storeHighScore(nameSubstring, (int)score);
        }
        SceneManager.LoadScene(2);
        Resume();
    }

}
