using UnityEngine.SceneManagement;
using UnityEngine;
using TMPro;

public class GameOver : MonoBehaviour {

    [SerializeField] private TextMeshProUGUI scoreUI;
    public TMP_InputField inputNameUI;
    private string nameSubstring;
    private int score; 

    private void Start() {
        score = (int)GameMenuManager.score;
        scoreUI.text = score.ToString();
    }

    public void MainMenu() {
        SceneManager.LoadScene(0);
    }

    public void TryAgain() {
        SceneManager.LoadScene(1);
    }

    public void ViewLeaderboard() {
        if (inputNameUI.text != "") {
            if (inputNameUI.text.Length > 6) {
                nameSubstring = inputNameUI.text.Substring(0, 6);
            } else {
                nameSubstring = inputNameUI.text;
            }
            ScoreData.storeHighScore(nameSubstring, score);
        }
        SceneManager.LoadScene(2);
    }
}
