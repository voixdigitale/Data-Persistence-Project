using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainManager : MonoBehaviour
{
    public static MainManager Instance;
    public List<HighScore> highScores;

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
