using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

// Collider script to trigger winning the level.
public class gameWin : MonoBehaviour {

	public Collider2D win;

private void OnTriggerEnter2D(Collider2D other) {
        if (other.gameObject.CompareTag("Player")) {
            GameObject.Find("Character").SendMessage("Finnish");
            GameObject.Find("gameController").SendMessage("Finnish");
        }

    }
	
}