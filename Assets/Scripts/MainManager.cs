using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

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
    }

    public void AddHighScore(string _player, int _score)
    {
        highScores.Add(new HighScore(_player, _score));

        highScores.Sort((x, y) => y.score.CompareTo(x.score));
    }

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
}
