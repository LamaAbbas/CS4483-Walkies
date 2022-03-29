using UnityEngine.SceneManagement;
using UnityEngine;

public class GameOver : MonoBehaviour {

    public void MainMenu() {
        SceneManager.LoadScene(0);
    }

    public void TryAgain() {
        SceneManager.LoadScene(1);
    }

    public void ViewLeaderboard() {
        SceneManager.LoadScene(2);
    }
}
