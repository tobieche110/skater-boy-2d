using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;

public class GameOver : MonoBehaviour
{   

    public TMP_Text currentText;
    public TMP_Text highScoreText;

    public void Start(){
        int score = PlayerPrefs.GetInt("score");
        currentText.text =  PlayerPrefs.GetInt("Score").ToString();

        if (score > PlayerPrefs.GetInt("HighScore")){
            PlayerPrefs.SetInt("HighScore", score);
        }

        PlayerPrefs.SetInt("Score", score);
        currentText.text = PlayerPrefs.GetInt("Score").ToString();
        highScoreText.text = PlayerPrefs.GetInt("HighScore").ToString();
    }

    public void Retry(){

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    }
}
