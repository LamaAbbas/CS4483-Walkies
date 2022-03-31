using UnityEngine.SceneManagement;
using UnityEngine;
using TMPro;

public class GameOver : MonoBehaviour {

    [SerializeField] private TextMeshProUGUI score;

    private void Start() {
        score.text = ((int)GameMenuManager.score).ToString();
    }

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
