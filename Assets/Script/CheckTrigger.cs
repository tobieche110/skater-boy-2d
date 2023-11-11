using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckTrigger : MonoBehaviour
{

    public AudioSource crash;
    public AudioSource coin;

    private void OnTriggerEnter2D(Collider2D other) {
        
        // if player hits a coin
        if(other.gameObject.tag == "Coin"){
            // Add to Score
            coin.Play();
            GameManager.Instance.AddScore(5);
            Destroy(other.gameObject);
        }

        // if player hits a wall
        if(other.gameObject.tag == "Wall"){
            // Game Over
            crash.Play();
            GameManager.Instance.GameOver();
            Destroy(gameObject);
        }

    }
}
