using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

// Kills player when they exit game level.
public class DeathTrigger : MonoBehaviour {

    void OnTriggerEnter2D(Collider2D other) {

        if (other.gameObject.CompareTag("Player")) {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
}
