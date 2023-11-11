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


    private void Start() {
        score = 0;
        scoreText.text = score.ToString();
        
    }

    public void AddScore(int number){
        score = score + number;
        scoreText.text =  score.ToString();

    }

    public void GameOver(){
        PlayerPrefs.SetInt("score", score);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void RestartLevel(){
        SceneManager.LoadScene("GameScene");
    }
}
