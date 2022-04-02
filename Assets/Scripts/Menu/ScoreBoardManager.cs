/**
 * Tom Lu
 * Group Game Demo
 * Handles saving data into binary file for leaderboard
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using TMPro;
using System;
using UnityEngine.SceneManagement;

[System.Serializable]
public struct LeaderBoardEntry {
    public LeaderBoardEntry(string name, int score) {
        this.name = name;
        this.score = score;
    }
    public string name;
    public int score;
}

public static class ScoreData {
    static string path = Application.persistentDataPath + "/leaderBoard.fun";
    public static void storeHighScore(string name, int score) {
        List<LeaderBoardEntry> data = getHighScoreData();
        if (data == null) {
            data = new List<LeaderBoardEntry>();
        }
        data.Add(new LeaderBoardEntry(name, score));
        FileStream stream = new FileStream(path, FileMode.Create);
        BinaryFormatter formatter = new BinaryFormatter();
        formatter.Serialize(stream, data);
        stream.Close();
    }

    public static List<LeaderBoardEntry> getHighScoreData() {
        if (File.Exists(path)) {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);

            List<LeaderBoardEntry> data = formatter.Deserialize(stream) as List<LeaderBoardEntry>;
            stream.Close();

            return data;
        }
        else {
            return null;
        }
    }

    public static void removeData() {
        File.Delete(path);
    }

}


public class ScoreBoardManager : MonoBehaviour {

    public TextMeshProUGUI scoreNames;
    public TextMeshProUGUI scoreNums;

    void Start() {
        scoreNames.text = "";
        scoreNums.text = "";
        List<LeaderBoardEntry> data = ScoreData.getHighScoreData();
        if (data == null) {
            scoreNames.text = "---";
            scoreNums.text = "---";
            return;
        }
        data.Sort((item1, item2) => item2.score - item1.score);
        for (int i = 0; i < 5; i++) {
            try {
                scoreNames.text = $"{scoreNames.text}{data[i].name} \n";
                scoreNums.text = $"{scoreNums.text}{data[i].score} \n";
            } catch (Exception) {
                break;
            }
        }
        foreach (LeaderBoardEntry item in data) {
            Debug.Log(item.score + " " + item.name);
        }
    }

    public void ClearScore() {
        ScoreData.removeData();
        Start();
    }

    public void Quit() {
        Application.Quit();
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#endif
    }

    public void PlayAgain() {
        SceneManager.LoadScene(1);
    }

    public void MainMenu() {
        SceneManager.LoadScene(0);
    }

}
