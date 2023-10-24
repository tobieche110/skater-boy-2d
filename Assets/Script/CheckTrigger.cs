using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckTrigger : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other) {
        
        // if player hits a coin
        if(other.gameObject.tag == "Coin"){
            // Add to Score
            GameManager.Instance.AddScore(5);
            Destroy(other.gameObject);
        }

        // if player hits a wall
        if(other.gameObject.tag == "Wall"){
            // Game Over
            GameManager.Instance.GameOver();
        }

    }
}
