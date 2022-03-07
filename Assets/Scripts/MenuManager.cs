using System.Collections;
using System.Collections.Generic;
#if UNITY_EDITOR
using UnityEditor;
#endif
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class MenuManager : MonoBehaviour
{
    public TMP_Text highScoreNamesText;
    public TMP_Text highScoreScoresText;
    public TMP_Text highScoreTitleText;

    private void Start()
    {
        UpdateHighScore();
    }

    public void OnStartClicked()
    {
        SceneManager.LoadScene(1);
    }

    public void OnExitClicked()
    {
#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#else
        Application.Quit();
#endif
    }

    public void UpdateHighScore()
    {
        if (MainManager.Instance.highScores.Count > 0)
        {
            highScoreTitleText.gameObject.SetActive(true);
            foreach (MainManager.HighScore highScore in MainManager.Instance.highScores)
            {
                highScoreNamesText.text += highScore.playerName + "\n";
                highScoreScoresText.text += highScore.score.ToString() + "\n";
            }
        } else
        {
            highScoreTitleText.gameObject.SetActive(false);
        }
    }
}
