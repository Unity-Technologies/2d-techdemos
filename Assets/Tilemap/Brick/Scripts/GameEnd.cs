using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameEnd : MonoBehaviour 
{
    void OnTriggerEnter2D(Collider2D other) {
        var ball = other.GetComponent<Ball>();
        if (ball != null)
        {
            SceneManager.LoadScene(0);
        }
    }
}
