using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using TMPro;
using UnityEngine.SceneManagement;

public class FormGame : MonoBehaviour
{
    public GameObject buttonStartHolder;
    public GameObject scoreHolder;
    public GameObject endGameHolder;

    public int score = 0;
    public TMP_Text scoreText;

    public TMP_Text endGameScoreText;

    public void StartGame()
    {
        buttonStartHolder.SetActive(false);
        scoreHolder.SetActive(true);

        GameManager.instance.StartGame();
    }

    public void AddScore()
    {
        score++;
        scoreText.text = score.ToString();

        if (score % 2 == 0) GameManager.instance.IncreaseDifficulties();
    }

    public void EndGame()
    {
        scoreHolder.SetActive(false);
        endGameHolder.SetActive(true);

        endGameScoreText.text = score.ToString();
    }
    
    public void Restart()
    {
        DOTween.KillAll();
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
