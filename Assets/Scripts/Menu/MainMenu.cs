/**
 *      Lama Abbas - 251035313
 *      Individual Game Prototype
 *      Main menu class adds functionality to menu buttons
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour {
   
    public void PlayGame() {
        SceneManager.LoadScene(1);
    }

    public void ExitGame() {
        Application.Quit();
    }
}
