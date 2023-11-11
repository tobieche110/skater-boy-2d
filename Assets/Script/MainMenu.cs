using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{   
    public void PlayGame(){
        Debug.Log("PlayGame method called");
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
