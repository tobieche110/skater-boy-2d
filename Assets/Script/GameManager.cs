using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    
    public void Awake() {
        if (Instance == null){
            Instance =  this;
        }
    }
    
    int score;
    public TMP_Text scoreText;

    public GameObject GameOverPannel;
    public TMP_Text currentText;
    public TMP_Text highScoreText;
    public Button restartButton;


    private void Start() {
        score = 0;
        scoreText.text = score.ToString();
        GameOverPannel.SetActive(false);
        restartButton.onClick.RemoveAllListeners();
        restartButton.onClick.AddListener(RestartLevel);

        currentText.text =  PlayerPrefs.GetInt("Score").ToString();
        
    }

    public void AddScore(int number){
        score = score + number;
        scoreText.text =  score.ToString();

    }

    public void GameOver(){
        if (score > PlayerPrefs.GetInt("HighScore")){
            PlayerPrefs.SetInt("HighScore", score);
        }

        PlayerPrefs.SetInt("Score", score);
        currentText.text = PlayerPrefs.GetInt("Score").ToString();
        GameOverPannel.SetActive(true);
        highScoreText.text = PlayerPrefs.GetInt("HighScore").ToString();
    }

    public void RestartLevel(){
        SceneManager.LoadScene("GameScene");
    }
}
