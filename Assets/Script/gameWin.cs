using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class gameWin : MonoBehaviour {

private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            GameObject.Find("Character").SendMessage("Finnish");
            GameObject.Find("gameController").SendMessage("Finnish");
        }

    }
	
}