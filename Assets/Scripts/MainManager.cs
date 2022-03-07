using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.IO;

public class MainManager : MonoBehaviour
{
    public static MainManager Instance;
    public List<HighScore> highScores = new List<HighScore>();

    public TMP_Text highScoreNamesText;
    public TMP_Text highScoreScoresText;

    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);
        LoadHighScores();
    }

    public void AddHighScore(string _player, int _score)
    {
        highScores.Add(new HighScore(_player, _score));

        highScores.Sort((x, y) => y.score.CompareTo(x.score));

        SaveHighScores();
    }

    public void SaveHighScores() {
        PersistentData data = new PersistentData();
        data.savedHighScores = highScores;

        string json = JsonUtility.ToJson(data);

        File.WriteAllText(Application.persistentDataPath + "/high.sav", json);
    }

    public void LoadHighScores()
    {
        string path = Application.persistentDataPath + "/high.sav";
        if(File.Exists(path))
        {
            string json = File.ReadAllText(path);
            PersistentData data = JsonUtility.FromJson<PersistentData>(json);

            highScores = data.savedHighScores;
        }
    }

    [Serializable]
    public class HighScore
    {
        public string playerName;
        public int score;
        
        public HighScore(string _playerName, int _score)
        {
            playerName = _playerName;
            score = _score;
        }
    }
    
    [Serializable]
    class PersistentData
    {
        public List<HighScore> savedHighScores;
    }
}
